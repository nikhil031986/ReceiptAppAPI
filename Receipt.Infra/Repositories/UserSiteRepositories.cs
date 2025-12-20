using Microsoft.EntityFrameworkCore;
using Receipt.Domain.Entity;
using Receipt.Domain.Interfaces;
using Receipt.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Infra.Repositories
{
    public class UserSiteRepositories(AppDbContext appDbContext) : IUserSite
    {
        public async Task<UserSite> AddUserSite(UserSite userSite)
        {
            appDbContext.userSites.Add(userSite);
            await appDbContext.SaveChangesAsync();
            return userSite;
        }

        public async Task<UserSite> UpdateUserSite(UserSite userSite)
        {
            var userSiteData = await appDbContext.userSites.SingleOrDefaultAsync(x => x.UserSiteId == userSite.UserSiteId);
            if (userSiteData is not null)
            {
                userSiteData.UserId = userSite.UserId;
                userSiteData.SiteId = userSite.SiteId;
                await appDbContext.SaveChangesAsync();
                return userSiteData;
            }
            return userSite;
        }

        public async Task<UserSite> DeleteUserSite(int userSiteId)
        {
            var userSiteData = await appDbContext.userSites.SingleOrDefaultAsync(x => x.UserSiteId == userSiteId);
            if (userSiteData is not null)
            {
                appDbContext.userSites.Remove(userSiteData);
                await appDbContext.SaveChangesAsync();
                return userSiteData;
            }
            return userSiteData;
        }

        public async Task<List<UserSite>> GetUserSite(int userId)
        {
            return await appDbContext.userSites
                        .Include(X=> X.Site)
                        .Where(x => x.UserId == userId && x.Site.IsActive == true).ToListAsync();
        }
    }
}
