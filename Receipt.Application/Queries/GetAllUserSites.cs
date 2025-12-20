using MediatR;
using Receipt.Domain.Entity;
using Receipt.Domain.Interfaces;

namespace Receipt.Application.Queries
{
    public record AddUserSiteCommand(UserSite userSite) : IRequest<UserSite>;
    internal class AddUserSiteCommandHandler(IUserSite userSite)
        : IRequestHandler<AddUserSiteCommand, UserSite>
    {
        public async Task<UserSite> Handle(AddUserSiteCommand request, CancellationToken cancellationToken)
        {
            return await userSite.AddUserSite(request.userSite);
        }
    }

    public record UpdateUserSiteCommand(UserSite userSite) : IRequest<UserSite>;
    internal class UpdateUserSiteCommandHandler(IUserSite userSite)
        : IRequestHandler<UpdateUserSiteCommand, UserSite>
    {
        public async Task<UserSite> Handle(UpdateUserSiteCommand request, CancellationToken cancellationToken)
        {
            return await userSite.UpdateUserSite(request.userSite);
        }
    }

    public record DeleteUserSiteCommand(int userSiteId) : IRequest<UserSite>;
    internal class DeleteUserSiteCommandHandler(IUserSite userSite)
        : IRequestHandler<DeleteUserSiteCommand, UserSite>
    {
        public async Task<UserSite> Handle(DeleteUserSiteCommand request, CancellationToken cancellationToken)
        {
            return await userSite.DeleteUserSite(request.userSiteId);
        }
    }

    public record GetUserSiteCommand(int userId) : IRequest<List<UserSite>>;
    internal class GetUserSiteCommandHandler(IUserSite userSite)
        : IRequestHandler<GetUserSiteCommand, List<UserSite>>
    {
        public async Task<List<UserSite>> Handle(GetUserSiteCommand request, CancellationToken cancellationToken)
        {
            return await userSite.GetUserSite(request.userId);
        }
    }
}
