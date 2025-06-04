using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Entity
{
    public partial class SiteMaster
    {
        [Key]
        public int SiteId { get; set; }
        [Required]
        public string SiteName { get; set; }
        public string Display_Name { get; set; }
        public string Address { get;set; }
        public string RegistrationDetails { get; set; }
        public int UserId { get; set; }
        public UserMaster? User { get; set; }

    }
}
