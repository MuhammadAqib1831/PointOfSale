using Microsoft.AspNet.Identity.EntityFramework;
using PointofSaleApplication.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSaleApplication.Data
{
    public class POSDbContext : IdentityDbContext<ApplicationUser>
    {
        public POSDbContext()
            : base("LocalConnection")
        {

        }
        public POSDbContext(string connString)
            : base(connString)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUser>().ToTable("Users", "dbo");
            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "dbo");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UsersInRoles", "dbo");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogins", "dbo");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaims", "dbo");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles", "dbo");


        }

        public DbSet<Product> products { get; set; }
        public DbSet<OrderMaster> ordermasters { get; set; }
        public DbSet<OrderDetail> orderdetails { get; set; }
        public DbSet<SynLog> Synclogs { get; set; }

    }
}
