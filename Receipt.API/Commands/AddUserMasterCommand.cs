using MediatR;
using Receipt.Domain.Entity;
using Receipt.Domain.Interfaces;

namespace Receipt.Application.Commands
{
    public record AddUserMasterCommand(UserMaster userMaster) : IRequest<UserMaster>;

    internal class AddUserMasterCommandHandler(IUserMasterRepositories userMasterRepositories)
        : IRequestHandler<AddUserMasterCommand, UserMaster>
    {
        public async Task<UserMaster> Handle(AddUserMasterCommand request, CancellationToken cancellationToken)
        {
            return await userMasterRepositories.AddUser(request.userMaster);
        }
    }

    public record UpdateUserCommand(int userId,UserMaster userMaster) : IRequest<UserMaster>;

    internal class UpdateUserCommandHandler(IUserMasterRepositories userMasterRepositories)
        : IRequestHandler<UpdateUserCommand, UserMaster>
    {
        public async Task<UserMaster> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await userMasterRepositories.UpdateUser(request.userId,request.userMaster);
        }
    }

    public record DeActiveUserCommand(int userId) : IRequest<bool>;

    internal class DeActiveUserCommandHandler(IUserMasterRepositories userMasterRepositories)
        : IRequestHandler<DeActiveUserCommand, bool>
    {
        public async Task<bool> Handle(DeActiveUserCommand request, CancellationToken cancellationToken)
        {
            return await userMasterRepositories.DeActiveUser(request.userId);
        }
    }

    public record AddUserSiteCommand(UserSite userSite) : IRequest<UserSite>;
    internal class AddUserSiteCommandHandler(IUserMasterRepositories userMasterRepositories)
        : IRequestHandler<AddUserSiteCommand, UserSite>
    {
        public async Task<UserSite> Handle(AddUserSiteCommand request, CancellationToken cancellationToken)
        {
            return await userMasterRepositories.AddUserSite(request.userSite);
        }
    }

    public record UpdateUserSiteCommand(UserSite userSite) : IRequest<UserSite>;
    internal class UpdateUserSiteCommandHandler(IUserMasterRepositories userMasterRepositories)
        : IRequestHandler<UpdateUserSiteCommand, UserSite>
    {
        public async Task<UserSite> Handle(UpdateUserSiteCommand request, CancellationToken cancellationToken)
        {
            return await userMasterRepositories.UpdateUserSite(request.userSite);
        }
    }

    public record DeleteUserSiteCommand(int userSiteId) : IRequest<UserSite>;
    internal class DeleteUserSiteCommandHandler(IUserMasterRepositories userMasterRepositories)
        : IRequestHandler<DeleteUserSiteCommand, UserSite>
    {
        public async Task<UserSite> Handle(DeleteUserSiteCommand request, CancellationToken cancellationToken)
        {
            return await userMasterRepositories.DeleteUserSite(request.userSiteId);
        }
    }

    public record GetUserSiteCommand(int userId) : IRequest<List<UserSite>>;
    internal class GetUserSiteCommandHandler(IUserMasterRepositories userMasterRepositories)
        : IRequestHandler<GetUserSiteCommand, List<UserSite>>
    {
        public async Task<List<UserSite>> Handle(GetUserSiteCommand request, CancellationToken cancellationToken)
        {
            return await userMasterRepositories.GetUserSite(request.userId);
        }
    }
}
