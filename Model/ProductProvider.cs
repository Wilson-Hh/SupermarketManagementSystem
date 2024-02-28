using SupermarketManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManagementSystem.Model
{
    public class ProductProvider : ProviderBase, IProvider<product>
    {
        public static ProductProvider Current = new ProductProvider();

        public int Delete(product entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges();
        }

        public List<product> GetAll()
        {
            return db.product.ToList();
        }

        public int Insert(product entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public int Update(product entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
