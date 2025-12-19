using Microsoft.EntityFrameworkCore;
using Receipt.Domain.Entity;

namespace Receipt.Infra.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<UserMaster> userMasters { get; set; }
        public DbSet<SiteMaster> siteMasters { get; set; }
        public DbSet<UserSite> userSites { get; set; }

        public DbSet<WingDetail> wingDetails { get; set; }
        public DbSet<WingMaster> DbwingMasters { get; set; }
        public DbSet<CustomerDetail> customerDetails { get; set; }
        public DbSet<CustomerMaster> customerMasters { get; set; }
        public DbSet<ReceiptDetail> receiptDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
    }
}
