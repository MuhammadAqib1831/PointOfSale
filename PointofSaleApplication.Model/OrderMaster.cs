using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSaleApplication.Model
{
    public enum Status
    {
        New,Completed
    }
   public class OrderMaster
    {
        public Guid Id { get; set; }
        public DateTime CreatiomTime { get; set; }
        public decimal TotalSum { get; set; }
        public Status Status { get; set; }
        public bool Synchronized { get; set; }
        public ICollection<OrderDetail> orderdetail { get; set; }
    }
}
