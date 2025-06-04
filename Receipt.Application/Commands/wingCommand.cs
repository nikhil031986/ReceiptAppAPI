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
    public record AddwingCommand(WingMaster WingMaster) : IRequest<WingMaster>;

    internal class AddwingCommandHandler(IWingRepositories wingRepositories)
        : IRequestHandler<AddwingCommand, WingMaster>
    {
        public async Task<WingMaster> Handle(AddwingCommand request, CancellationToken cancellationToken)
        {
            return await wingRepositories.AddwingAsync(request.WingMaster);
        }
    }

    public record UpdatewingCommand(WingMaster WingMaster) : IRequest<WingMaster>;

    internal class UpdatewingCommandHandler(IWingRepositories wingRepositories)
        : IRequestHandler<UpdatewingCommand, WingMaster>
    {
        public async Task<WingMaster> Handle(UpdatewingCommand request, CancellationToken cancellationToken)
        {
            return await wingRepositories.UpdatewingAsync(request.WingMaster);
        }
    }
    
    public record DeActivewingCommand(int wingMasterId) : IRequest<bool>;
    
    internal class DeActivewingCommandHandler(IWingRepositories wingRepositories)
        : IRequestHandler<DeActivewingCommand, bool>
    {
        public async Task<bool> Handle(DeActivewingCommand request, CancellationToken cancellationToken)
        {
            return await wingRepositories.DeActivatewing(request.wingMasterId);
        }
    }

    public record DeletewingCommand(int wingMasterId) : IRequest<bool>;
    internal class DeletewingCommandHandler(IWingRepositories wingRepositories)
        : IRequestHandler<DeletewingCommand, bool>
    {
        public async Task<bool> Handle(DeletewingCommand request, CancellationToken cancellationToken)
        {
            return await wingRepositories.DeletewingAsync(request.wingMasterId);
        }
    }

}
