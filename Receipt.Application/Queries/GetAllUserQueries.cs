using MediatR;
using Receipt.Domain.Entity;
using Receipt.Domain.Interfaces;

namespace Receipt.Application.Queries
{
    public record GetAllUserQueries() : IRequest<IEnumerable<UserMaster>>;

    internal class GetAllUserQueriesdHandler(IUserMasterRepositories userMasterRepositories)
        : IRequestHandler<GetAllUserQueries, IEnumerable<UserMaster>>
    {
        public async Task<IEnumerable<UserMaster>> Handle(GetAllUserQueries request, CancellationToken cancellationToken)
        {
            return await userMasterRepositories.GetUserMasters();
        }
    }

    public record GetLoginQueries(string emailId, string password) : IRequest<UserMaster>;

    internal class GetLoginQueriesHandler(IUserMasterRepositories userMasterRepositories)
        : IRequestHandler<GetLoginQueries, UserMaster>
    {
        public async Task<UserMaster> Handle(GetLoginQueries request, CancellationToken cancellationToken)
        {
            return await userMasterRepositories.GetUser(request.emailId,request.password);
        }
    }
}
