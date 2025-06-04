using Microsoft.EntityFrameworkCore;
using Receipt.Domain.Entity;
using Receipt.Domain.Interfaces;
using Receipt.Infra.Data;

namespace Receipt.Infra.Repositories
{
    public class ReceiptRepositories(AppDbContext appDbContext) : IReceiptRepositories
    {
        public async Task<IEnumerable<ReceiptDetail>> GetReceipts()
        {
            return await appDbContext.receiptDetails.Include(c => c.Customer).
                Include(w => w.WingMaster).
                Include(i => i.WingDetail).ToListAsync();
        }

        public async Task<ReceiptDetail> GetReceipt(int receiptId)
        {
            return await appDbContext.receiptDetails.Include(c => c.Customer).
                Include(w => w.WingMaster).
                Include(i => i.WingDetail).Where(x => x.ReceiptId == receiptId).FirstOrDefaultAsync();
        }

        public async Task<ReceiptDetail> AddReceipt(ReceiptDetail receiptDetail)
        {
            receiptDetail.UserId = 1;
            appDbContext.receiptDetails.Add(receiptDetail);
            await appDbContext.SaveChangesAsync();
            return receiptDetail;
        }

        public async Task<ReceiptDetail> UpdateReceipt(int receiptId, ReceiptDetail receiptDetail)
        {
            appDbContext.receiptDetails.Update(receiptDetail);
            return receiptDetail;
        }

        public async Task<bool> DeActiveReceipt(int receiptId)
        {
            var receiptData = await appDbContext.receiptDetails.Where(x => x.ReceiptId == receiptId).FirstOrDefaultAsync();
            if (receiptData != null)
            {
                receiptData.IsActive = new byte[1] { 1 };
                appDbContext.receiptDetails.Update(receiptData);
                return true;
            }
            return false;
        }
        public async Task<IEnumerable<ReceiptDetail>> GetReceiptDetailsByCustomerId(int customerId)
        {
            return await appDbContext.receiptDetails.Include(c => c.Customer).
                Include(w => w.WingMaster).
                Include(i => i.WingDetail).Where(x => x.CustomerId == customerId).ToListAsync();
        }
    }
}
