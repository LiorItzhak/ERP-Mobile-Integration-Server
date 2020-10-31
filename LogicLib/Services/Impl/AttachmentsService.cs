using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using CrossLayersUtils;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitsOfWorks;
using Microsoft.Extensions.Logging;

namespace LogicLib.Services.Impl
{
    public class AttachmentsService : IAttachmentsService
    {
        private readonly IDalService _dalService;
        private readonly ILogger<IAttachmentsService> _logger;
        private readonly IFileService _fileService;

        public AttachmentsService(IDalService dalService, ILogger<IAttachmentsService> logger, IFileService fileService)
        {
            _dalService = dalService;
            _logger = logger;
            _fileService = fileService;
        }

        public async Task<Attachment> GetByKeyAsync(int attachmentsCode, int num)
        {
            using var uow = _dalService.CreateUnitOfWork();
            return await uow.Attachments.FindByIdAsync(new IAttachmentRepository.AttachmentKey
                {Code = attachmentsCode, Num = num});
        }


        public async Task<List<Attachment>> GetAttachments(int attachmentsCode, DateTime? createdAfterDate = null)
        {
            using var uow = _dalService.CreateUnitOfWork();
            var r = await uow.Attachments.FindAllAsync(x => x.AttachmentsCode == attachmentsCode &&
                                                            (createdAfterDate.HasValue == false ||
                                                             x.CreationDate > createdAfterDate),
                PageRequest.Of(0, int.MaxValue));
            return r;
        }


        public async Task<IEnumerable<Attachment>> SaveNewAttachments(IAttachmentsService.ObjectType objectType,
            string objectKey,
            IEnumerable<FileContainer> files,
            CancellationToken cancellationToken = default)
        {
            using var uow = _dalService.CreateUnitOfWork();
            var objectAttachmentsCode = await GetAttachmentsCodeFromObjectAsync(objectType, objectKey, uow);

            // Save files
            var filesKeys = await _fileService.SaveFilesAsync(files, false, cancellationToken);
            var attachments = filesKeys.Select(fileKey => StringToAttachmentMapper(fileKey, objectAttachmentsCode))
                .ToList();

            // Add Attachments 
            if (objectAttachmentsCode.HasValue)
            {
                // Object already assigned with attachments code 
                attachments = await uow.Attachments.AddAsync(attachments);
            }
            else
            {
                // Object never assigned with attachments code - create new attachments code
                var firstAtt = await uow.Attachments.AddAsync(attachments.First());
                objectAttachmentsCode = firstAtt.AttachmentsCode;
                Debug.Assert(objectAttachmentsCode != null, nameof(objectAttachmentsCode) + " != null");

                attachments.ForEach(x => x.AttachmentsCode = objectAttachmentsCode);
                attachments = await uow.Attachments.AddAsync(attachments.Skip(1).ToList());
                attachments.Insert(0, firstAtt);

                // assign the attachments code with the object
                await AssignAttachmentsCodeWithObjectAsync(objectAttachmentsCode.Value, objectType, objectKey, uow);
            }

            await uow.CompleteAsync(cancellationToken);
            return attachments;
        }

        public async Task<IEnumerable<Attachment>> AddAttachments(int attachmentsCode, IEnumerable<FileContainer> files,
            CancellationToken cancellationToken = default)
        {
            using var uow = _dalService.CreateUnitOfWork();
            var filesKeys = await _fileService.SaveFilesAsync(files, false, cancellationToken);
            var attachments = filesKeys.Select(fileKey => StringToAttachmentMapper(fileKey, attachmentsCode)).ToList();
            attachments = await uow.Attachments.AddAsync(attachments);
            await uow.CompleteAsync(cancellationToken);
            return attachments;
        }

        private Attachment StringToAttachmentMapper(string fileKey, int? attachmentsCode) => new Attachment
        {
            AttachmentsCode = attachmentsCode,
            Path = Path.GetDirectoryName(_fileService.ResolveFullLocalPath(fileKey)),
            FileName = Path.GetFileNameWithoutExtension(fileKey),
            Ext = Path.GetExtension(fileKey).Replace(".", "") // remove "." (dot) prefix
        };

