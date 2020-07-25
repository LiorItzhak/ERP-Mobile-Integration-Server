using System;
using System.Diagnostics;
using DataAccessLayer.Entities.Documents;
using SAPbobsCOM;
using Activity = DataAccessLayer.Entities.BusinessPartners.Activity;

namespace DataAccessLayer.SAPHandler.DiApiHandler.SapDbSets
{
    public class ActivityDiSet : DiSet<Activity, int>
    {
        public ActivityDiSet(SapDiApiContext.CompanyContext context) : base(context)
        {
        }


        public override Activity Add(Activity entity)
        {
            var company = Context.ConnectCompany();
            var companySrv = company.GetCompanyService();
            var activitySrv = (ActivitiesService) companySrv.GetBusinessService(ServiceTypes.ActivitiesService);
            var vNewActivity =
                (SAPbobsCOM.Activity) activitySrv.GetDataInterface(ActivitiesServiceDataInterfaces.asActivity);
            // vNewActivity.SalesEmployee = 2;

            vNewActivity = MapToSapEntity(entity, vNewActivity);
            var actParams = activitySrv.AddActivity(vNewActivity);
            var r = MapToEntity(activitySrv.GetActivity(actParams));
            r.LastModifiedDateTime =r.CreationDateTime;
            return r;            
        }

        public override Activity Update(Activity entity)
        {
            var company = Context.ConnectCompany();
            var companySrv = company.GetCompanyService();
            var activitySrv = (ActivitiesService) companySrv.GetBusinessService(ServiceTypes.ActivitiesService);
            Debug.Assert(entity.Code != null, "entity.Code != null");
            var oParams =
                (ActivityParams) activitySrv.GetDataInterface(ActivitiesServiceDataInterfaces.asActivityParams);
            oParams.ActivityCode = entity.Code.Value;
            oParams = (ActivityParams) activitySrv.GetDataInterface(ActivitiesServiceDataInterfaces.asActivityParams);
            oParams.ActivityCode = entity.Code.Value;
            var activity = activitySrv.GetActivity(oParams);
            var vNewActivity = MapToSapEntity(entity, activity);
            activitySrv.UpdateActivity(vNewActivity);
            company.GetLastError(out var error, out var msg);
            if (error != 0)
                throw new Exception($"SAP-DI-API - Cant update a customer, error code = {error} - ${msg}");
            oParams = (ActivityParams) activitySrv.GetDataInterface(ActivitiesServiceDataInterfaces.asActivityParams);
            oParams.ActivityCode = entity.Code.Value;
            var r = MapToEntity(activitySrv.GetActivity(oParams));
            r.LastModifiedDateTime = DateTime.Now;
            return r;
        }

        public override void Remove(int id)
        {
            var company = Context.ConnectCompany();
            var companySrv = company.GetCompanyService();
            var activitySrv = (ActivitiesService) companySrv.GetBusinessService(ServiceTypes.ActivitiesService);
            var oParams =
                (ActivityParams) activitySrv.GetDataInterface(ActivitiesServiceDataInterfaces.asActivityParams);
            oParams.ActivityCode = id;
            activitySrv.DeleteActivity(oParams);
            company.GetLastError(out var error, out var msg);
            if (error != 0)
                throw new Exception($"SAP-DI-API - Cant update a customer, error code = {error} - ${msg}");
        }


