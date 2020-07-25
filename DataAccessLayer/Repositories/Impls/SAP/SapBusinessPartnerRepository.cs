using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.SAPHandler.SqlHandler.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DataAccessLayer.Entities.BusinessPartners;
using DataAccessLayer.Repositories.Impls.Ral;
using DataAccessLayer.SAPHandler.DiApiHandler;
using DataAccessLayer.SAPHandler.SqlHandler.DbContexts;


namespace DataAccessLayer.Repositories.Impls.SAP
{
    public class SapBusinessPartnerRepository :SapWriteableRepository<BusinessPartner,string>, IBusinessPartnerRepository
    {
        private readonly SapSqlDbContext _dbContext;
        private readonly SapDiApiContext _diApiContext;
        public SapBusinessPartnerRepository(SapSqlDbContext dbContext, SapDiApiContext diApiContext)
            :base(SelectBusinessPartnerFromDb(dbContext),x=>x.Key,diApiContext.BusinessPartners)
        {
            _dbContext = dbContext;
            _diApiContext = diApiContext;
        }

        
        public async Task<IEnumerable<CardGroup>> GetAllGroupsAsync()
        {
            return await SelectGroupFromDb().ToListAsync();
        }

        public async Task<IEnumerable<Indicator>> GetAllIndicatorsAsync()
        {
            return await SelectIndicatorFromDb().ToListAsync();
        }

        public async Task<IEnumerable<Industry>> GetAllIndustriesAsync()
        {
            return await SelectIndustryFromDb().ToListAsync();
        }

        // public new  async Task<BusinessPartner> FindByIdAsync(string id)
        // {
        //     return await SelectEntityQuery.Where(x=>x.Cid == id)
        //         //.Where(x => SelectId .Compile().Invoke(x) .Equals(id))
        //         .SingleOrDefaultAsync();
        // }


        public async Task<IEnumerable<AccountBalanceRecordEntity>> GetAccountBalanceRecordsAsync(string cid, Sort<IBusinessPartnerRepository> sort = Sort<IBusinessPartnerRepository>.Unsorted)
        {
            return await SelectAccountBalanceRecordEntityDb()
                .SortBy(sort)
                .Where(record => record.OwnerSn == cid).ToListAsync();
        }

        private IQueryable<AccountBalanceRecordEntity> SelectAccountBalanceRecordEntityDb()
        {
            return _dbContext.JDT1.Select(AsAccountBalanceRecord);
        }

        private static readonly Expression<Func<JDT1, AccountBalanceRecordEntity>> AsAccountBalanceRecord =
            j => new AccountBalanceRecordEntity
            {
                SN = j.TransId,
                OwnerSn = j.ShortName,
                Doc1Sn = j.BaseRef,
                Doc2Sn = j.Ref2,
                Date = j.RefDate.Value,
                Debt = j.Debit.Value - j.Credit.Value,
                BalanceDebt = j.BalDueDeb.Value - j.BalDueCred.Value,
                Currency = j.FCCurrency ?? "₪", //TODO
                Memo = j.LineMemo,
                // ReSharper disable once ConvertConditionalTernaryExpressionToSwitchExpression
                Type = j.TransType == "13" ? AccountBalanceRecordEntity.DocumentTypes.Invoice :
                    j.TransType == "24" ? AccountBalanceRecordEntity.DocumentTypes.Receipt :
                    j.TransType == "14" ? AccountBalanceRecordEntity.DocumentTypes.CreditInvoice :
                    j.TransType == "30" ? AccountBalanceRecordEntity.DocumentTypes.Journal :
                    AccountBalanceRecordEntity.DocumentTypes.Other
            };

        private IQueryable<CardGroup> SelectGroupFromDb()
        {
            return _dbContext.OCRG.Select(AsCardGroupEntity);
        }

        private IQueryable<Industry> SelectIndustryFromDb()
        {
            return _dbContext.OOND.Select(AsCardIndustry);
        }
        private IQueryable<Indicator> SelectIndicatorFromDb()
        {
            return _dbContext.OIDC.Select(AsIndicator);
        }

        private static readonly Expression<Func<OCRG, CardGroup>> AsCardGroupEntity =
            g => new CardGroup
            {
                Name = g.GroupName,
                Sn = g.GroupCode
            };
        private static readonly Expression<Func<OOND, Industry>> AsCardIndustry =
            g => new Industry
            {
                Name = g.IndName,
                Code = g.IndCode
            };
        
