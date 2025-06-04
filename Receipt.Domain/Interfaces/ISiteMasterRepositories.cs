using Receipt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Interfaces
{
    public interface ISiteMasterRepositories
    {
        Task<IEnumerable<SiteMaster>> GetSiteMaster();
        Task<SiteMaster> GetSite(int siteId);
        Task<SiteMaster> AddSite(SiteMaster userMaster);
        Task<SiteMaster> Updatesite(int siteId, SiteMaster userMaster);
        Task<bool> DeActivesite(int siteId);
    }
}
