using PointofSaleApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSaleApplication.Data
{
   public  class Repository
    {
       POSDbContext db = null;
       public Repository()
       {
           db = new POSDbContext();
       }
       public List<Product> GetProducts()
       {
           return db.products.ToList();
       }
       public void AddOrder(OrderMaster d)
       {
           db.ordermasters.Add(d);
           foreach (var detail in d.orderdetail)
           {              
               db.orderdetails.Add(detail);
           }
           Commit();
       }

       private void Commit()
       {
           db.SaveChanges();
       }
    }
}
