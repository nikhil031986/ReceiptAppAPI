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
                foreach (WingDetail wd in wingMaster.WingDetails)
                {
                    await dbContext.wingDetails.AddAsync(wd);
                }
                await dbContext.SaveChangesAsync();
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
                    dbContext.DbwingMasters.Update(wingMaster);
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
                wing.IsActive = new byte[] { 0 }; // Assuming IsActive is a property in WingMaster
                dbContext.DbwingMasters.Update(wing);
                await dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<WingDetail>> GetWingDetails(int wingMasterId)
        {
           return await dbContext.wingDetails
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
