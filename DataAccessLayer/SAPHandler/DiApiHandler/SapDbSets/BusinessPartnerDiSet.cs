using DataAccessLayer.Entities;
using System;
using SAPbobsCOM;
using System.Diagnostics;
using CrossLayersUtils;
using static DataAccessLayer.SAPHandler.DiApiHandler.SapDiApiContext;
using CrossLayersUtils.Aspects;
using DataAccessLayer.Entities.BusinessPartners;

// ReSharper disable ClassNeverInstantiated.Global
namespace DataAccessLayer.SAPHandler.DiApiHandler.SapDbSets
{
    public class BusinessPartnerDiSet : DiSet<BusinessPartner, string>
    {
        public BusinessPartnerDiSet(CompanyContext context) : base(context)
        {
        }


        [LogMethod]
        public override BusinessPartner Add(BusinessPartner businessPartner)
        {
            if (businessPartner.Key != null)
                throw new InvalidStateException("BusinessPartner with a card code cant be add!");
            var company = Context.ConnectCompany();
            var businessPartnerSap = MapToSapBusinessPartner(
                (BusinessPartners) company.GetBusinessObject(BoObjectTypes.oBusinessPartners), businessPartner);
            //Get CardCode Automatically//
            var records = (Recordset) company.GetBusinessObject(BoObjectTypes.BoRecordset);
            records.DoQuery("SELECT DfltSeries FROM ONNM WHERE ObjectCode = '2' AND DocSubType = 'C'");
            records.MoveFirst();
            businessPartnerSap.Series = int.Parse(records.Fields.Item("DfltSeries").Value.ToString());
            var errCode = businessPartnerSap.Add();
            if (errCode != 0)
                throw new Exception(
                    $"SAP-DI-API -add remove the businessPartner, error code {errCode} {company.GetLastErrorDescription()}");

            businessPartner.Key = company.GetNewObjectKey(); //get the new cardCode
            Debug.WriteLine($"businessPartner with  cardCode {businessPartner.Key} added!");
            Context.IncrementAffectedObjectCounter();
            businessPartnerSap.GetByKey(businessPartner.Key);
            var businessPartnerAdded = MapToBusinessPartnerEntity(company, new BusinessPartner(), businessPartnerSap);
            businessPartnerAdded.LastUpdateDateTime = null; //follow sap policy
            businessPartnerAdded.CreationDateTime = DateTime.Now;
            return businessPartnerAdded;
        }

        [LogMethod]
        public override void Remove(string id)
        {
            if (string.IsNullOrEmpty(id))
                throw new IllegalArgumentException("Cant remove a businessPartner with cardCode that is null or empty");

            var company = Context.ConnectCompany();
            var businessPartnerSap = (BusinessPartners) company.GetBusinessObject(BoObjectTypes.oBusinessPartners);

            if (businessPartnerSap.GetByKey(id))
            {
                var errCode = businessPartnerSap.Remove();
                if (errCode != 0)
                    throw new Exception(
                        $"SAP-DI-API -cant remove the businessPartner, error code {errCode} {company.GetLastErrorDescription()}");
                Context.IncrementAffectedObjectCounter();
                Debug.WriteLine($"businessPartner with  cardCode {id} removed!");
            }
            else
                throw new NotFoundException($"businessPartner don't exist : CardCode= = {id}");
        }

        [LogMethod]
        public override BusinessPartner Update(BusinessPartner businessPartner)
        {
            var company = Context.ConnectCompany();
            var businessPartnerSap = (BusinessPartners) company.GetBusinessObject(BoObjectTypes.oBusinessPartners);

            if (!businessPartnerSap.GetByKey(businessPartner.Key))
                throw new NotFoundException($"businessPartner don't exist : CardCode= = {businessPartner.Key}");
            //BUG - some applications dont send the creation date of the businessPartner - set a fake one
            var creationTime = businessPartner.CreationDateTime ?? DateTime.Now;
            businessPartnerSap = MapToSapBusinessPartner(businessPartnerSap, businessPartner);
            var errCode = businessPartnerSap.Update();
            if (errCode != 0)
                throw new Exception(
                    $"SAP-DI-API -cant update the businessPartner, error code {errCode} {company.GetLastErrorDescription()} ");

            Debug.WriteLine($"BusinessPartner with  cardCode {businessPartner.Key} updated!");
            Context.IncrementAffectedObjectCounter();
            businessPartnerSap.GetByKey(businessPartner.Key);
            var businessPartnerAdded = MapToBusinessPartnerEntity(company, new BusinessPartner(), businessPartnerSap);
            businessPartnerAdded.LastUpdateDateTime = DateTime.Now;
            businessPartnerAdded.CreationDateTime = creationTime;
            return businessPartnerAdded;
        }

