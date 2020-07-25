using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using DataAccessLayer.SAPHandler.DiApiHandler;
using DataAccessLayer.SAPHandler.DiApiHandler.SapDbSets;
using DataAccessLayer.SAPHandler.SqlHandler.DbContexts;
using DataAccessLayer.SAPHandler.SqlHandler.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories.Impls.SAP
{
    public class SapAttachmentRepository : SapWriteableRepository<Attachment, IAttachmentRepository.AttachmentKey>,
        IAttachmentRepository
    {
        public SapAttachmentRepository(SapSqlDbContext dbContext, SapDiApiContext diApiContext)
            : base(dbContext.ATC1.Select(AsAttachmentEntity),
                x => new IAttachmentRepository.AttachmentKey {Code = x.AttachmentsCode.Value, Num = x.Num.Value},
                diApiContext.Attachments)
        {
        }

        public new async Task<Attachment> FindByIdAsync(IAttachmentRepository.AttachmentKey id)
        {
            return await SelectEntityQuery
                .Where( x=>x.Num == id.Num && x.AttachmentsCode == id.Code)
                .SingleOrDefaultAsync();
        }
        
        


        private static readonly Expression<Func<ATC1, Attachment>> AsAttachmentEntity =
            x => new Attachment
            {
                AttachmentsCode = x.AbsEntry,
                Num = x.Line,
                Path = x.trgtPath,
                FileName = x.FileName,
                Ext = x.FileExt,
                CreationDate = x.Date.Value
            };
    }
}