using System;

namespace DataAccessLayer.Entities.Documents.Headers
{
    public class QuotationHeaderEntity : DocumentHeaderEntity
    {
        public DateTime? ValidUntil { get; set; }

    }
}
