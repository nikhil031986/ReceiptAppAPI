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
}
