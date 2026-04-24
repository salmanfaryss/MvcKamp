using DataAcces.Repository.Abstract;
using DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Repository.Concrete
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;
        public GenericRepository()
        {
            _object = c.Set<T>();
        }
        public void Delete(T p)
        {
            var deleteEntity = c.Entry(p);
            deleteEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).FirstOrDefault();
        }

        public T GetById(int id)
        {
           return _object.Find(id);
        }

        public List<T> GetList()
        {
            return _object.ToList();
        }

        public void Insert(T p)
        {
           var addEntity = c.Entry(p);
           addEntity.State = EntityState.Added;
            c.SaveChanges();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            
           return _object.Where(filter).ToList();
        }

        public void Update(T p)
        {
            var updateEntity = c.Entry(p);
            updateEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
