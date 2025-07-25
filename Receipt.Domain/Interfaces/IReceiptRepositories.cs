using Receipt.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Interfaces
{
    public interface IReceiptRepositories:ICommonFunction<ReceiptDetail>
    {
        Task<IEnumerable<ReceiptDetail>> GetReceipts();
        Task<ReceiptDetail> AddReceipt(ReceiptDetail receiptDetail);
        Task<ReceiptDetail> UpdateReceipt(int receiptId, ReceiptDetail receiptDetail);
        Task<IEnumerable<ReceiptDetail>> GetReceiptDetailsByCustomerId(int customerId);
    }
}
