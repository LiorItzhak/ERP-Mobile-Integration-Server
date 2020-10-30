using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using CrossLayersUtils;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.UnitsOfWorks;

namespace LogicLib.Services.Impl.Actions
{
    [Action("PostAttachmentsCode")]
    // ReSharper disable once UnusedType.Global
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
            if (!attachmentsCodeStr.All(char.IsDigit))
                throw new IllegalArgumentException($"{AttachmentsCodeKey} property must be a Int");
            var attachmentsCode = Convert.ToInt32(attachmentsCodeStr);

            using var uow = _dalService.CreateUnitOfWork();

            var attachment = await uow.Attachments
                                 .FirstOrDefaultAsync(x => x.AttachmentsCode == attachmentsCode) ??
                             throw new IllegalArgumentException($"property {AttachmentsCodeKey} not valid");

            var businessPartnerCode = actionProps.GetValueOrDefault(BusinessPartnerCodeKey, null);
            if (businessPartnerCode == null)
                throw new IllegalArgumentException($"property {BusinessPartnerCodeKey} not valid");
            var output = await AssignAttachmentToBusinessPartner(businessPartnerCode, attachment, uow);
            await uow.CompleteAsync(cancellationToken);
            return output;
        }
        
        private static async Task<object> AssignAttachmentToBusinessPartner(string businessPartnerKey,
            Attachment attachment, IUnitOfWork uow)
        {
            var bp = await uow.BusinessPartners.FindByIdAsync(businessPartnerKey) ??
                     throw new IllegalArgumentException($"property BusinessPartnerKey={businessPartnerKey} not valid");
            bp.AttachmentsCode = attachment.AttachmentsCode;
            await uow.BusinessPartners.UpdateAsync(bp);
            return bp;
        }

    }
}