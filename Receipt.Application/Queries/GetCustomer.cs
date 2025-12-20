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
    public record GetCustomersCommand() : IRequest<IEnumerable<CustomerMaster>>;

    internal class GetCustomersCommandHandler(ICustomerRepositories customerRepositories)
        : IRequestHandler<GetCustomersCommand, IEnumerable<CustomerMaster>>
    {
        public async Task<IEnumerable<CustomerMaster>> Handle(GetCustomersCommand request, CancellationToken cancellationToken)
        {
            return await customerRepositories.GetDataFromDB();
        }
    }

    public record GetCustomerByIdCommand(int customerId):IRequest<CustomerMaster>;

    internal class GetCustomerByIdCommandHandler(ICustomerRepositories customerRepositories)
        :IRequestHandler<GetCustomerByIdCommand,CustomerMaster>
    {
        public async Task<CustomerMaster> Handle(GetCustomerByIdCommand request, CancellationToken cancellationToken)
        {
            var dbData = await customerRepositories.GetDataFromDB(x => x.CustomerMasterId == request.customerId);
            return dbData.FirstOrDefault();
        }
    }

    public record GetCustomerBySiteIdCommand(int SiteId) : IRequest<CustomerMaster>;

    internal class GetCustomerBySiteIdCommandHandler(ICustomerRepositories customerRepositories)
        : IRequestHandler<GetCustomerBySiteIdCommand, CustomerMaster>
    {
        public async Task<CustomerMaster> Handle(GetCustomerBySiteIdCommand request, CancellationToken cancellationToken)
        {
            var dbData = await customerRepositories.GetDataFromDB(x => x.SiteId == request.SiteId && x.Site.IsActive == true);
            return dbData.FirstOrDefault();
        }
    }

}
