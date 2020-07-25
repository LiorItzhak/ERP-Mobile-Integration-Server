using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Entities.BusinessPartners;
using DataAccessLayer.Entities.Documents;

namespace LogicLib.Services
{
    public interface IActivityService
    {
        Task<Activity> GetActivityAsync(int code);
        Task<List<Activity>> GetActivitiesAsync(int page, int size,string businessPartnerCode = null, int? handleByEmployee =null, DateTime? modifiedAfter = null);

        Task<Activity> UpdateActivityAsync(int code,Activity activity, CancellationToken cancellationToken = default);
        Task<Activity> CreateNewActivityAsync(Activity activity, CancellationToken cancellationToken = default);


        Task<IEnumerable<ActivityType>> GetActivitiesTypesAsync();
        Task<IEnumerable<ActivitySubject>> GetActivitySubjectsAsync();
    }
}