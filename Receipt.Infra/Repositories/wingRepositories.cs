using Microsoft.EntityFrameworkCore;
using Receipt.Domain.Entity;
using Receipt.Domain.Interfaces;
using Receipt.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Infra.Repositories
{
    public class wingRepositories(AppDbContext dbContext) : IWingRepositories
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

        public async Task<IEnumerable<WingMaster>> GetDataFromDB(Expression<Func<WingMaster, bool>> expression = null)
        {
            if (expression == null)
            {
                return await dbContext.DbwingMasters
                    .Include(x => x.WingDetails)
                    .Include(x => x.Site)
                    .ToListAsync();
            }
            else
            {
                return await dbContext.DbwingMasters
                    .Include(x => x.WingDetails)
                    .Include(x => x.Site)
                    .Where(expression)
                    .ToListAsync();
            }
        }

        public async Task<WingMaster> UpdatewingAsync(WingMaster wingMaster)
        {
            if (wingMaster != null)
            {
                var wing = await dbContext.DbwingMasters.
                    Where(x => x.WingMasterId == wingMaster.WingMasterId).FirstOrDefaultAsync();
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
                        var getWingDetails = dbContext.wingDetails.Find(wd.WingDetailId);
                        if(getWingDetails != null)
                        {
                            getWingDetails.WingMasterId = wd.WingMasterId;
                            getWingDetails.FlatNo = wd.FlatNo;
                            getWingDetails.South = wd.South;
                            getWingDetails.Land = wd.Land;
                            getWingDetails.Wb = wd.Wb;
                            getWingDetails.Carpate = wd.Carpate;
                            getWingDetails.UpdateuserId = 1;
                            getWingDetails.UpdatedAt = DateTime.Now.ToString("dd/MM/yyyy");
                            getWingDetails.Amount = wd.Amount;
                            getWingDetails.East = wd.East;
                            getWingDetails.North = wd.North;
                            getWingDetails.OpenTarrace = wd.OpenTarrace;
                            getWingDetails.FlowrName = wd.FlowrName;
                            getWingDetails.Total = wd.Total;
                            getWingDetails.WingName = wd.WingName;
                            getWingDetails.SiteId = wd.SiteId;
                            dbContext.wingDetails.Update(getWingDetails);
                        }
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
            if (wing != null)
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
            return await dbContext.DbwingMasters
                .Include(p => p.Site)
                .Include(p => p.WingDetails.Where(x=> x.IsActive != false))
                .SingleOrDefaultAsync(x => x.WingMasterId == wingMasterId);
        }
        public async Task<IEnumerable<WingMaster>> GetAllwingAsync()
        {
            return await dbContext.DbwingMasters
                .Include(p => p.WingDetails)
                .Include(p => p.Site)
                .ToListAsync();
        }

        public async Task<bool> DeActivatewing(int wingMasterId)
        {
            var wing = await dbContext.DbwingMasters.FindAsync(wingMasterId);
            if (wing != null)
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
                 .Include(wm => wm.WingMaster)
                 .Where(x => x.WingMasterId == wingMasterId && x.IsActive != false)
                 .ToListAsync();
        }

        public async Task<WingDetail> GetWingDetailsByIdAsync(int wigDetailId)
        {
            return await dbContext.wingDetails
                .Include(w => w.WingMaster)
                .SingleOrDefaultAsync(x => x.WingDetailId == wigDetailId && x.IsActive != false);
        }

        public async Task<WingDetail> AddAndUpdateWingDetails(WingDetail wingDetail)
        {
            WingDetail? getwingDetails = dbContext.wingDetails.Find(wingDetail.WingDetailId);
            if(getwingDetails != null)
            {
                getwingDetails.FlatNo = wingDetail.FlatNo;
                getwingDetails.South = wingDetail.South;
                getwingDetails.Land = wingDetail.Land;
                getwingDetails.Wb = wingDetail.Wb;
                getwingDetails.Carpate = wingDetail.Carpate;
                getwingDetails.UpdateuserId = wingDetail.UpdateuserId;
                getwingDetails.UpdatedAt = DateTime.Now.ToString("dd/MM/yyyy");
                getwingDetails.Amount = wingDetail.Amount;
                getwingDetails.East = wingDetail.East;
                getwingDetails.North = wingDetail.North;
                getwingDetails.OpenTarrace = wingDetail.OpenTarrace;
                getwingDetails.FlowrName = wingDetail.FlowrName;
                getwingDetails.Total = wingDetail.Total;
                getwingDetails.WingName = wingDetail.WingName;
                getwingDetails.West = wingDetail.West;
                dbContext.wingDetails.Update(getwingDetails);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                getwingDetails = new WingDetail();
                getwingDetails.WingMasterId = wingDetail.WingMasterId;
                getwingDetails.FlatNo = wingDetail.FlatNo;
                getwingDetails.South = wingDetail.South;
                getwingDetails.Land = wingDetail.Land;
                getwingDetails.Wb = wingDetail.Wb;
                getwingDetails.Carpate = wingDetail.Carpate;
                getwingDetails.CreateuserId = 1;
                getwingDetails.CreatedAt = DateTime.Now.ToString("dd/MM/yyyy");
                getwingDetails.Amount = wingDetail.Amount;
                getwingDetails.East = wingDetail.East;
                getwingDetails.North = wingDetail.North;
                getwingDetails.OpenTarrace = wingDetail.OpenTarrace;
                getwingDetails.FlowrName = wingDetail.FlowrName;
                getwingDetails.Total = wingDetail.Total;
                getwingDetails.WingName = wingDetail.WingName;
                getwingDetails.SiteId = wingDetail.SiteId;
                getwingDetails.West = wingDetail.West;
                await dbContext.wingDetails.AddAsync(getwingDetails);
                await dbContext.SaveChangesAsync();
            }
            return getwingDetails;
        }

        public async Task<bool> DeleteWingDetail(int wingDetailId)
        {
            WingDetail? wingDetail = dbContext.wingDetails.SingleOrDefault(x => x.WingDetailId == wingDetailId);
            if (wingDetail != null)
            {
                wingDetail.IsActive = false;
                dbContext.wingDetails.Update(wingDetail);
                await dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
