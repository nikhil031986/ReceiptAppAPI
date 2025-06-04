using Receipt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Interfaces
{
    public interface IReceiptRepositories
    {
        Task<IEnumerable<ReceiptDetail>> GetReceipts();
        Task<ReceiptDetail> GetReceipt(int receiptId);
        Task<ReceiptDetail> AddReceipt(ReceiptDetail receiptDetail);
        Task<ReceiptDetail> UpdateReceipt(int receiptId, ReceiptDetail receiptDetail);
        Task<bool> DeActiveReceipt(int receiptId);
        Task<IEnumerable<ReceiptDetail>> GetReceiptDetailsByCustomerId(int customerId);
    }
}
