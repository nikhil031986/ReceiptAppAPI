using Receipt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Interfaces
{
    public interface IWingRepositories
    {
        Task<WingMaster> AddwingAsync(WingMaster wingMaster);
        Task<WingMaster> UpdatewingAsync(WingMaster wingMaster);
        Task<bool> DeletewingAsync(int wingMasterId);
        Task<WingMaster> GetwingByIdAsync(int wingMasterId);
        Task<IEnumerable<WingMaster>> GetAllwingAsync();
        Task<bool> DeActivatewing(int wingMasterId);
        Task<IEnumerable<WingDetail>> GetWingDetails(int wingMasterId);
        Task<WingDetail> GetWingDetailsByIdAsync(int wigDetailId);
    }
}
