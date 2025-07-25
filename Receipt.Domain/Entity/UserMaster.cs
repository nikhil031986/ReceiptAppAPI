using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Receipt.Domain.Entity
{
    public class UserMaster:BaseEntity
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string EmailId { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public bool? IsAdmin { get; set; }
        public ICollection<SiteMaster> siteMasters { get;set; }
    }
}
