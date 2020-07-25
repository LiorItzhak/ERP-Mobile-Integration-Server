using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Entities;

namespace LogicLib.Services
{
    public interface IAttachmentsService
    {
        Task<Attachment> GetByKeyAsync(int attachmentsCode, int num);
        
        Task<List<Attachment>> GetAttachments(int attachmentsCode,DateTime? createdAfterDate = null);

        Task<IEnumerable<Attachment>> CreateNewAttachments(IEnumerable<FileContainer> files, int? attachmentsCode = null,CancellationToken cancellationToken = default);

    }
}