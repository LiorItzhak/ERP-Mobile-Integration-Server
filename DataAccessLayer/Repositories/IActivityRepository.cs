using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.Entities.BusinessPartners;

namespace DataAccessLayer.Repositories
{
    public interface IActivityRepository : IWritableRepository<Activity,int>
    {
        Task<IEnumerable<ActivityType>> GetAllActivityTypes();
        Task<IEnumerable<ActivitySubject>> GetAllActivitySubjects();
    }
}