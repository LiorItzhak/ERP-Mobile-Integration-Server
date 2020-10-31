using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace LogicLib.Services
{
    public interface IAttachmentsService
    {
        enum ObjectType
        {
            BusinessPartner,Invoice, Order, Quotation, CreditNote, DeliveryNote, DownPaymentRequest
        }
        Task<Attachment> GetByKeyAsync(int attachmentsCode, int num);
        
        Task<List<Attachment>> GetAttachments(int attachmentsCode,DateTime? createdAfterDate = null);
        
        Task<IEnumerable<Attachment>> SaveNewAttachments(
            ObjectType objectType, string objectKey,
            IEnumerable<FileContainer> files,CancellationToken cancellationToken = default);
        
        Task<IEnumerable<Attachment>> AddAttachments(
            int attachmentsCode,
            IEnumerable<FileContainer> files,CancellationToken cancellationToken = default);


    }
}