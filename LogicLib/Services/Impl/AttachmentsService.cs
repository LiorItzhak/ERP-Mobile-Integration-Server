using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using CrossLayersUtils;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repositories;
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


        public async Task<IEnumerable<Attachment>> CreateNewAttachments(IEnumerable<FileContainer> files,
            int? attachmentsCode,
            CancellationToken cancellationToken = default)
        {
            using var uow = _dalService.CreateUnitOfWork();
            var filesKeys = await _fileService.SaveFilesAsync(files,false, cancellationToken);
            var attachments = filesKeys.Select(fileKey => new Attachment
            {
                AttachmentsCode = attachmentsCode,
                Path = Path.GetDirectoryName(_fileService.ResolveFullLocalPath(fileKey)),
                FileName = Path.GetFileNameWithoutExtension(fileKey),
                Ext = Path.GetExtension(fileKey)
            }).ToList();

            if (attachmentsCode.HasValue || attachments.Count == 1)
            {
                attachments = await uow.Attachments.AddAsync(attachments);
            }
            else
            {
                var firstAtt = await uow.Attachments.AddAsync(attachments.First());
                attachments.ForEach(x => x.AttachmentsCode = firstAtt.AttachmentsCode);
                attachments = await uow.Attachments.AddAsync(attachments.Skip(1).ToList());
                attachments.Insert(0, firstAtt);
            }

            await uow.CompleteAsync(cancellationToken);
            return attachments;
        }
        

        
        public async Task<IEnumerable<Attachment>> SaveNewAttachments(IAttachmentsService.ObjectType objectType,
            string objectKey,
            IEnumerable<FileContainer> files,
            CancellationToken cancellationToken = default)
        {
            using var uow = _dalService.CreateUnitOfWork();
            int? objectAttachmentsCode;
            switch (objectType)
            {
                case IAttachmentsService.ObjectType.BusinessPartner:
                    var bp = await uow.BusinessPartners.FindByIdAsync(objectKey) ??
                             throw new NotFoundException($"{objectType} key={objectKey} not found");
                    objectAttachmentsCode = bp.AttachmentsCode;
                    break;
                case IAttachmentsService.ObjectType.Order:
                    var order = await uow.Orders.FindByIdAsync(Convert.ToInt32(objectKey)) ??
                             throw new NotFoundException($"{objectType} key={objectKey} not found");
                    objectAttachmentsCode = order.AttachmentsCode;
                    break;
                case IAttachmentsService.ObjectType.Quotation:
                    var quo = await uow.Quotations.FindByIdAsync(Convert.ToInt32(objectKey)) ??
                              throw new NotFoundException($"{objectType} key={objectKey} not found");
                    objectAttachmentsCode = quo.AttachmentsCode;
                    break;
                default:
                    throw new IllegalArgumentException($"Object type: {objectType} not supported");
            }

            // Save files
            var filesKeys = await _fileService.SaveFilesAsync(files,false, cancellationToken);
            var attachments = filesKeys.Select(fileKey => new Attachment
            {
                AttachmentsCode = objectAttachmentsCode,
                Path = Path.GetDirectoryName(_fileService.ResolveFullLocalPath(fileKey)),
                FileName = Path.GetFileNameWithoutExtension(fileKey),
                Ext = Path.GetExtension(fileKey).Replace(".","") // remove "." (dot) prefix
            }).ToList();

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
                attachments.ForEach(x => x.AttachmentsCode = objectAttachmentsCode);
                attachments = await uow.Attachments.AddAsync(attachments.Skip(1).ToList());
                attachments.Insert(0, firstAtt);

                // assign the attachments code with the object
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
                        await uow.Orders.UpdateAsync(order);
                        break;
                    case IAttachmentsService.ObjectType.Quotation:
                        var quo = await uow.Quotations.FindByIdWithItemsAsync(Convert.ToInt32(objectKey));
                        quo.AttachmentsCode = objectAttachmentsCode;
                        await uow.Quotations.UpdateAsync(quo);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(objectType), objectType, null);
                }
            }

            await uow.CompleteAsync(cancellationToken);
            return attachments;
        }
    }
}