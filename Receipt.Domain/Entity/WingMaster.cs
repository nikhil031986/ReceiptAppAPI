using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Entity
{
    public partial class WingMaster:BaseEntity
    {
        [Key]
        public int WingMasterId { get; set; }

        public string DisplayName { get; set; } = null!;

        public int? FloarCount { get; set; }

        public int? HouseCount { get; set; }

        public int? StartNumber { get; set; }

        public int? EndNumber { get; set; }

        public int SiteId { get; set; }

        public virtual ICollection<CustomerMaster>? CustomerMasters { get; set; } = new List<CustomerMaster>();

        public virtual SiteMaster? Site { get; set; } = null!;

        public virtual UserMaster? User { get; set; } = null!;

        public virtual ICollection<WingDetail> WingDetails { get; set; } = new List<WingDetail>();

    }
}