        private static readonly Expression<Func<OIDC, Indicator>> AsIndicator =
            x => new Indicator
            {
                Code = x.Code,
                Name = x.Name
            };


        
        private static IQueryable<BusinessPartner> SelectBusinessPartnerFromDb(SapSqlDbContext dbContext)
        {
            return dbContext.OCRD
            //    .Where(x => x.CardName != null && x.CardName.Trim() != "")
                .Select(AsCustomerEntity);
        }

        private static readonly Expression<Func<OCRD, BusinessPartner>> AsCustomerEntity =
            c => new BusinessPartner
            {
                
                Name = c.CardName,
                Key = c.CardCode,
                // ReSharper disable once ConvertConditionalTernaryExpressionToSwitchExpression
                PartnerType = c.CardType == "C" ? BusinessPartner.PartnerTypes.Customer :
                    c.CardType == "L" ? BusinessPartner.PartnerTypes.Lead : BusinessPartner.PartnerTypes.Supplier /*S*/,
                //Group = AsCardGroupEntity.Compile()(g),
                GroupSn = c.GroupCode,
                // ReSharper disable once ConvertConditionalTernaryExpressionToSwitchExpression
                Type = c.CmpPrivate == "C" ? BusinessPartner.CardType.Company :
                    c.CmpPrivate == "I" ? BusinessPartner.CardType.Private :
                    c.CmpPrivate == "S" ? BusinessPartner.CardType.Employee : BusinessPartner.CardType.Company,

                FederalTaxId = c.LicTradNum??"",
                Phone1 = c.Phone1??"",
                Phone2 = c.Phone2??"",
                Cellular = c.Cellular??"",
                Email = c.E_Mail??"",
                Fax = c.Fax??"",
                Balance = c.Balance,
                OrdersBalance = c.OrdersBal,
                DeliveryNotesBalance = c.DNotesBal,
                IsVatFree = c.VatStatus == "N",
                Currency = c.Currency,
                DiscountPercent = c.Discount,
                Comments = c.Notes??"",
                IsActive = c.frozenFor == "N" || c.validFor == "Y",

                SalesmanCode = c.SlpCode,

                CreationDateTime = c.CreateTS.HasValue && c.CreateDate.HasValue ? c.CreateDate.Value
                        .AddSeconds( c.CreateTS.Value % 100)
                        .AddMinutes(( c.CreateTS.Value / 100) % 100)
                        .AddHours(( c.CreateTS.Value / 10000) % 10000) : c.CreateDate,
                
                LastUpdateDateTime = c.UpdateTS.HasValue && c.UpdateDate.HasValue ? c.UpdateDate.Value
                    .AddSeconds( c.UpdateTS.Value % 100)
                    .AddMinutes(( c.UpdateTS.Value / 100) % 100)
                    .AddHours(( c.UpdateTS.Value / 10000) % 10000) : c.UpdateDate,
                

                BillingAddress =  string.IsNullOrEmpty( c.BillToDef) ==false ? new Address
                {
                    ID = c.BillToDef,
                    Country = c.Country,
                    City = c.City,
                    Block = c.Block,
                    Street = c.Address,
                    NumAtStreet = c.StreetNo,
                    Apartment = c.Building,
                    ZipCode = c.ZipCode
                } :null,
                ShippingAddress = string.IsNullOrEmpty( c.ShipToDef) ==false? new Address
                {
                    ID = c.ShipToDef,
                    Country = c.MailCounty,
                    City = c.MailCity,
                    Block = c.MailBlock,
                    Street = c.MailAddres,
                    NumAtStreet = c.MailStrNo,
                    Apartment = c.MailBuildi,
                    ZipCode = c.MailZipCod
                }: null,

                GeoLocation = string.IsNullOrEmpty(c.GlblLocNum ) ==false ?new SapGeoLocation
                {
                    LocationString = c.GlblLocNum
                }:null,
                IsFavorite = c.QryGroup64 == "Y",
                
                IndicatorCode = c.Indicator,
                IndustryCode = c.IndustryC,
                AttachmentsCode = c.AtcEntry

            };
    }
}