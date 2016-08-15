using PointofSaleApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSaleApplication.Sale.ViewModels
{
    class OrderDetailViewModel : OrderDetail
    {
        public decimal GrossTotal { get { return Quantity * UnitPrice; } }
        public string ItemName { get; set; }

        public OrderDetail GetFrom()
        {
            return new OrderDetail
            {
                Id = this.Id,
                OrderMaster = this.OrderMaster,
                ItemId = this.ItemId,
                UnitPrice = this.UnitPrice,
                Porduct = this.Porduct,
                OrderId = this.OrderId,
                Quantity = this.Quantity
            };
        }
    }
}
