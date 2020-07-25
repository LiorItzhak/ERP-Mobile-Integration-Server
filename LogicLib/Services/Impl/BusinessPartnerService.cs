using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrossLayersUtils;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.BusinessPartners;
using DataAccessLayer.Repositories;
using FluentValidation;
using LogicLib.Validators;

namespace LogicLib.Services.Impl
{
    public class BusinessPartnerService : IBusinessPartnerService
    {
        private readonly IDalService _dalService;
        public BusinessPartnerService(IDalService dalService)
        {
            _dalService = dalService;
        }


        public async Task<BusinessPartner> AddBusinessPartnerAsync(BusinessPartner businessPartner,
            CancellationToken cancellation)
        {
            var validator = new CustomerValidator(ValidateCardGroupExist, ValidateSalesmanCodeExist);

            validator.RuleFor(x => x.Name).NotEmpty();
            validator.RuleFor(x => x.GroupSn).Must(ValidateCardGroupExist)
                .WithMessage(x => $"Card Group {x.GroupSn} is invalid");
            validator.RuleFor(x => x.SalesmanCode).Must(ValidateSalesmanCodeExist)
                .WithMessage(x => $"Salesman with code {x.SalesmanCode} is  invalid");
            validator.RuleFor(x => x.Key).Null();
            validator.RuleFor(x => x.CreationDateTime).Null();
            var isBusinessPannerValid = await validator.ValidateAsync(businessPartner, cancellation);
           if(!isBusinessPannerValid.IsValid )
               throw new InvalidStateException(isBusinessPannerValid.Errors
                   .Select(x=>x.ErrorMessage).Aggregate((s1,s2)=>$"{s1},{s2}"));


            using var transaction = _dalService.CreateUnitOfWork();
            businessPartner.CreationDateTime = DateTime.Now;
            var result = await transaction.BusinessPartners.AddAsync(businessPartner);
            await transaction.CompleteAsync(cancellation);
            return result;
        }

        public async Task<BusinessPartner> UpdateBusinessPartnerAsync(string cid, BusinessPartner businessPartner,
            CancellationToken cancellation)
        {
            var validator = new CustomerValidator(ValidateCardGroupExist, ValidateSalesmanCodeExist);
            validator.RuleFor(x => x.Key).Must(x => x == cid);
            validator.RuleFor(x => x.Name).Must(x => x == null || !string.IsNullOrWhiteSpace(x));
            validator.RuleFor(x => x.GroupSn).Must(x => !x.HasValue || ValidateCardGroupExist(x))
                .WithMessage(x => $"Card Group {x.GroupSn} is invalid");
            validator.RuleFor(x => x.SalesmanCode).Must(x => !x.HasValue || ValidateSalesmanCodeExist(x))
                .WithMessage(x => $"Salesman with code {x.SalesmanCode} is  invalid");
            var isBusinessPannerValid = await validator.ValidateAsync(businessPartner, cancellation);
            if(!isBusinessPannerValid.IsValid )
                throw new InvalidStateException(isBusinessPannerValid.Errors
                    .Select(x=>x.ErrorMessage).Aggregate((s1,s2)=>$"{s1},{s2}"));

            using var transaction = _dalService.CreateUnitOfWork();
            //TODO check which field are updateable
            var result = await transaction.BusinessPartners.UpdateAsync(businessPartner);
            await transaction.CompleteAsync(cancellation);
            return result;
        }


        public async Task<IEnumerable<BusinessPartner>> GetPageAsync(int page, int size, DateTime? modifiedAfter)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            return await transaction.BusinessPartners.FindAllAsync(
                //x => !modifiedAfter.HasValue || x.LastModifiedDateTime > modifiedAfter,
                x => !modifiedAfter.HasValue ||( x.LastUpdateDateTime ?? x.CreationDateTime )> modifiedAfter,
                PageRequest.Of(page, size, Sort<BusinessPartner>.By(x => x.CreationDateTime)));
        }


        public async Task<IEnumerable<CardGroup>> GetCardGroupsAsync()
        {
            using var transaction = _dalService.CreateUnitOfWork();
            return await transaction.BusinessPartners.GetAllGroupsAsync();
        }

        public async Task<IEnumerable<Indicator>> GetCardIndicatorsAsync()
        {
            using var transaction = _dalService.CreateUnitOfWork();
            return await transaction.BusinessPartners.GetAllIndicatorsAsync();
        }

        public async Task<IEnumerable<Industry>> GetCardIndustriesAsync()
        {
            using var transaction = _dalService.CreateUnitOfWork();
            return await transaction.BusinessPartners.GetAllIndustriesAsync();
        }


        public async Task<BusinessPartner> GetByKeyAsync(string cid)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            return await transaction.BusinessPartners.FindByIdAsync(cid);
        }
        
        
        
        public async Task<IEnumerable<AccountBalanceRecordEntity>> GetBalanceAsync(string cid)
        {
            using var transaction = _dalService.CreateUnitOfWork();
            var t =  await transaction.BusinessPartners.GetAccountBalanceRecordsAsync( cid);
            return t;
        }



        private static Dictionary<int, CardGroup> _cacheGroups;

        private bool ValidateCardGroupExist(int? cardGroupSn)
        {
            if (cardGroupSn.HasValue && (_cacheGroups == null || !_cacheGroups.ContainsKey(cardGroupSn.Value)))
                _cacheGroups = GetCardGroupsAsync().Result.ToDictionary(k => k.Sn, v => v);
            return cardGroupSn.HasValue && _cacheGroups.ContainsKey(cardGroupSn.Value);
        }

        private static Dictionary<int, SalesmanEntity> _cachedSalesmen;

        private bool ValidateSalesmanCodeExist(int? salesmanCode)
        {
            if (!salesmanCode.HasValue || (_cachedSalesmen != null && _cachedSalesmen.ContainsKey(salesmanCode.Value)))
                return salesmanCode.HasValue && _cachedSalesmen.ContainsKey(salesmanCode.Value);
            using var transaction = _dalService.CreateUnitOfWork();
            _cachedSalesmen = transaction.Salesmen
                .GetAllAsync(PageRequest.Of(0, int.MaxValue)).Result.ToDictionary(k => k.Sn, v => v);
            return _cachedSalesmen.ContainsKey(salesmanCode.Value);
        }
    }
}