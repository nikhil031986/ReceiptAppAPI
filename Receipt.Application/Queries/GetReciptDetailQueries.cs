using MediatR;
using Receipt.Domain.Entity;
using Receipt.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Application.Queries
{
    public record GetAllReceiptDetailsQueries() : IRequest<IEnumerable<ReceiptDetail>>;

    internal class GetAllReceiptDetailsQueriesHandler(IReceiptRepositories receiptRepositories)
        : IRequestHandler<GetAllReceiptDetailsQueries, IEnumerable<ReceiptDetail>>
    {
        public async Task<IEnumerable<ReceiptDetail>> Handle(GetAllReceiptDetailsQueries request, CancellationToken cancellationToken)
        {
            return await receiptRepositories.GetReceipts();
        }
    }

    public record GetReceiptDetailQueries(int receiptId) : IRequest<ReceiptDetail>;
    internal class GetReceiptDetailQueriesHandler(IReceiptRepositories receiptRepositories)
        : IRequestHandler<GetReceiptDetailQueries, ReceiptDetail>
    {
        public async Task<ReceiptDetail> Handle(GetReceiptDetailQueries request, CancellationToken cancellationToken)
        {
            return await receiptRepositories.GetReceipt(request.receiptId);
        }
    }

    public record GetReceiptDetailsByCustomerIdQueries(int customerId) : IRequest<IEnumerable<ReceiptDetail>>;  
    internal class GetReceiptDetailsByCustomerIdQueriesHandler(IReceiptRepositories receiptRepositories)
        : IRequestHandler<GetReceiptDetailsByCustomerIdQueries, IEnumerable<ReceiptDetail>>
    {
        public async Task<IEnumerable<ReceiptDetail>> Handle(GetReceiptDetailsByCustomerIdQueries request, CancellationToken cancellationToken)
        {
            return await receiptRepositories.GetReceiptDetailsByCustomerId(request.customerId);
        }
    }
}
