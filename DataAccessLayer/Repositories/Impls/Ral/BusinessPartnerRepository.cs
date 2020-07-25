using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.Entities.BusinessPartners;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Impls.Ral
{
    public class BusinessPartnerRepository : WriteableRepository<BusinessPartner,string>, IBusinessPartnerRepository
    {
        private readonly RalDbContext _dbContext;
        
        public BusinessPartnerRepository(RalDbContext dbContext) :base(dbContext.BusinessPartners)
        {
           _dbContext = dbContext;
        }

        public async Task<IEnumerable<Indicator>> GetAllIndicatorsAsync()
        {
            return await _dbContext.CardIndicators
                .ToListAsync();
        }

        public  async Task<IEnumerable<Industry>> GetAllIndustriesAsync()
        {
            return await _dbContext.CardIndustries
                .ToListAsync();
        }

        public async Task<IEnumerable<AccountBalanceRecordEntity>>GetAccountBalanceRecordsAsync(string cid, Sort<IBusinessPartnerRepository> sort = Sort<IBusinessPartnerRepository>.Unsorted)
        {
            return await _dbContext.AccountBalanceRecords
                .Where(r => r.OwnerSn == cid)
                .SortBy(sort).ToListAsync();
        }



        public async Task<IEnumerable<CardGroup>> GetAllGroupsAsync()
        {
            return await _dbContext.CardGroups
                .ToListAsync();
        }

        protected override void BeforeModify(BusinessPartner entity)
        {
            if(entity.CreationDateTime.HasValue ==false)
                entity.CreationDateTime = DateTime.Now;
            entity.LastUpdateDateTime = DateTime.Now;
            base.BeforeModify(entity);
        }
    }
}
