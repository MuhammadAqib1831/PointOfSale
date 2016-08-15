using PointofSaleApplication.Data;
using PointofSaleApplication.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleService.Data
{
    public class OrderController
    {
        public List<OrderMaster> GetUpdatedOrders()
        {
            List<OrderMaster> orders = new List<OrderMaster>();
            try
            {

            
            string localConnection = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
         
            using (POSDbContext db = new POSDbContext(localConnection))
            {

              var orderdata= db.ordermasters.Where(x => x.Synchronized == false).Select(o => new 
                {
                    Id = o.Id,
                    CreatiomTime = o.CreatiomTime,
                    Status = o.Status,
                    Synchronized = o.Synchronized,
                    TotalSum = o.TotalSum,
                    orderdetail = db.orderdetails.Where(od => od.OrderId == o.Id).Select(od=>new 
                    {
                        Id=od.Id,
                        OrderId=od.OrderId,
                        OrderMaster=od.OrderMaster,
                         ItemId=od.ItemId,
                         Porduct=od.Porduct,
                         UnitPrice=od.UnitPrice,
                          Quantity=od.Quantity
                           
                    }).ToList()
                }).ToList();
              foreach (var o in orderdata)
              {
                  orders.Add(new OrderMaster
                  {
                      Id = o.Id,
                      CreatiomTime = o.CreatiomTime,
                      Status = o.Status,
                      Synchronized = o.Synchronized,
                      TotalSum = o.TotalSum,
                      orderdetail = o.orderdetail.Select(od => new OrderDetail
                      {
                          Id = od.Id,
                          OrderId = od.OrderId,
                          OrderMaster = od.OrderMaster,
                          ItemId = od.ItemId,
                          Porduct = od.Porduct,
                          UnitPrice = od.UnitPrice,
                          Quantity = od.Quantity
                      }).ToList()
                  });
              }
                return orders;
            }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public void UpdatedOrdersStatus(List<OrderMaster> orders)
        {
            string localConnection = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
            using (POSDbContext db = new POSDbContext(localConnection))
            {
                foreach (var order in orders)
                {
                    var _order = db.ordermasters.FirstOrDefault(o => o.Id == order.Id);
                    if (_order != null)
                        _order.Synchronized = true;
                }
                db.SaveChanges();
            }
        }
        public void upDateOrderDetail(List<OrderDetail> orderDetail)
        {
            try
            {
               string localConnection = ConfigurationManager.ConnectionStrings["LIVEConnection"].ConnectionString;
                using (POSDbContext db = new POSDbContext(localConnection))
                {
                    foreach (var order in orderDetail)
                    {
                        OrderDetail od = new OrderDetail() 
                        {
                          Id=order.Id,
                          Porduct=order.Porduct,
                          //OrderMaster=order.OrderMaster,
                          ItemId=order.ItemId,
                          OrderId=order.OrderId,
                          Quantity=order.Quantity,
                          UnitPrice=order.UnitPrice
                             

                        };
                        db.orderdetails.Add(od);
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                 Exception realerror = ex;
               while (realerror.InnerException != null)
                    realerror = realerror.InnerException;

               Console.WriteLine(realerror.ToString());
                throw;
            }
        }
    }
}
