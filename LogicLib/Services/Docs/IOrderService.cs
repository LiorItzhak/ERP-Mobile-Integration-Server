using DataAccessLayer.Entities.Documents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer.Entities.Documents.Headers;

namespace LogicLib.Services.Docs
{
    public interface IOrderService : IDocumentService<OrderEntity, OrderHeaderEntity>
    {
        Task<OrderEntity> CancelDocument(int key, CancellationToken cancellationToken);
        Task<OrderEntity> CloseDocument(int key, CancellationToken cancellationToken);
    }
}
