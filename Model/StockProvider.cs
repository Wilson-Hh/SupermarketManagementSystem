using SupermarketManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManagementSystem.Model
{
    public class StockProvider:ProviderBase,IProvider<stock>
    {
        public static StockProvider Current = new StockProvider();

        public int Delete(stock entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges();
        }

        public List<stock> GetAll()
        {
            return db.stock.ToList();
        }

        public int Insert(stock entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public int Update(stock entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
