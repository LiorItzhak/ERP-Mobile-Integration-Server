using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.Entities.Authentication;

namespace DataAccessLayer.Repositories
{
    public interface IAuthenticationRepository : IWritableRepository<RefreshToken,string>
    {


    }
}