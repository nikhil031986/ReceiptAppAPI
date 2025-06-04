using MediatR;
using Receipt.Domain.Entity;
using Receipt.Domain.Interfaces;

namespace Receipt.Application.Queries
{
    public record GetAllwingQueries() : IRequest<IEnumerable<WingMaster>>;

    internal class GetAllwingQueriesHandler(IWingRepositories wingRepositories)
        : IRequestHandler<GetAllwingQueries, IEnumerable<WingMaster>>
    {
        public async Task<IEnumerable<WingMaster>> Handle(GetAllwingQueries request, CancellationToken cancellationToken)
        {
            return await wingRepositories.GetAllwingAsync();
        }
    }

    public record GetwingByIdQueries(int wingId) : IRequest<WingMaster>;

    internal class GetwingByIdQueriesHandler(IWingRepositories wingRepositories)
        : IRequestHandler<GetwingByIdQueries, WingMaster>
    {
        public async Task<WingMaster> Handle(GetwingByIdQueries request, CancellationToken cancellationToken)
        {
            return await wingRepositories.GetwingByIdAsync(request.wingId);
        }
    }   
    
    public record GetWingDetailsQueries(int wingMasterId) : IRequest<IEnumerable<WingDetail>>;
    
    internal class GetWingDetailsQueriesHandler(IWingRepositories wingRepositories)
        : IRequestHandler<GetWingDetailsQueries, IEnumerable<WingDetail>>
    {
        public async Task<IEnumerable<WingDetail>> Handle(GetWingDetailsQueries request, CancellationToken cancellationToken)
        {
            return await wingRepositories.GetWingDetails(request.wingMasterId);
        }
    }

    public record GetWingDetailsByIdQueries(int wigDetailId) : IRequest<WingDetail>;    
    
    internal class GetWingDetailsByIdQueriesHandler(IWingRepositories wingRepositories)
        : IRequestHandler<GetWingDetailsByIdQueries, WingDetail>
    {
        public async Task<WingDetail> Handle(GetWingDetailsByIdQueries request, CancellationToken cancellationToken)
        {
            return await wingRepositories.GetWingDetailsByIdAsync(request.wigDetailId);
        }
    }
}
