using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Entity
{
    public partial class WingDetail
    {
        public int WingDetailId { get; set; }

        public int? WingMasterId { get; set; }

        public string FlatNo { get; set; } = null!;

        public string WingName { get; set; } = null!;

        public double? Land { get; set; }

        public double? Carpate { get; set; }

        public double? Wb { get; set; }

        public double? Total { get; set; }

        public double? Amount { get; set; }

        public string? East { get; set; }

        public string? West { get; set; }

        public string? North { get; set; }

        public string? South { get; set; }

        public string? FlowrName { get; set; }

        public double? OpenTarrace { get; set; }

        public int SiteId { get; set; }

        public int UserId { get; set; }

        public string? EntryDate { get; set; }

        public string? UpdateDate { get; set; }

        public byte[] IsActive { get; set; } = null!;

        public virtual ICollection<CustomerMaster>? CustomerMasters { get; set; } = new List<CustomerMaster>();

        public virtual SiteMaster? Site { get; set; } = null!;

        public virtual UserMaster? User { get; set; } = null!;

        public virtual WingMaster? WingMaster { get; set; }
    }

}
