﻿using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities.Documents.Headers;
using DataAccessLayer.Entities.Documents.Items;

namespace DataAccessLayer.Entities.Documents
{
    public class InvoiceEntity : InvoiceHeaderEntity, IDocumentEntity
    {

        public List<DocItemEntity> Items { get; set; }
    }
}
