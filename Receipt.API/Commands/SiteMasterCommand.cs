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
    public record AddSiteMasterCommand(SiteMaster siteMaster) : IRequest<SiteMaster>;

    internal class AddSiteMasterCommandHendler(ISiteMasterRepositories siteMasterRepositories)
        : IRequestHandler<AddSiteMasterCommand, SiteMaster>
    {
        public async Task<SiteMaster> Handle(AddSiteMasterCommand request, CancellationToken cancellationToken)
        {
            return await siteMasterRepositories.AddSite(request.siteMaster);
        }
    }

    public record UpdateSiteCommand(int siteId, SiteMaster siteMaster) : IRequest<SiteMaster>;

    internal class UpdateSiteCommandHandler(ISiteMasterRepositories siteMasterRepositories)
        : IRequestHandler<UpdateSiteCommand, SiteMaster>
    {
        public async Task<SiteMaster> Handle(UpdateSiteCommand request, CancellationToken cancellationToken)
        {
            return await siteMasterRepositories.Updatesite(request.siteId, request.siteMaster);
        }
    }

    public record DeActiveSiteCommand(int siteId) : IRequest<bool>;

    internal class DeActiveSiteCommandHandler(ISiteMasterRepositories siteMasterRepositories)
        : IRequestHandler<DeActiveSiteCommand, bool>
    {
        public async Task<bool> Handle(DeActiveSiteCommand request, CancellationToken cancellationToken)
        {
            return await siteMasterRepositories.DeActivesite(request.siteId);
        }
    }
}
