using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Entity
{
    public partial class ReceiptDetail:BaseEntity
    {
        [Key]
        public int ReceiptId { get; set; }

        public string? ReceiptNo { get; set; }

        public string? ReceiptDate { get; set; }

        public int CustomerId { get; set; }

        public int WingDetailId { get; set; }

        public int WingMasterId { get; set; }

        public string? CheqNeftRtgsNo { get; set; }

        public string? BankName { get; set; }

        public string? BranchName { get; set; }

        public string? ReceivedAs { get; set; }

        public double? Amount { get; set; }

        public string? AmountInWord { get; set; }

        public string? PaymentDate { get; set; }

        public bool? IsCancel { get; set; }

        public bool? IsPrint { get; set; }

        public int SiteId { get; set; }

        public virtual UserMaster? User { get; set; } = null!;

        public virtual CustomerMaster? Customer { get; set; } = null!;

        public virtual WingDetail? WingDetail { get; set; } = null!;
        
        public virtual WingMaster? WingMaster { get; set; } = null!;
    }

}