        private static async Task<int?> GetAttachmentsCodeFromObjectAsync(IAttachmentsService.ObjectType objectType,
            string objectKey, IReadOnlyUnitOfWork uow)
        {
            // Invoice, Order, Quotation, CreditNote, DeliveryNote, DownPaymentRequest
            switch (objectType)
            {
                case IAttachmentsService.ObjectType.BusinessPartner:
                    var bp = await uow.BusinessPartners.FindByIdAsync(objectKey) ??
                             throw new NotFoundException($"{objectType} key={objectKey} not found");
                    return bp.AttachmentsCode;
                case IAttachmentsService.ObjectType.Order:
                    var order = await uow.Orders.FindByIdAsync(Convert.ToInt32(objectKey)) ??
                                throw new NotFoundException($"{objectType} key={objectKey} not found");
                    return order.AttachmentsCode;
                case IAttachmentsService.ObjectType.Quotation:
                    var quo = await uow.Quotations.FindByIdAsync(Convert.ToInt32(objectKey)) ??
                              throw new NotFoundException($"{objectType} key={objectKey} not found");
                    return quo.AttachmentsCode;
                case IAttachmentsService.ObjectType.Invoice:
                    var inv = await uow.Invoices.FindByIdAsync(Convert.ToInt32(objectKey)) ??
                              throw new NotFoundException($"{objectType} key={objectKey} not found");
                    return inv.AttachmentsCode;
                case IAttachmentsService.ObjectType.CreditNote:
                    var cn = await uow.CreditNotes.FindByIdAsync(Convert.ToInt32(objectKey)) ??
                             throw new NotFoundException($"{objectType} key={objectKey} not found");
                    return cn.AttachmentsCode;
                case IAttachmentsService.ObjectType.DeliveryNote:
                    var dn = await uow.DeliveryNotes.FindByIdAsync(Convert.ToInt32(objectKey)) ??
                             throw new NotFoundException($"{objectType} key={objectKey} not found");
                    return dn.AttachmentsCode;
                case IAttachmentsService.ObjectType.DownPaymentRequest:
                    var dpr = await uow.DownPaymentRequests.FindByIdAsync(Convert.ToInt32(objectKey)) ??
                              throw new NotFoundException($"{objectType} key={objectKey} not found");
                    return dpr.AttachmentsCode;
                default:
                    throw new IllegalArgumentException($"Object type: {objectType} not supported");
            }
        }


        private static async Task AssignAttachmentsCodeWithObjectAsync(int objectAttachmentsCode,
            IAttachmentsService.ObjectType objectType,
            string objectKey, IUnitOfWork uow)
        {
            // TODO - UPDATE ONLY DOC HEADER
            switch (objectType)
            {
                case IAttachmentsService.ObjectType.BusinessPartner:
                    var bp = await uow.BusinessPartners.FindByIdAsync(objectKey);
                    bp.AttachmentsCode = objectAttachmentsCode;
                    await uow.BusinessPartners.UpdateAsync(bp);
                    break;
                case IAttachmentsService.ObjectType.Order:
                    var order = await uow.Orders.FindByIdWithItemsAsync(Convert.ToInt32(objectKey));
                    order.AttachmentsCode = objectAttachmentsCode;
                    order.Items = null;
                    await uow.Orders.UpdateAsync(order);
                    break;
                case IAttachmentsService.ObjectType.Quotation:
                    var quo = await uow.Quotations.FindByIdWithItemsAsync(Convert.ToInt32(objectKey));
                    quo.AttachmentsCode = objectAttachmentsCode;
                    quo.Items = null;
                    await uow.Quotations.UpdateAsync(quo);
                    break;
                case IAttachmentsService.ObjectType.Invoice:
                    var inv = await uow.Invoices.FindByIdWithItemsAsync(Convert.ToInt32(objectKey));
                    inv.AttachmentsCode = objectAttachmentsCode;
                    inv.Items = null;
                    await uow.Invoices.UpdateAsync(inv);
                    break;
                case IAttachmentsService.ObjectType.CreditNote:
                    var cn = await uow.CreditNotes.FindByIdWithItemsAsync(Convert.ToInt32(objectKey));
                    cn.AttachmentsCode = objectAttachmentsCode;
                    cn.Items = null;
                    await uow.CreditNotes.UpdateAsync(cn);
                    break;
                case IAttachmentsService.ObjectType.DeliveryNote:
                    var dn = await uow.DeliveryNotes.FindByIdWithItemsAsync(Convert.ToInt32(objectKey));
                    dn.AttachmentsCode = objectAttachmentsCode;
                    dn.Items = null;
                    await uow.DeliveryNotes.UpdateAsync(dn);
                    break;
                case IAttachmentsService.ObjectType.DownPaymentRequest:
                    var dpr = await uow.DownPaymentRequests.FindByIdWithItemsAsync(Convert.ToInt32(objectKey));
                    dpr.AttachmentsCode = objectAttachmentsCode;
                    dpr.Items = null;
                    await uow.DownPaymentRequests.UpdateAsync(dpr);
                    break;
                default:
                    throw new IllegalArgumentException($"Object type: {objectType} not supported");
            }
        }
    }
}