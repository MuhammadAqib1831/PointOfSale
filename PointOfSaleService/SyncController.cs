using PointofSaleApplication.Data;
using PointofSaleApplication.Model;
using PointOfSaleService.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointOfSaleService
{
    public class SyncController
    {
        static int x=0;
        public void SyncData()
        {
            try
            {
                DateTime ExecutionDate = DateTime.Now; ;
                DateTime LastExecutedDate = DateTime.Now;

                string localConnection = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
                string liveConnection = ConfigurationManager.ConnectionStrings["LIVEConnection"].ConnectionString;
                using (POSDbContext db = new POSDbContext(localConnection))
                {
                    var log= db.Synclogs.FirstOrDefault();
                    if (log != null)
                    { 
                        LastExecutedDate = log.lastUpdated;
                    }
                  //  log.lastUpdated = ExecutionDate;
                  //  db.SaveChanges();
                       
                       
                };
                ExecutionDate = DateTime.Now;
                #region Update Product
                List<Product> products = new List<Product>();
                productRepository r = new productRepository(liveConnection);
                List<Product> p= r.GetProducts();
                if (p.Count !=0)
                {
                    products = p.Where(od => od.Updated >= LastExecutedDate && od.Updated <= ExecutionDate).ToList();
                }
                //using (POSDbContext db = new POSDbContext(liveConnection))
                //{
                //    //if (x == 0)
                //    //{
                //    //    ++x;
                //    //    SyncData();
                //    //}

                //    List<Product> newp = db.products.ToList();
                //    if (newp != null)
                //    {
                //        products = newp.Where(p => p.Updated >= LastExecutedDate && p.Updated <= ExecutionDate).ToList();
                //    }
                //}
                if (products.Count!=0)
                {
                    ProductController productController = new ProductController();
                    bool res = productController.UpdateProducts(products);
                    if (res)
                    {
                        using (POSDbContext db = new POSDbContext(localConnection))
                        {
                            var syncLog = db.Synclogs.First();
                            syncLog.lastUpdated = DateTime.Now;
                            //foreach(var product in products)
                            //{
                            //    db.products.Add(product);
                            //}
                            db.SaveChanges();
                        }
                    }
                }
                #endregion

                #region Update Orders
                OrderController orderController = new OrderController();
                var orders = orderController.GetUpdatedOrders();
                List<OrderDetail> orderdetail = new List<OrderDetail>();
                var repository = new productRepository(liveConnection);
                foreach (var order in orders)
                {
                     OrderMaster om = new OrderMaster
                           {

                               Id = order.Id,
                               CreatiomTime = order.CreatiomTime,
                               orderdetail = null,
                               Status = order.Status,
                               Synchronized = order.Synchronized,
                               TotalSum = order.TotalSum

                           };
                         foreach(var od in order.orderdetail){
                             orderdetail.Add(od);
                         }
                   
                    repository.AddOrder(om);
                }
                //if (orders.Count > 0)
                //{
                //    foreach(var order in orders)
                //    {
                //       using(POSDbContext db=new POSDbContext(liveConnection)){
                //        foreach (var od in order.orderdetail)
                //        {
                //            OrderDetail orderdetil = new OrderDetail
                //            {
                //                 Id = new Guid(),
                //                 ItemId=od.ItemId,
                //                 OrderId=od.OrderId,
                //                 OrderMaster=od.OrderMaster,
                //                 Porduct=od.Porduct,
                //                 Quantity=od.Quantity,
                //                 UnitPrice=od.UnitPrice
                //            };
                //            db.orderdetails.Add(orderdetil);
                //        }
                //        db.SaveChanges();
                //        }
                //    }
                //  using(POSDbContext db=new POSDbContext(liveConnection)){
                //      foreach (var master in orders)
                //      {
                //          db.ordermasters.Add(master);
                //      }
                //      db.SaveChanges();
                //    }
                //}
                //if (orders.Count > 0)
                //{

                //    using (POSDbContext db = new POSDbContext(liveConnection))
                //    {
                //        foreach (var order in orders)
                //        {

                //            OrderMaster om = new OrderMaster
                //            {

                //                Id = order.Id,
                //                CreatiomTime = order.CreatiomTime,
                //                orderdetail = null,
                //                Status = order.Status,
                //                Synchronized = order.Synchronized,
                //                TotalSum = order.TotalSum

                //            };
                //         //  db.ordermasters.Add(om);
                //          foreach(var od in order.orderdetail){
                //              orderdetail.Add(od);
                //          }
                //            //foreach (var od in order.orderdetail)
                //            //{
                //            //    OrderDetail detail = new OrderDetail
                //            //    {
                //            //        Id = od.Id,
                //            //        ItemId = od.ItemId,
                //            //        UnitPrice = od.UnitPrice,
                //            //        OrderId = od.OrderId,
                //            //       // OrderMaster = od.OrderMaster,
                //            //       // Porduct = od.Porduct,
                //            //        Quantity = od.Quantity
                //            //    };
                //            //    db.orderdetails.Add(detail);
                //            //}
                //        }

                //        db.SaveChanges();
                //    }
                   orderController.upDateOrderDetail(orderdetail);
                   orderController.UpdatedOrdersStatus(orders);
                //}

                
                #endregion
                //success log + date time
            }
            catch (Exception ex)
            {
                Exception realerror = ex;
                while (realerror.InnerException != null)
                    realerror = realerror.InnerException;

                Console.WriteLine(realerror.ToString());
                
            }
            

        }
    }
}
