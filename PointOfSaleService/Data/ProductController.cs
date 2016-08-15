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
  public class ProductController
    {
  
      public bool UpdateProducts(List<PointofSaleApplication.Model.Product> products)
        {
            string localConnection = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
            using (POSDbContext db = new POSDbContext(localConnection))
            {
                foreach (var product in products)
                {
                    var _product = db.products.FirstOrDefault(o => o.Id == product.Id);
                    if (_product != null)
                    {
                        _product.Updated = product.Updated;
                        _product.Name = product.Name;
                        _product.UnitPrice = product.UnitPrice;
                        db.Entry(_product).State = System.Data.Entity.EntityState.Modified;
                    }
                    else
                    {
                        db.products.Add(product);
                    }
                }
                db.SaveChanges();
                return true;
            }
        }
    }
}
