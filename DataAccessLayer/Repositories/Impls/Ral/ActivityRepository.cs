using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities.BusinessPartners;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Impls.Ral
{
    public class ActivityRepository :WriteableRepository<Activity,int>,IActivityRepository
    {
        private readonly RalDbContext _context;
        public ActivityRepository(RalDbContext dbContext) : base(dbContext.Activities)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<ActivityType>> GetAllActivityTypes()
        {
            return await _context.ActivityTypes.ToListAsync();
        }

        public async Task<IEnumerable<ActivitySubject>> GetAllActivitySubjects()
        {
            return await _context.ActivitySubjects.ToListAsync();
        }

        protected override void BeforeModify(Activity entity)
        {
           // entity.LastModifiedDateTime = DateTime.Now;
        }


    }
}