        private static BusinessPartners MapToSapBusinessPartner(BusinessPartners sapBusinessPartner,
            BusinessPartner businessPartnerEntity)
        {
            if (businessPartnerEntity.Key != null && sapBusinessPartner.CardCode == null)
                sapBusinessPartner.CardCode = businessPartnerEntity.Key;


            if (businessPartnerEntity.PartnerType != null)
            {
                sapBusinessPartner.CardType = businessPartnerEntity.PartnerType switch
                {
                    BusinessPartner.PartnerTypes.Customer => BoCardTypes.cCustomer,
                    BusinessPartner.PartnerTypes.Lead => BoCardTypes.cLid,
                    BusinessPartner.PartnerTypes.Supplier => BoCardTypes.cSupplier,
                    _ => throw new Exception("CardType not recognized by sap di-api")
                };
            }

            if (businessPartnerEntity.Name != null)
                sapBusinessPartner.CardName = businessPartnerEntity.Name;

            if (businessPartnerEntity.GroupSn != null)
                sapBusinessPartner.GroupCode = businessPartnerEntity.GroupSn.Value;
            if (businessPartnerEntity.Phone1 != null)
                sapBusinessPartner.Phone1 = businessPartnerEntity.Phone1;
            if (businessPartnerEntity.Phone2 != null)
                sapBusinessPartner.Phone2 = businessPartnerEntity.Phone2;
            if (businessPartnerEntity.Cellular != null)
                sapBusinessPartner.Cellular = businessPartnerEntity.Cellular;
            if (businessPartnerEntity.Email != null)
                sapBusinessPartner.EmailAddress = businessPartnerEntity.Email;
            if (businessPartnerEntity.Fax != null)
                sapBusinessPartner.Fax = businessPartnerEntity.Fax;
            if (businessPartnerEntity.FederalTaxId != null)
                sapBusinessPartner.FederalTaxID = businessPartnerEntity.FederalTaxId;
            if (businessPartnerEntity.Type != null)
                sapBusinessPartner.CompanyPrivate =
                    businessPartnerEntity.Type switch
                    {
                        BusinessPartner.CardType.Company => BoCardCompanyTypes.cCompany,
                        BusinessPartner.CardType.Private => BoCardCompanyTypes.cPrivate,
                        BusinessPartner.CardType.Employee => BoCardCompanyTypes.cGovernment,
                        _ => BoCardCompanyTypes.cCompany
                    };

            if (businessPartnerEntity.IsVatFree.HasValue)
                sapBusinessPartner.VatLiable =
                    businessPartnerEntity.IsVatFree.Value ? BoVatStatus.vExempted : BoVatStatus.vLiable;

            if (businessPartnerEntity.DiscountPercent.HasValue)
                sapBusinessPartner.DiscountPercent = Convert.ToDouble(businessPartnerEntity.DiscountPercent.Value);

            if (businessPartnerEntity.Comments != null)
                sapBusinessPartner.Notes = businessPartnerEntity.Comments;

            if (businessPartnerEntity.SalesmanCode.HasValue)
                sapBusinessPartner.SalesPersonCode = businessPartnerEntity.SalesmanCode.Value;

//            if (businessPartner.GeoLocation !=null && (businessPartner.GeoLocation.HasLocation() || businessPartner.GeoLocation.IsLocationNull))
//                businessPartnerSap.GlobalLocationNumber = businessPartner.GeoLocation.ToLocationString();
            if (businessPartnerEntity.GeoLocation != null)
            {
                // SAP GlpLocNum is a 50 chars string, temporarily I save the location as a string value
                if (businessPartnerEntity.GeoLocation is SapGeoLocation sapGeoLocation && sapGeoLocation != null &&
                    sapGeoLocation.HasLocation())
                    sapBusinessPartner.GlobalLocationNumber = sapGeoLocation.ToLocationString();
                else
                    sapBusinessPartner.GlobalLocationNumber =
                        SapGeoLocation.From(businessPartnerEntity.GeoLocation).ToLocationString();
            }


            foreach (var address in new[] {businessPartnerEntity.BillingAddress, businessPartnerEntity.ShippingAddress})
            {
                if (address == null || string.IsNullOrEmpty(address.ID)) continue;
                var sapAddrType = address == businessPartnerEntity.BillingAddress
                    ? BoAddressType.bo_BillTo
                    : BoAddressType.bo_ShipTo;
                for (var i = 0; i < sapBusinessPartner.Addresses.Count - 1; i++)
                {
                    sapBusinessPartner.Addresses.SetCurrentLine(i);
                    if (sapBusinessPartner.Addresses.AddressType == sapAddrType &&
                        !string.IsNullOrEmpty(sapBusinessPartner.Addresses.AddressName?.Trim()))
                        sapBusinessPartner.Addresses.Delete();
                }

                sapBusinessPartner.Addresses.SetCurrentLine(sapBusinessPartner.Addresses.Count - 1);
                sapBusinessPartner.Addresses.AddressType = sapAddrType;
                sapBusinessPartner.Addresses.AddressName = address.ID;
                sapBusinessPartner.Addresses.Country = address.Country;
                sapBusinessPartner.Addresses.City = address.City;
                sapBusinessPartner.Addresses.Block = address.Block;
                sapBusinessPartner.Addresses.Street = address.Street;
                sapBusinessPartner.Addresses.StreetNo = address.NumAtStreet;
                sapBusinessPartner.Addresses.BuildingFloorRoom = address.Apartment;
                sapBusinessPartner.Addresses.ZipCode = address.ZipCode;
                sapBusinessPartner.Addresses.Add();
            }

            if (businessPartnerEntity.IsActive.HasValue)
            {
                sapBusinessPartner.Valid = businessPartnerEntity.IsActive.Value ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
                sapBusinessPartner.Frozen = !businessPartnerEntity.IsActive.Value ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
            }

            if (businessPartnerEntity.IsFavorite.HasValue)
            {
                sapBusinessPartner.Properties[64] =
                    businessPartnerEntity.IsFavorite.Value ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
            }

            
            sapBusinessPartner.Indicator = businessPartnerEntity.IndicatorCode; //if null - remove indicator
            
            sapBusinessPartner.Industry = businessPartnerEntity.IndustryCode ?? -1; //if null code =>-1
            
            if (businessPartnerEntity.AttachmentsCode.HasValue && businessPartnerEntity.AttachmentsCode != 0 )
                sapBusinessPartner.AttachmentEntry = businessPartnerEntity.AttachmentsCode.Value;

            return sapBusinessPartner;
        }

