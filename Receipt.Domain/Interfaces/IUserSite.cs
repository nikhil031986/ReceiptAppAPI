using Receipt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Interfaces
{
    public interface IUserSite
    {
        Task<UserSite> AddUserSite(UserSite userSite);
        Task<UserSite> UpdateUserSite(UserSite userSite);
        Task<UserSite> DeleteUserSite(int userSiteId);
        Task<List<UserSite>> GetUserSite(int userId);
    }
}
