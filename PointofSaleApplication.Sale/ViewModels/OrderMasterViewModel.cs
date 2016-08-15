using PointofSaleApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSaleApplication.Sale.ViewModels
{
    class OrderMasterViewModel : OrderMaster
    {
        public OrderMaster GetFrom()
        {
            return new OrderMaster
            {
                Id = this.Id,
                orderdetail = this.orderdetail,
                CreatiomTime = this.CreatiomTime,
                Status = this.Status,
                Synchronized = this.Synchronized,
                TotalSum = this.TotalSum

            };
        }
    }
}
