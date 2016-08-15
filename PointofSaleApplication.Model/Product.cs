using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSaleApplication.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime Updated { get; set; }
      //  public virtual ICollection<OrderDetail> orderdetail { get; set; }
    }
}
