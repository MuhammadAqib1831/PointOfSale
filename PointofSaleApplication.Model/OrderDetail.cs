using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSaleApplication.Model
{
   public class OrderDetail
    {
        public Guid Id { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int ItemId { get; set; }

       [ForeignKey("ItemId")]
        public virtual Product Porduct { get; set; }

        public Guid OrderId { get; set; }

       [ForeignKey("OrderId")]
        public virtual OrderMaster OrderMaster { get; set; }
        
    }
}
