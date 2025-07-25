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
    public record AddCustomerCommand(CustomerMaster Customer) : IRequest<CustomerMaster>;

    internal class AddCustomerCommandHandler(ICustomerRepositories customerRepositories)
        : IRequestHandler<AddCustomerCommand, CustomerMaster>
    {
        public async Task<CustomerMaster> Handle(AddCustomerCommand request, CancellationToken cancellationToken)
        {
            return await customerRepositories.AddCustomerAsync(request.Customer);
        }
    }

    public record UpdateCustomerCommand(CustomerMaster Customer) : IRequest<CustomerMaster>;

    internal class UpdateCustomerCommandHandler(ICustomerRepositories customerRepositories)
        : IRequestHandler<UpdateCustomerCommand, CustomerMaster>
    {
        public async Task<CustomerMaster> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            return await customerRepositories.UpdateCustomerAsync(request.Customer);
        }
    }

    public record DeActiveCustomerCommand(int customerId) : IRequest<bool>;

    internal class DeActiveCustomerCommandHandler(ICustomerRepositories customerRepositories)
        : IRequestHandler<DeActiveCustomerCommand, bool>
    {
        public async Task<bool> Handle(DeActiveCustomerCommand request, CancellationToken cancellationToken)
        {
            return await customerRepositories.DeActivate(request.customerId);
        }
    }

    public record DeleteCustomerCommand(int customerId) : IRequest<bool>;

    internal class DeleteCustomerCommandHandler(ICustomerRepositories customerRepositories)
        : IRequestHandler<DeleteCustomerCommand, bool>
    {
        public async Task<bool> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            return await customerRepositories.DeleteCustomerAsync(request.customerId);
        }
    }

}
