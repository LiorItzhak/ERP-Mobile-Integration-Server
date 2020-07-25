using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataAccessLayer.Repositories.Impls.Ral

{
    public class UserLocationRepository:WriteableRepository<UserLocation,long>, IUserLocationRepository
    {
        public UserLocationRepository(RalDbContext dbContext) :base(dbContext.UserLocations)
        {
        }


     
    }
}