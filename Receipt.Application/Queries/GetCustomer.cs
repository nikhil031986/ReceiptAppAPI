using MediatR;
using Receipt.Domain.Entity;
using Receipt.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
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
    public record GetCustomerByWingIdAndWingDetailIdCommand(int wingId,int wingDetailId):IRequest<IEnumerable<CustomerMaster>>;
    internal class GetCustomerByWingIdAndWingDetailIdCommandHandler(ICustomerRepositories customerRepositories)
        : IRequestHandler<GetCustomerByWingIdAndWingDetailIdCommand, IEnumerable<CustomerMaster>>
    {
        public async Task<IEnumerable<CustomerMaster>> Handle(GetCustomerByWingIdAndWingDetailIdCommand request, CancellationToken cancellationToken)
        {
            var dbData = await customerRepositories.GetDataFromDB(x => x.WingMasterId == request.wingId && x.WingDetailId == request.wingDetailId && x.IsActive == true);
            return dbData;
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

    public record GetCustomerBySiteIdCommand(int SiteId) : IRequest<IEnumerable<CustomerMaster>>;

    internal class GetCustomerBySiteIdCommandHandler(ICustomerRepositories customerRepositories)
        : IRequestHandler<GetCustomerBySiteIdCommand, IEnumerable<CustomerMaster>>
    {
        public async Task<IEnumerable<CustomerMaster>> Handle(GetCustomerBySiteIdCommand request, CancellationToken cancellationToken)
        {
            var dbData = await customerRepositories.GetDataFromDB(x => x.SiteId == request.SiteId && x.Site.IsActive == true);
            return dbData;
        }
    }

    public record GetCustomerDetailCommand(int customerDetailId):IRequest<CustomerDetail>;

    internal class GetCustomerDetailCommandHandler(ICustomerRepositories customerRepositories)
        : IRequestHandler<GetCustomerDetailCommand,CustomerDetail>
    {
        public async Task<CustomerDetail> Handle(GetCustomerDetailCommand request, CancellationToken cancellationToken)
        {
            return await customerRepositories.GetCustomerDetail(request.customerDetailId);
        }
    }

}
