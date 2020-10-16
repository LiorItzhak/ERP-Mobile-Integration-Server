using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.Entities.BusinessPartners;
using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Repositories.Impls.Ral;
using DataAccessLayer.SAPHandler;
using DataAccessLayer.SAPHandler.DiApiHandler;
using DataAccessLayer.SAPHandler.SqlHandler.DbContexts;
using DataAccessLayer.SAPHandler.SqlHandler.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Activity = DataAccessLayer.Entities.BusinessPartners.Activity;

namespace DataAccessLayer.Repositories.Impls.SAP
{
    public class SapActivityRepository : SapWriteableRepository<Activity, int>, IActivityRepository
    {
        private readonly SapSqlDbContext _context;

        //   private readonly ActivityRepository _activityRepository;
        //  private readonly RalDbContext _extraDbContext;

        private static Dictionary<int, Activity> _cachedActivities;

        public SapActivityRepository(SapSqlDbContext dbContext, SapDiApiContext diApiContext,
            RalDbContext extraDbContext, SapContextOptions options)
            : base(SelectActivitiesFromDb(dbContext), x => x.Code.Value, diApiContext.Activities)
        {
            _context = dbContext;
            if (_cachedActivities == null)
            {
                _cachedActivities = new Dictionary<int, Activity>();
                extraDbContext.Activities.ForEachAsync(a =>
                {
                    if (a.Code != null) _cachedActivities[a.Code.Value] = a;
                }).Wait();
            }
            else
            {
#pragma warning disable 4014
                SyncActivitiesCache(options);
#pragma warning restore 4014
            }
        }

        private static DateTime? _lastSync = new DateTime?();

        private static void SyncActivitiesCache(SapContextOptions options)
        {
            Task.Run(() =>
            {
                if (_lastSync.HasValue && _lastSync.Value.AddMinutes(10) >= DateTime.Now) return;
                _lastSync = DateTime.Now;
                var extraDbContext = new RalDbContext(options.ExtrasServerOptions);
                var dbActivities = extraDbContext.Activities.ToList();
                var unchanged = 0;
                var cachedActivitiesValues = _cachedActivities.Values;
                foreach (var cachedActivity in cachedActivitiesValues)
                {
                    var dbActivity = dbActivities.SingleOrDefault(x => x.Code == cachedActivity.Code);
                    if (cachedActivity.Code == 8)
                        Console.WriteLine("e");
                    if (dbActivity == null)
                        extraDbContext.Activities.Add(cachedActivity);
                    else if (dbActivity.Equals(cachedActivity) == false)
                    {
                        extraDbContext.Entry(dbActivity).CurrentValues.SetValues(cachedActivity);
                        // temp = extraDbContext.Activities.Update(cachedActivity);
                    }
                    else
                        unchanged++;
                }

                if (unchanged != cachedActivitiesValues.Count)
                    extraDbContext.SaveChanges();
            });
        }

        private class ActContainer
        {
            public OHEM Ohem { get; set; }
            public OCLG Oclg { get; set; }
        }

        private static IQueryable<Activity> SelectActivitiesFromDb(SapSqlDbContext dbContext) =>
            (from oclg in dbContext.OCLG
                join ohem in dbContext.OHEM on oclg.AttendUser equals ohem.userId into gj
                from sub in gj.DefaultIfEmpty()
                select new ActContainer
                {
                    Oclg = oclg,
                    Ohem = sub
                }).Select(AsActivity);


        public async Task<IEnumerable<ActivityType>> GetAllActivityTypes()
            => await _context.OCLT.Select(AsActivityType).ToListAsync();


        public async Task<IEnumerable<ActivitySubject>> GetAllActivitySubjects()
            => await _context.OCLS.Select(AsActivitySubject).ToListAsync();

        public new async Task<List<Activity>> GetAllAsync(PageRequest pageRequest)
            => await base.GetAllAsync(pageRequest).MergeCacheAsync(_cachedActivities);


        public new async Task<Activity> SingleOrDefaultAsync(Expression<Func<Activity, bool>> predicate)
        {
            return (await SelectEntityQuery.Where(predicate)
                    .ToListAsync())
                .MergeCache(_cachedActivities)
                .SingleOrDefault(a => predicate.Compile()(a));
        }

        public new async Task<Activity> FirstOrDefaultAsync(Expression<Func<Activity, bool>> predicate,
            Sort<Activity> sort = Sort<Activity>.Unsorted)
        {
            return (await SelectEntityQuery.Where(predicate).ToListAsync())
                .MergeCache(_cachedActivities)
                .FirstOrDefault(a => predicate.Compile()(a));
        }

