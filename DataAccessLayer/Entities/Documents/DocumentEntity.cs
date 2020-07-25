using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities.Documents.Items;

namespace DataAccessLayer.Entities.Documents
{
    public interface IDocumentEntity
    {
        List<DocItemEntity> Items { get; set; }
    }
}
