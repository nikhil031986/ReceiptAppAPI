using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Entity
{
    public partial class UserSite :BaseEntity
    {
        [Key]
        public int UserSiteId { get; set; }
        public int UserId { get; set; }
        public int SiteId { get; set; }
        public virtual UserMaster? User { get; set; } = null!;
        public virtual SiteMaster? Site { get; set; } = null!;
    }
}
