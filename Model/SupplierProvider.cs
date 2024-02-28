using SupermarketManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManagementSystem.Model
{
    public class SupplierProvider:ProviderBase,IProvider<supplier>
    {
        public static SupplierProvider Current = new SupplierProvider();

        public int Delete(supplier entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges();
        }

        public List<supplier> GetAll()
        {
            return db.supplier.ToList();
        }
        
        public int Insert(supplier entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public int Update(supplier entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