        public new async Task<List<Activity>> FindAllAsync(Expression<Func<Activity, bool>> predicate,
            PageRequest pageRequest)
        {
            return (await SelectEntityQuery.Where(predicate)
                    .SortBy(pageRequest.SortBy)
                    .ToListAsync())
                .MergeCache(_cachedActivities)
                .Where(a => predicate.Compile()(a))
                .Skip(pageRequest.Page * pageRequest.Size)
                .Take(pageRequest.Size)
                .ToList();
        }


        public new async Task<Activity> FindByIdAsync(int id)
        {
            return await base.FindByIdAsync(id).MergeCacheAsync(_cachedActivities);
        }


        public new async Task<Activity> AddAsync(Activity entity)
        {
            var tmpHandleBy = entity.HandleByEmployeeCode;
            entity.HandleByEmployeeCode = await HandleByUserOrEmployee(entity);
            var o = await base.AddAsync(entity);
            if (o.HandleByEmployeeCode == 0) //return 0 if handle by user
                o.HandleByEmployeeCode = tmpHandleBy; //set to tha matching employee
            return o.MergeCache(_cachedActivities);
        }

        public new async Task<List<Activity>> AddAsync(List<Activity> entities)
        {
            var tmps = entities.Select(x => x.HandleByEmployeeCode);
            var o = await base.AddAsync(entities).MergeCacheAsync(_cachedActivities);
            return  o.Zip(tmps).Select(x =>
            {
                if (x.First.HandleByEmployeeCode == 0)
                    x.First.HandleByEmployeeCode = x.Second;
                return x.First;
            }).ToList();
        }


        public new async Task<Activity> UpdateAsync(Activity entity)
        {
            var tmpHandleBy = entity.HandleByEmployeeCode;
            entity.HandleByEmployeeCode = await HandleByUserOrEmployee(entity);
            var o = await base.UpdateAsync(entity);
            if (o.HandleByEmployeeCode == 0) //return 0 if handle by user
                o.HandleByEmployeeCode = tmpHandleBy; //set to tha matching employee
            return o.MergeCache(_cachedActivities);
        }

        public new   Task<List<Activity>> UpdateAsync(List<Activity> entities)
        {
            return Task.Run(() => entities.Select(x => UpdateAsync(x).Result).ToList());

        }


        private static readonly Expression<Func<OCLS, ActivitySubject>> AsActivitySubject =
            x => new ActivitySubject
            {
                Code = x.Code,
                Name = x.Name,
                IsActive = x.Active == "Y"
            };

        private static readonly Expression<Func<OCLT, ActivityType>> AsActivityType =
            x => new ActivityType
            {
                Code = x.Code,
                Name = x.Name,
                IsActive = x.Active == "Y"
            };

        private static readonly Expression<Func<ActContainer, Activity>> AsActivity =
            (x) => new Activity
            {
                Code = x.Oclg.ClgCode,
                BusinessPartnerCode = x.Oclg.CardCode,
                HandleByEmployeeCode = x.Ohem == null ? x.Oclg.AttendEmpl : x.Ohem.empID,
                // ReSharper disable once ConvertConditionalTernaryExpressionToSwitchExpression
                Action = x.Oclg.Action == "C" ? Activity.ActionType.PhoneCall :
                    x.Oclg.Action == "M" ? Activity.ActionType.Meeting :
                    x.Oclg.Action == "T" ? Activity.ActionType.Task :
                    x.Oclg.Action == "E" ? Activity.ActionType.Note :
                    x.Oclg.Action == "P" ? Activity.ActionType.Campaign : Activity.ActionType.Other,
                TypeCode = x.Oclg.CntctType.Value,
                SubjectCode = x.Oclg.CntctSbjct.Value == -1 ? null as int? : x.Oclg.CntctSbjct.Value,
                Details = x.Oclg.Details,
                Notes = x.Oclg.Notes,
                BeginDateTime = x.Oclg.BeginTime.HasValue && x.Oclg.Recontact.HasValue
                    ? x.Oclg.Recontact.Value
                        .AddMinutes(x.Oclg.BeginTime.Value % 100)
                        // ReSharper disable once PossibleLossOfFraction
                        .AddHours(x.Oclg.BeginTime.Value / 100)
                    : x.Oclg.Recontact.Value,

                DurationMinutes = x.Oclg.DurType == "D" ? Convert.ToInt32(x.Oclg.Duration.Value * 60 * 24) :
                    x.Oclg.DurType == "H" ? Convert.ToInt32(x.Oclg.Duration.Value * 60) :
                    Convert.ToInt32(x.Oclg.Duration.Value),

                CreationDateTime = x.Oclg.CntctTime.HasValue && x.Oclg.CntctDate.HasValue
                    ? x.Oclg.CntctDate.Value
                        .AddMinutes(x.Oclg.CntctTime.Value % 100)
                        // ReSharper disable once PossibleLossOfFraction
                        .AddHours(x.Oclg.CntctTime.Value / 100)
                    : x.Oclg.CntctDate,

                CloseDate = x.Oclg.CloseDate,
                IsClosed = x.Oclg.Closed == "Y",
                IsActive = x.Oclg.inactive == "N",
                Document = x.Oclg.DocEntry == null || Convert.ToInt64(x.Oclg.DocEntry) == 0
                    ? null
                    : new DocReferencedEntity
                    {
                        DocKey = Convert.ToInt64(x.Oclg.DocEntry),
                        // ReSharper disable once ConvertConditionalTernaryExpressionToSwitchExpression
                        DocType = x.Oclg.DocType == "13" ? DocType.Invoice :
                            x.Oclg.DocType == "17" ? DocType.Order :
                            x.Oclg.DocType == "23" ? DocType.Quotation :
                            x.Oclg.DocType == "14" ? DocType.CreditNote :
                            x.Oclg.DocType == "15" ? DocType.DeliveryNote :
                            x.Oclg.DocType == "203" ? DocType.DownPaymentRequest :
                            x.Oclg.DocType == "24" ? DocType.Receipt : DocType.Other
                    },
                LastModifiedDateTime = x.Oclg.CloseDate.HasValue ? x.Oclg.CloseDate.Value.AddDays(1) : new DateTime?(),
                BaseActivity = x.Oclg.prevActvty
            };

