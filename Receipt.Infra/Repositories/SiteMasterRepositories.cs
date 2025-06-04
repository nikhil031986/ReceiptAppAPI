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
    public class SiteMasterRepositories(AppDbContext appDbContext): ISiteMasterRepositories
    {
        public async Task<IEnumerable<SiteMaster>> GetSiteMaster()
        {
            return await appDbContext.siteMasters.ToListAsync();
        }

        public async Task<SiteMaster> GetSite(int siteId)
        {
            return await appDbContext.siteMasters.SingleOrDefaultAsync(x => x.SiteId==siteId);
        }

        public async Task<SiteMaster> AddSite(SiteMaster site)
        {
            site.UserId = 1;
            appDbContext.siteMasters.Add(site);
            await appDbContext.SaveChangesAsync();
            return site;
        }

        public async Task<SiteMaster> Updatesite(int siteId, SiteMaster site)
        {
            site.UserId = 1;
            var Updatesite = await appDbContext.siteMasters.SingleOrDefaultAsync(x => x.SiteId ==siteId);
            if (Updatesite is not null)
            {
                Updatesite.SiteName = site.SiteName;
                Updatesite.Address = site.Address;
                Updatesite.UserId = site.UserId;
                Updatesite.Display_Name = site.Display_Name;
                Updatesite.RegistrationDetails = site.RegistrationDetails;
                await appDbContext.SaveChangesAsync();
                return Updatesite;
            }
            return site;
        }

        public async Task<bool> DeActivesite(int siteId)
        {
            var selectSite = await appDbContext.siteMasters.SingleOrDefaultAsync(x => x.SiteId==siteId);
            if (selectSite is not null)
            {
                appDbContext.siteMasters.Remove(selectSite);
                await appDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
