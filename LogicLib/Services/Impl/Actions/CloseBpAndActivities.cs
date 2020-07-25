using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrossLayersUtils;
using DataAccessLayer;
using DataAccessLayer.Repositories;
// ReSharper disable UnusedType.Global

namespace LogicLib.Services.Impl.Actions
{
    [Action("CloseBpAndActivities")]
    public class CloseBpAndActivities : IActionService
    {
        private readonly IDalService _dalService;

        public CloseBpAndActivities(IDalService dalService)
        {
            _dalService = dalService;
        }



        public async Task<object> ExecuteAction(Dictionary<string, string> actionProps, CancellationToken cancellationToken = default)
        {
            var businessPartnerCode = actionProps.GetValueOrDefault("BusinessPartnerCode", null) ??
                                      throw new IllegalArgumentException("BusinessPartnerCode property missing");

            using var uow = _dalService.CreateUnitOfWork();
            var bp = await uow.BusinessPartners.FindByIdAsync(businessPartnerCode);
            if (bp == null) throw new IllegalArgumentException("property BusinessPartnerCode not valid");
            bp.IsActive = false;
            var activities = (await uow.Activities.FindAllAsync(
                    x => x.IsClosed == false && x.BusinessPartnerCode == businessPartnerCode,
                    PageRequest.Of(0, int.MaxValue)))
                .Select(x =>
                {
                    x.IsClosed = true;
                    return x;
                }).ToList();
            if(activities.Count >0)
                await uow.Activities.UpdateAsync(activities);
            await uow.BusinessPartners.UpdateAsync(bp);
            await uow.CompleteAsync(cancellationToken);
            return bp;
                
        }
    }
}