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
    public class CreditNotesService : DocumentService<CreditNoteEntity, CreditNoteHeaderEntity>, ICreditNotesService
    {
        public CreditNotesService(IDalService dalService) : base(dalService)
        {
        }

        protected override IDocumentRepository<CreditNoteEntity, CreditNoteHeaderEntity> GetRepository(IUnitOfWork transaction)
        {
            return transaction.CreditNotes;
        }
    }
}
