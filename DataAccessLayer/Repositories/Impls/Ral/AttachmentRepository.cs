using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Impls.Ral
{
    public class AttachmentRepository :WriteableRepository<Attachment,IAttachmentRepository.AttachmentKey>,IAttachmentRepository
    {
        public AttachmentRepository(RalDbContext dbContext) : base(dbContext.Attachments)
        {
        }
    }
}