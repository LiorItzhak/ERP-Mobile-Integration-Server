using System;
using System.Diagnostics;
using DataAccessLayer.Repositories;
using SAPbobsCOM;
using Attachment = DataAccessLayer.Entities.Attachment;

namespace DataAccessLayer.SAPHandler.DiApiHandler.SapDbSets
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class AttachmentDiSet : DiSet<Attachment, IAttachmentRepository.AttachmentKey>
    {
        public AttachmentDiSet(SapDiApiContext.CompanyContext context) : base(context)
        {
        }

        public override Attachment Add(Attachment entity)
        {
            var company = Context.ConnectCompany();
            var oAtt = company.GetBusinessObject(BoObjectTypes.oAttachments2) as Attachments2;
            Debug.Assert(oAtt != null, nameof(oAtt) + " != null");
            if (entity.AttachmentsCode.HasValue)
            {
                //add new line to existing entry
                if (!oAtt.GetByKey(entity.AttachmentsCode.Value))
                    throw new Exception(
                        $"Attachment entry {entity.AttachmentsCode} dont exist {company.GetLastErrorDescription()}");
            }
            oAtt.Lines.Add();
            oAtt = MapToSapObject(entity, oAtt);
            var err = entity.AttachmentsCode.HasValue switch
            {
                true => oAtt.Update(),
                false => oAtt.Add()
            };
            if (err != 0)
                throw new Exception($"cant add the attachment, error code {err} {company.GetLastErrorDescription()} ");

            var entry = entity.AttachmentsCode ?? int.Parse(company.GetNewObjectKey());
            oAtt.GetByKey(entry);
            var newLineNum = oAtt.Lines.Count;
            oAtt.Lines.SetCurrentLine(newLineNum - 1); //current lines start from 0
            var returnEntity = MapToEntityObject(oAtt);
            returnEntity.Num = newLineNum;
            returnEntity.AttachmentsCode = entry;
            return returnEntity;
        }

        public override Attachment Update(Attachment entity)
        {
            throw new System.NotImplementedException();
        }

        public override void Remove(IAttachmentRepository.AttachmentKey id)
        {
            throw new System.NotImplementedException();
        }

        private static Attachments2 MapToSapObject(Attachment entity, Attachments2 sapEntity)
        {
            sapEntity.Lines.FileName = entity.FileName;
            sapEntity.Lines.FileExtension = entity.Ext;
            sapEntity.Lines.SourcePath = entity.Path;
            sapEntity.Lines.Override = BoYesNoEnum.tYES;
            return sapEntity;
        }

        private static Attachment MapToEntityObject(IAttachments2 sapEntity) => new Attachment
        {
            FileName = sapEntity.Lines.FileName,
            Ext = sapEntity.Lines.FileExtension,
            Path = sapEntity.Lines.SourcePath,
            CreationDate = sapEntity.Lines.AttachmentDate
        };
    }
}