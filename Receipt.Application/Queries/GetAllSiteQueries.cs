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
    public record GetAllSiteQueries() : IRequest<IEnumerable<SiteMaster>>;

    internal class GetAllSiteQueriesHandler(ISiteMasterRepositories siteMasterRepositories)
        : IRequestHandler<GetAllSiteQueries, IEnumerable<SiteMaster>>
    {
        public async Task<IEnumerable<SiteMaster>> Handle(GetAllSiteQueries request, CancellationToken cancellationToken)
        {
            return await siteMasterRepositories.GetSiteMaster();
        }
    }

    public record GetSiteByIdQueries(int siteId) : IRequest<SiteMaster>;

    internal class GetSiteByIdQueriesHandler(ISiteMasterRepositories siteMasterRepositories)
        : IRequestHandler<GetSiteByIdQueries, SiteMaster>
    {
        public async Task<SiteMaster> Handle(GetSiteByIdQueries request, CancellationToken cancellationToken)
        {
            return await siteMasterRepositories.GetSite(request.siteId);
        }
    }
}
