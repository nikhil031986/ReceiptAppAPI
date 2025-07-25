using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Receipt.Domain.Entity
{
    public abstract class BaseEntity
    {
        public int? CreateuserId { get; set; } = 0;
        public string? CreatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public int? UpdateuserId { get; set; } = 0;
        public string? UpdatedAt { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public bool? IsActive { get; set; } = true;
    }
}
