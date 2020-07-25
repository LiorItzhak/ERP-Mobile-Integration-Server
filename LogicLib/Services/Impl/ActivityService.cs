using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using CrossLayersUtils;
using DataAccessLayer;
using DataAccessLayer.Entities.BusinessPartners;
using DataAccessLayer.Repositories;

namespace LogicLib.Services.Impl
{
    public class ActivityService : IActivityService
    {
        private readonly IDalService _dalService;

        public ActivityService(IDalService dalService)
        {
            _dalService = dalService;
        }

        public async Task<Activity> GetActivityAsync(int code)
        {
            using var uow = _dalService.GetReadOnlyUnitOfWork();
            var r = await uow.Activities.FindByIdAsync(code);
            return r;
        }

        public async Task<List<Activity>> GetActivitiesAsync(int page, int size, string businessPartnerCode = null,
            int? handleByEmployee = null,
            DateTime? modifiedAfter = null)
        {
            using var uow = _dalService.GetReadOnlyUnitOfWork();
            var aPage = await uow.Activities.FindAllAsync(
                x =>
                    (handleByEmployee.HasValue == false || handleByEmployee == x.HandleByEmployeeCode) &&
                    (businessPartnerCode == null || businessPartnerCode == x.BusinessPartnerCode) &&
                    (modifiedAfter.HasValue == false || x.LastModifiedDateTime.HasValue == false ||
                     x.LastModifiedDateTime > modifiedAfter),
                PageRequest.Of(page, size, Sort<Activity>.By(x => x.CreationDateTime)));
            //     aPage.ForEach(x=>x.LastModifiedDateTime = x.CreationDateTime);
            return aPage;
        }

        public async Task<Activity> UpdateActivityAsync(int code, Activity activity,
            CancellationToken cancellationToken = default)
        {
            if (activity.Code != code)
                throw new IllegalArgumentException("code must match activity's code (cant modify activity code");
            using var uow = _dalService.CreateUnitOfWork();
            //TODO check activity
            var x = await uow.Activities.UpdateAsync(activity);
            await uow.CompleteAsync(cancellationToken);
            return x;
        }

        public async Task<Activity> CreateNewActivityAsync(Activity activity,
            CancellationToken cancellationToken = default)
        {
            //TODO check activity
            if (activity.Code.HasValue)
                throw new IllegalArgumentException(
                    "cant create new activity with existing code (you must supply null code)");
            using var uow = _dalService.CreateUnitOfWork();
            //if the new activity is a follow up of previous one - close the previous 
            if (activity.BaseActivity.HasValue)
            {
                var baseActivity = await uow.Activities.FindByIdAsync(activity.BaseActivity.Value);
                if (baseActivity.IsClosed == false)
                {
                    baseActivity.IsClosed = true;
                    await uow.Activities.UpdateAsync(baseActivity);
                }
            }

            var x = await uow.Activities.AddAsync(activity);
            await uow.CompleteAsync(cancellationToken);
            return x;
        }

        public async Task<IEnumerable<ActivityType>> GetActivitiesTypesAsync()
        {
            var uow = _dalService.GetReadOnlyUnitOfWork();
            return await uow.Activities.GetAllActivityTypes();
        }

        public async Task<IEnumerable<ActivitySubject>> GetActivitySubjectsAsync()
        {
            var uow = _dalService.GetReadOnlyUnitOfWork();
            return await uow.Activities.GetAllActivitySubjects();
        }

      
    }
}