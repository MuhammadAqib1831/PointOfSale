using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public enum Status
    {
       New ,Completed
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime Updated { get; set; }
    }
    public class orderMaster
    {
        public Guid id { get; set; }
        public DateTime  CreatiomTime{ get; set; }
        public decimal TotalSum { get; set; }
        public Status status { get; set; }
        public bool Synchronized { get; set; }
    }
    public class OrderDetail
    {
        public int Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int quantity { get; set; }
        public virtual ICollection<Product> products { get; set; }
        public virtual ICollection<orderMaster> orderMaster { get; set; }
    }
    public class SyncLog
    {
        public int Id { get; set; }
        public DateTime lastUpdated { get; set; }
    }
}
