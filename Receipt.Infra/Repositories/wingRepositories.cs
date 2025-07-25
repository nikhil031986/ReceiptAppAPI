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
    public class wingRepositories(AppDbContext dbContext) :IWingRepositories
    {
        public async Task<WingMaster> AddwingAsync(WingMaster wingMaster)
        {
            if (wingMaster != null)
            {
                await dbContext.DbwingMasters.AddAsync(wingMaster);
                await dbContext.SaveChangesAsync();
                foreach (WingDetail wd in wingMaster.WingDetails)
                {
                    wd.WingMasterId = wingMaster.WingMasterId;
                    await dbContext.wingDetails.AddAsync(wd);
                    //await dbContext.SaveChangesAsync();
                }
                return wingMaster;
            }
            return null;
        }
        public async Task<WingMaster> UpdatewingAsync(WingMaster wingMaster)
        {
            if (wingMaster != null)
            {
                var wing = await dbContext.DbwingMasters.
                    Where(x=> x.WingMasterId == wingMaster.WingMasterId).FirstOrDefaultAsync();
                if (wing != null)
                {
                    wing.DisplayName = wingMaster.DisplayName;
                    wing.FloarCount = wingMaster.FloarCount;
                    wing.HouseCount = wingMaster.HouseCount;
                    wing.StartNumber = wingMaster.StartNumber;
                    wing.EndNumber = wingMaster.EndNumber;
                    wing.SiteId = wingMaster.SiteId;
                    wing.CreateuserId = wingMaster.CreateuserId;
                    wing.CreatedAt = wingMaster.CreatedAt;
                    wing.UpdatedAt = wingMaster.UpdatedAt;
                    wing.IsActive = wingMaster.IsActive;
                    wingMaster.IsActive = wingMaster.IsActive; // Default to active if not set

                    dbContext.DbwingMasters.Update(wing);
                    foreach (WingDetail wd in wingMaster.WingDetails)
                    {
                        dbContext.wingDetails.Update(wd);
                    }
                    await dbContext.SaveChangesAsync();
                    return wingMaster;
                }
                return null;
            }
            return null;
        }
        public async Task<bool> DeletewingAsync(int wingMasterId)
        {
            var wing = await dbContext.DbwingMasters.FindAsync(wingMasterId);
            if(wing != null)
            {
                var wingDetails = await dbContext.wingDetails.Where(x => x.WingMasterId == wingMasterId).ToListAsync();
                if (wingDetails != null && wingDetails.Count > 0)
                {
                    dbContext.wingDetails.RemoveRange(wingDetails);
                }
                dbContext.DbwingMasters.Remove(wing);
                await dbContext.SaveChangesAsync();
                return true;
            }   
            return false;
        }
        public async Task<WingMaster> GetwingByIdAsync(int wingMasterId)
        {
            var wing = await dbContext.DbwingMasters
                .SingleOrDefaultAsync(x => x.WingMasterId == wingMasterId);
            if (wing != null)
            {
                wing.WingDetails = await dbContext.wingDetails.Where(x => x.WingMasterId == wing.WingMasterId).ToListAsync();
                return wing;
            }
            return null;
        }
        public async Task<IEnumerable<WingMaster>> GetAllwingAsync()
        {
            return await dbContext.DbwingMasters
                .Include(p=> p.WingDetails)
                .ToListAsync();
        }
        public async Task<bool> DeActivatewing(int wingMasterId)
        {
            var wing = await dbContext.DbwingMasters.FindAsync(wingMasterId);
            if(wing != null)
            {
                wing.IsActive = true; // Assuming IsActive is a property in WingMaster
                dbContext.DbwingMasters.Update(wing);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<WingDetail>> GetWingDetails(int wingMasterId)
        {
           return await dbContext.wingDetails
                .Include(wm=> wm.WingMaster)
                .Where(x => x.WingMasterId == wingMasterId)
                .ToListAsync();
        }
        public async Task<WingDetail> GetWingDetailsByIdAsync(int wigDetailId)
        {
            return await dbContext.wingDetails
                .Include(w => w.WingMaster)
                .SingleOrDefaultAsync(x => x.WingDetailId == wigDetailId);
        }
    }
}
