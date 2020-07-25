using System.Collections.Generic;
using DataAccessLayer.Entities.Documents.Headers;
using DataAccessLayer.Entities.Documents.Items;

namespace DataAccessLayer.Entities.Documents
{
    public class QuotationEntity : QuotationHeaderEntity,IDocumentEntity
    {

        public List<DocItemEntity> Items { get; set; }
    }
}
