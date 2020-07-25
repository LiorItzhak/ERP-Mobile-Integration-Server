using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitsOfWorks;
using LogicLib.Services.Docs;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer;
using DataAccessLayer.Entities.Documents.Headers;

namespace LogicLib.Services.Impl.Docs
{
    public class DeliveryNotesService : DocumentService<DeliveryNoteEntity, DeliveryNoteHeaderEntity>, IDeliveryNotesService
    {
        public DeliveryNotesService(IDalService dalService) : base(dalService)
        {
        }

        protected override IDocumentRepository<DeliveryNoteEntity, DeliveryNoteHeaderEntity> GetRepository(IUnitOfWork transaction)
        {
            return transaction.DeliveryNotes;
        }
    }
}
