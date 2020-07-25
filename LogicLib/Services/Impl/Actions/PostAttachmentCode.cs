using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrossLayersUtils;
using DataAccessLayer;
using DataAccessLayer.Repositories;

namespace LogicLib.Services.Impl.Actions
{
    [Action("PostAttachmentsCode")]
    public class PostAttachmentsCode : IActionService
    {
        private readonly IDalService _dalService;

        public PostAttachmentsCode(IDalService dalService)
        {
            _dalService = dalService;
        }


        private const string BusinessPartnerCodeKey = "BusinessPartnerCode";
        private const string AttachmentsCodeKey = "AttachmentsCode";

        public async Task<object> ExecuteAction(Dictionary<string, string> actionProps,
            CancellationToken cancellationToken = default)
        {
            var attachmentsCodeStr = actionProps.GetValueOrDefault(AttachmentsCodeKey, null) ??
                                  throw new IllegalArgumentException($"{AttachmentsCodeKey} property missing");
            if(! attachmentsCodeStr.All(char.IsDigit))
                throw new IllegalArgumentException($"{AttachmentsCodeKey} property must be a Int");
            var attachmentsCode = Convert.ToInt32(attachmentsCodeStr);
            var businessPartnerCode = actionProps.GetValueOrDefault(BusinessPartnerCodeKey, null) ??
                                      throw new IllegalArgumentException($" {BusinessPartnerCodeKey} property missing");

            using var uow = _dalService.CreateUnitOfWork();
            var att =await uow.Attachments.FirstOrDefaultAsync(x => x.AttachmentsCode == attachmentsCode);
            if(att == null) throw new IllegalArgumentException($"property {AttachmentsCodeKey} not valid");
            var bp = await uow.BusinessPartners.FindByIdAsync(businessPartnerCode);
            if (bp == null) throw new IllegalArgumentException($"property {BusinessPartnerCodeKey} not valid");
            bp.AttachmentsCode = attachmentsCode;
            await uow.BusinessPartners.UpdateAsync(bp);
            await uow.CompleteAsync(cancellationToken);
            return bp;
        }
    }
}