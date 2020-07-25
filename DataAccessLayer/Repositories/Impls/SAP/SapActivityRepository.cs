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
                var uncanged = 0;
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
                        uncanged++;
                }

                if (uncanged != cachedActivitiesValues.Count)
                    extraDbContext.SaveChanges();
            });
        }

        private static IQueryable<Activity> SelectActivitiesFromDb(SapSqlDbContext dbContext) =>
            dbContext.OCLG.Select(AsActivity);


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
            return await base.AddAsync(entity).MergeCacheAsync(_cachedActivities);
        }

        public new async Task<List<Activity>> AddAsync(List<Activity> entities)
        {
            return await base.AddAsync(entities).MergeCacheAsync(_cachedActivities);
        }

        public new async Task<Activity> UpdateAsync(Activity entity)
        {
            return await base.UpdateAsync(entity).MergeCacheAsync(_cachedActivities);
        }

        public new async Task<List<Activity>> UpdateAsync(List<Activity> entities)
        {
            return await base.UpdateAsync(entities).MergeCacheAsync(_cachedActivities);
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

        private static readonly Expression<Func<OCLG, Activity>> AsActivity =
            x => new Activity
            {
                Code = x.ClgCode,
                BusinessPartnerCode = x.CardCode,
                HandleByEmployeeCode = x.AttendEmpl,
                // ReSharper disable once ConvertConditionalTernaryExpressionToSwitchExpression
                Action = x.Action == "C" ? Activity.ActionType.PhoneCall :
                    x.Action == "M" ? Activity.ActionType.Meeting :
                    x.Action == "T" ? Activity.ActionType.Task :
                    x.Action == "E" ? Activity.ActionType.Note :
                    x.Action == "P" ? Activity.ActionType.Campaign : Activity.ActionType.Other,
                TypeCode = x.CntctType.Value,
                SubjectCode = x.CntctSbjct.Value == -1 ? null as int? : x.CntctSbjct.Value,
                Details = x.Details,
                Notes = x.Notes,
                BeginDateTime = x.BeginTime.HasValue && x.Recontact.HasValue
                    ? x.Recontact.Value
                        .AddMinutes(x.BeginTime.Value % 100)
                        // ReSharper disable once PossibleLossOfFraction
                        .AddHours(x.BeginTime.Value / 100)
                    : x.Recontact.Value,

                DurationMinutes = x.DurType == "D" ? Convert.ToInt32(x.Duration.Value * 60 * 24) :
                    x.DurType == "H" ? Convert.ToInt32(x.Duration.Value * 60) : Convert.ToInt32(x.Duration.Value),

                CreationDateTime = x.CntctTime.HasValue && x.CntctDate.HasValue
                    ? x.CntctDate.Value
                        .AddMinutes(x.CntctTime.Value % 100)
                        // ReSharper disable once PossibleLossOfFraction
                        .AddHours(x.CntctTime.Value / 100)
                    : x.CntctDate,

                CloseDate = x.CloseDate,
                IsClosed = x.Closed == "Y",
                IsActive = x.inactive == "N",
                Document = x.DocEntry == null || Convert.ToInt64(x.DocEntry) == 0
                    ? null
                    : new DocReferencedEntity
                    {
                        DocKey = Convert.ToInt64(x.DocEntry),
                        // ReSharper disable once ConvertConditionalTernaryExpressionToSwitchExpression
                        DocType = x.DocType == "13" ? DocType.Invoice :
                            x.DocType == "17" ? DocType.Order :
                            x.DocType == "23" ? DocType.Quotation :
                            x.DocType == "14" ? DocType.CreditNote :
                            x.DocType == "15" ? DocType.DeliveryNote :
                            x.DocType == "203" ? DocType.DownPaymentRequest :
                            x.DocType == "24" ? DocType.Receipt : DocType.Other
                    },
                LastModifiedDateTime = x.CloseDate.HasValue ? x.CloseDate.Value.AddDays(1) : new DateTime?(),
                BaseActivity = x.prevActvty
            };
    }

    internal static class ActivitiesExtenstion
    {
        public static IEnumerable<Activity> MergeCache(this IEnumerable<Activity> activities,
            Dictionary<int, Activity> cachedActivities) => activities
            .Select(a => a.MergeCache(cachedActivities));


        public static async Task<List<Activity>> MergeCacheAsync(this Task<List<Activity>> activities,
            Dictionary<int, Activity> cachedActivities) => (await activities).MergeCache(cachedActivities).ToList();

        public static async Task<Activity> MergeCacheAsync(this Task<Activity> a,
            Dictionary<int, Activity> cachedActivities) => (await a).MergeCache(cachedActivities);

        private static Activity MergeCache(this Activity a,
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