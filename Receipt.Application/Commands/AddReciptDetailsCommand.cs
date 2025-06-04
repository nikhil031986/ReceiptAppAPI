using MediatR;
using Receipt.Domain.Entity;
using Receipt.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Application.Commands
{
    public record AddReciptDetailsCommand(ReceiptDetail ReceiptDetail) : IRequest<ReceiptDetail>;

    internal class AddReciptDetailsCommandHandler(IReceiptRepositories receiptRepositories)
        : IRequestHandler<AddReciptDetailsCommand, ReceiptDetail>
    {
        public async Task<ReceiptDetail> Handle(AddReciptDetailsCommand request, CancellationToken cancellationToken)
        {
            return await receiptRepositories.AddReceipt(request.ReceiptDetail);
        }
    }

    public record UpdateReciptDetailsCommand(int ReceiptId, ReceiptDetail ReceiptDetail) : IRequest<ReceiptDetail>;
    internal class UpdateReciptDetailsCommandHandler(IReceiptRepositories receiptRepositories)
        : IRequestHandler<UpdateReciptDetailsCommand, ReceiptDetail>
    {
        public async Task<ReceiptDetail> Handle(UpdateReciptDetailsCommand request, CancellationToken cancellationToken)
        {
            return await receiptRepositories.UpdateReceipt(request.ReceiptId, request.ReceiptDetail);
        }
    }

    public record DeActiveReciptDetailsCommand(int ReceiptId) : IRequest<bool>;
    internal class DeActiveReciptDetailsCommandHandler(IReceiptRepositories receiptRepositories)
        : IRequestHandler<DeActiveReciptDetailsCommand, bool>
    {
        public async Task<bool> Handle(DeActiveReciptDetailsCommand request, CancellationToken cancellationToken)
        {
            return await receiptRepositories.DeActiveReceipt(request.ReceiptId);
        }
    }
}
