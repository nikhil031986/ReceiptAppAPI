using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Entity
{
    public partial class  CustomerMaster
    {
        [Key]
        public int CustomerMasterId { get; set; }

        public int WingMasterId { get; set; }

        public int WingDetailId { get; set; }

        public int SiteId { get; set; }

        public byte[]? IsBanakhat { get; set; }

        public string? BanakhatNumber { get; set; }

        public string? BanakhatDate { get; set; }

        public string? FinacialName { get; set; }

        public string? DastavgNo { get; set; }

        public string? DastavgDate { get; set; }

        public string? EntryDate { get; set; }

        public int? UpdateDate { get; set; }

        public int UserId { get; set; }

        public string? IsActive { get; set; }

        public virtual ICollection<CustomerDetail>? CustomerDetails { get; set; } = new List<CustomerDetail>();

        public virtual SiteMaster Site { get; set; } = null!;

        public virtual WingDetail WingDetail { get; set; } = null!;

        public virtual WingMaster WingMaster { get; set; } = null!;
    }
}
