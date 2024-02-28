using SupermarketManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManagementSystem.Model
{
    public class CustomerProvider : ProviderBase, IProvider<customer>
    {
        public static CustomerProvider Current = new CustomerProvider();
        public int Delete(customer entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges();
        }

        public List<customer> GetAll()
        {
            return db.customer.ToList();
        }

        public int Insert(customer entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public int Update(customer entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
