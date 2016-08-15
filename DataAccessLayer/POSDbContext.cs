using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
   public class POSDbContext:DbContext
    {
        public DbSet<Product> products { get; set; }
        public DbSet<orderMaster> ordermasters { get; set; }
        public DbSet<OrderDetail> orderdetails { get; set; }
        public DbSet<SyncLog> Synclogs { get; set; }
    }
}