        private static Activity MapToEntity(IActivity sapActivity)
        {
            var e = sapActivity.DocEntry;
            return new Activity
            {
                Code = sapActivity.ActivityCode,
                BusinessPartnerCode = sapActivity.CardCode,
                HandleByEmployeeCode = sapActivity.HandledByEmployee,
                Action = sapActivity.Activity switch
                {
                    BoActivities.cn_Conversation => Activity.ActionType.PhoneCall,
                    BoActivities.cn_Meeting => Activity.ActionType.Meeting,
                    BoActivities.cn_Note => Activity.ActionType.Note,
                    BoActivities.cn_Task => Activity.ActionType.Task,
                    BoActivities.cn_Campaign => Activity.ActionType.Campaign,
                    BoActivities.cn_Other => Activity.ActionType.Other,
                    _ => Activity.ActionType.Other
                },
                TypeCode = sapActivity.ActivityType,
                SubjectCode = sapActivity.Subject,
                Details = sapActivity.Details,
                Notes = sapActivity.Notes,
                BeginDateTime = sapActivity.StartDate.AddTicks(sapActivity.StartTime.TimeOfDay.Ticks),
                DurationMinutes = sapActivity.DurationType switch
                {
                    BoDurations.du_Days => Convert.ToInt32(sapActivity.Duration * 60 * 24),
                    BoDurations.du_Hours => Convert.ToInt32(sapActivity.Duration * 60),
                    _ => Convert.ToInt32(sapActivity.Duration)
                },
                CreationDateTime = sapActivity.ActivityDate.AddTicks(sapActivity.ActivityTime.TimeOfDay.Ticks),
                CloseDate = sapActivity.Closed == BoYesNoEnum.tYES? sapActivity.CloseDate : new DateTime?(),
                IsClosed = sapActivity.Closed == BoYesNoEnum.tYES,
                IsActive = sapActivity.Inactiveflag == BoYesNoEnum.tNO,
                BaseActivity = sapActivity.PreviousActivity == 0 ? new int?() : sapActivity.PreviousActivity,

                Document = string.IsNullOrEmpty(sapActivity.DocEntry)
                    ? null
                    : new DocReferencedEntity
                    {
                        DocKey = Convert.ToInt32(sapActivity.DocEntry),
                        DocType = sapActivity.DocType switch
                        {
                            "13" => DocType.Invoice,
                            "17" => DocType.Order,
                            "23" => DocType.Quotation,
                            "14" => DocType.CreditNote,
                            "15" => DocType.DeliveryNote,
                            "203" => DocType.DownPaymentRequest,
                            "24" => DocType.Receipt,
                            _ => DocType.Other
                        }
                    }
            };
        }

        private static SAPbobsCOM.Activity MapToSapEntity(Activity activity, SAPbobsCOM.Activity sapActivity)
        {
            sapActivity.CardCode = activity.BusinessPartnerCode;
            if (activity.HandleByEmployeeCode.HasValue)
                sapActivity.HandledByEmployee = activity.HandleByEmployeeCode.Value;
            sapActivity.Activity = activity.Action switch
            {
                Activity.ActionType.PhoneCall => BoActivities.cn_Conversation,
                Activity.ActionType.Meeting => BoActivities.cn_Meeting,
                Activity.ActionType.Note => BoActivities.cn_Note,
                Activity.ActionType.Task => BoActivities.cn_Task,
                Activity.ActionType.Campaign => BoActivities.cn_Campaign,
                Activity.ActionType.Other => BoActivities.cn_Other,
                _ => BoActivities.cn_Other
            };
            sapActivity.ActivityType = activity.TypeCode;
            sapActivity.Subject = activity.SubjectCode ?? -1;
            sapActivity.Details = activity.Details;
            sapActivity.Notes = activity.Notes;
            sapActivity.StartDate = activity.BeginDateTime.Date;
            sapActivity.StartTime = new DateTime(activity.BeginDateTime.TimeOfDay.Ticks);
            if (activity.DurationMinutes.HasValue)
            {
                sapActivity.Duration = activity.DurationMinutes.Value;
                sapActivity.DurationType = BoDurations.du_Minuts;
            }

            // sapActivity.ActivityDate = activity.CreationDateTime;
            // sapActivity.CloseDate = activity.CloseDate;
            sapActivity.Closed = activity.IsClosed ? BoYesNoEnum.tYES : BoYesNoEnum.tNO;
            sapActivity.Inactiveflag = activity.IsActive ? BoYesNoEnum.tNO : BoYesNoEnum.tYES;
            if (activity.BaseActivity.HasValue)
                sapActivity.PreviousActivity = activity.BaseActivity.Value;
            if (activity.Document != null)
            {
                sapActivity.DocEntry = activity.Document.DocKey.ToString();
                sapActivity.DocType = activity.Document.DocType switch
                {
                    DocType.Invoice => "13",
                    DocType.Order => "17",
                    DocType.Quotation => "23",
                    DocType.CreditNote => "14",
                    DocType.DeliveryNote => "15",
                    DocType.DownPaymentRequest => "203",
                    DocType.Receipt => "24",
                    DocType.Other => throw new Exception("can map document type (Other) to sap di api"),
                    _ => throw new Exception($"cant map document type to sap di api, type={activity.Document.DocType} ")
                };
            }

            return sapActivity;
        }
    }
}