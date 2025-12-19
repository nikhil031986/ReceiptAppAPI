using Receipt.Domain.Entity;

namespace Receipt.Domain.Interfaces
{
    public interface IUserMasterRepositories
    {

        Task<IEnumerable<UserMaster>> GetUserMasters();
        Task<UserMaster> GetUser(string emailId, string password);
        Task<UserMaster> AddUser(UserMaster userMaster);
        Task<UserMaster> UpdateUser(int userId, UserMaster userMaster);
        Task<bool> DeActiveUser(int userId); 
        Task<UserSite> AddUserSite(UserSite userSite);
        Task<UserSite> UpdateUserSite(UserSite userSite);
        Task<UserSite> DeleteUserSite(int userSiteId);
        Task<List<UserSite>> GetUserSite(int userId);

    }
}
