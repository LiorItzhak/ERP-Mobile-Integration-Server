using DataAccessLayer.Entities.Documents;
using DataAccessLayer.Repositories;
using DataAccessLayer.UnitsOfWorks;
using LogicLib.Services.Docs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataAccessLayer;
using DataAccessLayer.Entities.Documents.Headers;

namespace LogicLib.Services.Impl.Docs
{
    public class OrderService : DocumentService<OrderEntity, OrderHeaderEntity>, IOrderService
    {
        public OrderService(IDalService dalService) : base(dalService)
        {
        }

        public async Task<OrderEntity> CancelDocument(int key, CancellationToken cancellationToken)
        {
            using (var transaction = DalService.CreateUnitOfWork())
            {
                var doc = await transaction.Quotations.FindByIdAsync(key);


                var canceledDoc = await GetRepository(transaction).CancelAsync(key);
                cancellationToken.ThrowIfCancellationRequested();
                await transaction.CompleteAsync();
                return canceledDoc;
            }
        }

        public async Task<OrderEntity> CloseDocument(int key, CancellationToken cancellationToken)
        {
            using (var transaction = DalService.CreateUnitOfWork())
            {
                var doc = await transaction.Quotations.FindByIdAsync(key);


                var closedDoc = await GetRepository(transaction).CloseAsync(key);
                cancellationToken.ThrowIfCancellationRequested();
                await transaction.CompleteAsync();
                return closedDoc;
            }
        }

        protected override IDocumentRepository<OrderEntity, OrderHeaderEntity> GetRepository(IUnitOfWork transaction)
        {
            return transaction.Orders;
        }
    }
}