        private static CardGroup MapToGroupEntity(IBusinessPartnerGroups group)
        {
            return new CardGroup
            {
                Sn = group.Code,
                Name = group.Name
            };
        }

        private static SalesmanEntity MapToSalesmanEntity(ICompany company, ISalesPersons sameperson)
        {
            var employee = (EmployeesInfo) company.GetBusinessObject(BoObjectTypes.oEmployeesInfo);
            var salesman = new SalesmanEntity
            {
                Sn = sameperson.SalesEmployeeCode,
                Name = sameperson.SalesEmployeeName,
                ActiveStatus = sameperson.Active == BoYesNoEnum.tYES
                    ? SalesmanEntity.Status.Active
                    : SalesmanEntity.Status.NoActive
            };
            if (!employee.GetByKey(sameperson.EmployeeID)) return salesman;
            salesman.Mobile = employee.MobilePhone;
            salesman.Email = employee.eMail;
            return salesman;
        }

        private static BusinessPartner MapToBusinessPartnerEntity(ICompany company, BusinessPartner businessPartner,
            BusinessPartners businessPartnerSap)
        {
            businessPartner.PartnerType = businessPartnerSap.CardType switch
            {
                BoCardTypes.cCustomer => BusinessPartner.PartnerTypes.Customer,
                BoCardTypes.cLid => BusinessPartner.PartnerTypes.Lead,
                BoCardTypes.cSupplier => BusinessPartner.PartnerTypes.Supplier,
                _ => throw new Exception("PartnerType not recognized by sap di-api")
            };

            businessPartner.Name = businessPartnerSap.CardName;
            businessPartner.Key = businessPartnerSap.CardCode;
            var groups = (BusinessPartnerGroups) company.GetBusinessObject(BoObjectTypes.oBusinessPartnerGroups);
            if (!groups.GetByKey(businessPartnerSap.GroupCode))
            {
                Debug.WriteLine($"DiAi - group don't exist : code=  {businessPartnerSap.GroupCode}");
                throw new Exception($"DiAi - group don't exist : code=  {businessPartnerSap.GroupCode}");
            }

            businessPartner.GroupSn = businessPartnerSap.GroupCode;

            //businessPartner.Group = mapToGroupEntity(groups);
            businessPartner.Phone1 = businessPartnerSap.Phone1;
            businessPartner.Phone2 = businessPartnerSap.Phone2;
            businessPartner.Cellular = businessPartnerSap.Cellular;
            businessPartner.Email = businessPartnerSap.EmailAddress;
            businessPartner.Fax = businessPartnerSap.Fax;
            
            businessPartner.FederalTaxId = businessPartnerSap.FederalTaxID;
            businessPartner.Type = businessPartnerSap.CompanyPrivate switch
            {
                BoCardCompanyTypes.cCompany => BusinessPartner.CardType.Company,
                BoCardCompanyTypes.cPrivate => BusinessPartner.CardType.Private,
                BoCardCompanyTypes.cGovernment => BusinessPartner.CardType.Employee,
                _ => BusinessPartner.CardType.Company
            };

            businessPartner.Comments = businessPartnerSap.Notes;

            var salesperson = (SalesPersons) company.GetBusinessObject(BoObjectTypes.oSalesPersons);
            if (!salesperson.GetByKey(businessPartnerSap.SalesPersonCode))
            {
                Debug.WriteLine($"DiAi - SalePerson don't exist : code=  {businessPartnerSap.SalesPersonCode}");
                throw new Exception($"DiAi - SalePerson don't exist : code=  {businessPartnerSap.SalesPersonCode}");
            }

            

            businessPartner.SalesmanCode = businessPartnerSap.SalesPersonCode;

            for (var i = businessPartnerSap.Addresses.Count - 1;
                i >= 0 && (businessPartner.ShippingAddress == null || businessPartner.BillingAddress == null);
                i--)
            {
                businessPartnerSap.Addresses.SetCurrentLine(i);
                if (string.IsNullOrEmpty( businessPartnerSap.Addresses.AddressName)) continue;

                if (businessPartnerSap.Addresses.AddressType == BoAddressType.bo_BillTo)
                    businessPartner.BillingAddress = new Address();
                else
                    businessPartner.ShippingAddress = new Address();
                var address = businessPartnerSap.Addresses.AddressType == BoAddressType.bo_BillTo
                    ? businessPartner.BillingAddress
                    : businessPartner.ShippingAddress;

                if (address == null) continue;
                address.ID = businessPartnerSap.Addresses.AddressName;
                address.Country = businessPartnerSap.Addresses.Country;
                address.City = businessPartnerSap.Addresses.City;
                address.Block = businessPartnerSap.Addresses.Block;
                address.Street = businessPartnerSap.Addresses.Street;
                address.NumAtStreet = businessPartnerSap.Addresses.StreetNo;
                address.Apartment = businessPartnerSap.Addresses.BuildingFloorRoom;
                address.ZipCode = businessPartnerSap.Addresses.ZipCode;
            }

            businessPartner.IsActive = businessPartnerSap.Valid == BoYesNoEnum.tYES;

            businessPartner.IsVatFree = businessPartnerSap.VatLiable != BoVatStatus.vLiable;

            businessPartner.Balance = Convert.ToDecimal(businessPartnerSap.CurrentAccountBalance);

            businessPartner.Balance = Convert.ToDecimal(businessPartnerSap.CurrentAccountBalance);
            businessPartner.OrdersBalance = Convert.ToDecimal(businessPartnerSap.OpenOrdersBalance);
            businessPartner.DeliveryNotesBalance = Convert.ToDecimal(businessPartnerSap.OpenDeliveryNotesBalance);
            businessPartner.DiscountPercent = Convert.ToDecimal(businessPartnerSap.DiscountPercent);
            businessPartner.Currency = businessPartnerSap.Currency;
            if (!string.IsNullOrEmpty(businessPartnerSap.GlobalLocationNumber))
                businessPartner.GeoLocation = new SapGeoLocation
                {
                    LocationString = businessPartnerSap.GlobalLocationNumber
                };

            businessPartner.IsFavorite = businessPartnerSap.Properties[64] == BoYesNoEnum.tYES;
            businessPartner.IndicatorCode = businessPartnerSap.Indicator;
            businessPartner.IndustryCode = businessPartnerSap.Industry;
            businessPartner.AttachmentsCode = businessPartnerSap.AttachmentEntry!=0 ? businessPartnerSap.AttachmentEntry: new int?();
            return businessPartner;
        }
    }
}