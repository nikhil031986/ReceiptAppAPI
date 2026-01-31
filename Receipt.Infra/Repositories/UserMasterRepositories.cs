using Microsoft.EntityFrameworkCore;
using Receipt.Domain.Entity;
using Receipt.Domain.Interfaces;
using Receipt.Infra.CommonFunction;
using Receipt.Infra.Data;

namespace Receipt.Infra.Repositories
{
    public class UserMasterRepositories (AppDbContext appDbContext) : IUserMasterRepositories
    {
        public async Task<IEnumerable<UserMaster>> GetUserMasters()
        {
            return await appDbContext.userMasters.Where(x=> x.IsActive != null && x.IsActive == true).ToListAsync();
        }

        public async Task<UserMaster> GetUser(string emailId,string password)
        {
            return await appDbContext.userMasters.SingleOrDefaultAsync(x => x.EmailId.Equals(emailId)
                                    && x.Password.Equals(password) && x.IsActive==true);
        }

        public async Task<UserMaster> GetUserById(int userId)
        {
            return await appDbContext.userMasters
                   .Include(x=> x.usersSite)
                        .ThenInclude(x=> x.Site)
                .SingleOrDefaultAsync(x => x.UserId== userId && x.IsActive==true);
        }
        public async Task<UserMaster> AddUser(UserMaster userMaster)
        {
            userMaster.CreateuserId = 1;
            userMaster.CreatedAt = DateTime.Now.ToString("dd/MM/yyyy");
            userMaster.Password = await PropertyUpdater.GeneratePassword(8);
            appDbContext.userMasters.Add(userMaster);
            await appDbContext.SaveChangesAsync();
            if(userMaster.usersSite is null || !userMaster.usersSite.Any())
            {
                var userSite = new UserSite
                {
                    UserId=userMaster.UserId,
                    SiteId = 1,
                    IsDefault = true,
                    CreateuserId = userMaster.CreateuserId,
                    CreatedAt = userMaster.CreatedAt
                };
                appDbContext.userSites.Add(userSite);
                await appDbContext.SaveChangesAsync();
            }
            return userMaster;
        }
        
        public async Task<IEnumerable<UserMaster>> GetUserBySiteId(int siteId)
        {
            //var userSites = await appDbContext.userSites
            //                    .Where(us => us.SiteId == siteId && us.IsActive == true)
            //                    .ToListAsync();
            //var userIds = userSites.Select(us => us.UserId).Distinct().ToList();
            var users = await appDbContext.userMasters
                                .Include(x=> x.usersSite.Where(m=> m.IsActive==true))
                                .Include(x=> x.siteMasters)
                                .Where(um => um.IsActive == true)
                                .ToListAsync();
            return users;
        }

        public async Task<UserMaster> UpdateUser(int userId,UserMaster userMaster)
        {
            var user = await appDbContext.userMasters.SingleOrDefaultAsync(x => x.UserId==userId && x.IsActive==true);
            if(user is not null)
            {
                user.UserName = userMaster.UserName;
                user.First_Name = userMaster.First_Name;
                user.Last_Name = userMaster.Last_Name;
                user.Address = userMaster.Address;
                user.EmailId = userMaster.EmailId;
                user.CreatedAt = DateTime.Now.Date.ToString("dd/MMM/yyyy");
                user.IsActive = userMaster.IsActive;
                user.IsAdmin = userMaster.IsAdmin;
                await appDbContext.SaveChangesAsync();
                return user;
            }
            return userMaster;
        }

        public async Task<bool> DeActiveUser(int userId)
        {
            var user = await appDbContext.userMasters.SingleOrDefaultAsync(x=> x.UserId== userId && x.IsActive == true);
            if(user is not null)
            {
                user.IsActive = false;
                await appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

    }
}