        private async Task<int?> HandleByUserOrEmployee(Activity activity)
        {
            if (!activity.HandleByEmployeeCode.HasValue) return activity.HandleByEmployeeCode;          
           
            // mark user id (and not emp id ) by a negative value
            var emp = await _context.OHEM.FirstAsync(x => x.empID == activity.HandleByEmployeeCode.Value);
            if (emp.userId.HasValue)
                return -emp.userId;

            return activity.HandleByEmployeeCode;
        }
    }

    internal static class ActivitiesExtenstion
    {
        public static List<Activity> MergeCache(this IEnumerable<Activity> activities,
            Dictionary<int, Activity> cachedActivities) => activities
            .Select(a => a.MergeCache(cachedActivities)).ToList();


        public static async Task<List<Activity>> MergeCacheAsync(this Task<List<Activity>> activities,
            Dictionary<int, Activity> cachedActivities) => (await activities).MergeCache(cachedActivities);

        public static async Task<Activity> MergeCacheAsync(this Task<Activity> a,
            Dictionary<int, Activity> cachedActivities) => (await a).MergeCache(cachedActivities);

        public static Activity MergeCache(this Activity a,
            Dictionary<int, Activity> cachedActivities)
        {
            Debug.Assert(a.Code != null, "a.Code != null");
            var cachedActivity = cachedActivities.GetValueOrDefault(a.Code.Value, null);
            if (cachedActivity == null)
            {
                //activity not present in cache => add it and return the activity
                a.LastModifiedDateTime = DateTime.Now;
                cachedActivities[a.Code.Value] = a.Clone() as Activity;
                return a;
            }

            cachedActivity = cachedActivity.Clone() as Activity; //clone to support multi-threading

            //last modified is the latest modified date time (from the original activity or the cached one) 
            DateTime? lastUpdate;
            Debug.Assert(cachedActivity != null, nameof(cachedActivity) + " != null");
            if (a.LastModifiedDateTime.HasValue && cachedActivity.LastModifiedDateTime.HasValue)
                lastUpdate = a.LastModifiedDateTime > cachedActivity.LastModifiedDateTime
                    ? a.LastModifiedDateTime
                    : cachedActivity.LastModifiedDateTime;
            else if (a.LastModifiedDateTime.HasValue && cachedActivity.LastModifiedDateTime.HasValue == false)
                lastUpdate = a.LastModifiedDateTime;
            else
                lastUpdate = cachedActivity.LastModifiedDateTime;
            lastUpdate ??= DateTime.Now;
            //check if the cached activity is equals to the original one
            //ignore the LastModifiedDateTime value
            a.LastModifiedDateTime = null;
            cachedActivity.LastModifiedDateTime = null;

            if (a.Equals(cachedActivity))
            {
                //if the cached activity is equals to the original one
                //return the original activity 
                //modify the appropriate lastUpdate
                a.LastModifiedDateTime = lastUpdate;
                return a;
            }

            //the cached activity is different from the original one
            //return the original activity 
            //modify the appropriate lastUpdate
            //update the cache activity
            a.LastModifiedDateTime = DateTime.Now;
            cachedActivities[a.Code.Value] = a.Clone() as Activity;
            return a;
        }
    }
}