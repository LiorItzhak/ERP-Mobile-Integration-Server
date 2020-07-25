using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CrossLayersUtils.Utils;
using DataAccessLayer.Entities.UserData;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Impls.Ral
{
    public class LeadUserDataRepository :WriteableRepository<UserData,LeadUserDataKey>,  ILeadUserDataRepository
    {
        private readonly RalDbContext _dbContext;


        public LeadUserDataRepository(RalDbContext dbContext) :base(dbContext.LeadUserData)
        {
            _dbContext = dbContext;
        }


        public async Task<UserData> UpsertAsync(UserData entity)
        {
            //var key = LeadUserDataKey.GetKey(entity);
            var isExist = await _dbContext.LeadUserData.AnyAsync(u => u.UserId == entity.UserId && u.LeadSn == entity.LeadSn);
            UserData r;
            if (isExist)
                r= await UpdateAsync(entity);
            else
                r= await AddAsync(entity);
            return r;

        }
        
        public async Task<IEnumerable<UserData>> UpsertAsync(IEnumerable<UserData> entity)
        {
            return await Task.Run(() => entity.Select(x => UpsertAsync(x).Result));


        }

     
        
        
    }
}


