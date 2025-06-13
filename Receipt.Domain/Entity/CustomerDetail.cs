using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Entity
{
    public partial class CustomerDetail
    {
        [Key]
        public int CustomerDetailsId { get; set; }

        public int CustomerId { get; set; }

        public string? CustomerName { get; set; }

        public string? Address { get; set; }

        public string? ContDetails { get; set; }

        public string? PanNumber { get; set; }

        public string? AadharNumber { get; set; }

        public string? Religin { get; set; }

        public string? Ocupation { get; set; }

        public string? ContactNumber { get; set; }

        public string? EmaiId { get; set; }

        public byte[]? IsMain { get; set; }

        public int SiteId { get; set; }

        public byte[] IsActive { get; set; } = null!;

        public virtual CustomerMaster? Customer { get; set; } = null!;

        public virtual SiteMaster? Site { get; set; } = null!;
    }
}
