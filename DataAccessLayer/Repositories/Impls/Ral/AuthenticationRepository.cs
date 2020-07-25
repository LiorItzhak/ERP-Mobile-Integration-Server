using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.Entities.Authentication;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Impls.Ral
{
    public class AuthenticationRepository :WriteableRepository<RefreshToken,string>, IAuthenticationRepository
    {
        private readonly RalDbContext _dbContext;

        public AuthenticationRepository(RalDbContext dbContext):base(dbContext.RefreshTokens)
        {
            _dbContext = dbContext;
        }
        

    }
}