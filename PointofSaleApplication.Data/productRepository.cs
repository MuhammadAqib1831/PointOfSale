using PointofSaleApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointofSaleApplication.Data
{
   public  class productRepository
    {
       POSDbContext dbase = null;
       public productRepository(string con)
       {
           dbase = new POSDbContext(con);
       }
       public List<Product> GetProducts()
       {
           return dbase.products.ToList();
       }
       public void AddOrder(OrderMaster d)
       {
           dbase.ordermasters.Add(d);
           //foreach (var detail in d.orderdetail)
           //{              
           //    dbase.orderdetails.Add(detail);
           //}
           Commit();
       }

       private void Commit()
       {
           dbase.SaveChanges();
       }
    }
}
