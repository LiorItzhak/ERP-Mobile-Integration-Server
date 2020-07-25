using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.Entities.Authentication;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Impls.Ral
{
    public class IdentityUserRepository :ReadOnlyRepository<IdentityUser,int> ,IIdentityRepository
    {
        private readonly RalDbContext _dbContext;
        public IdentityUserRepository(RalDbContext dbContext):base(dbContext.IdentityUsers)
        {
            _dbContext = dbContext;
        }
    }
}