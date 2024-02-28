using SupermarketManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketManagementSystem.Model
{
    public class MemberProvider : ProviderBase, IProvider<member>
    {
        public static MemberProvider Current = new MemberProvider();
        public int Delete(member entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
            return db.SaveChanges();
        }

        public List<member> GetAll()
        {
            return db.member.ToList();
        }

        public int Insert(member entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Added;
            return db.SaveChanges();
        }

        public int Save()
        {
            return db.SaveChanges();
        }

        public int Update(member entity)
        {
            db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            return db.SaveChanges();
        }
    }
}
