using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    //Generik Repository Kısmı
    public class Repository<T> : IRepository<T> where T : class
    {
        Context context = new Context();

        DbSet<T> _object;

        public Repository()
        {
            _object = context.Set<T>();
        }
        public void Delete(T p) 
        {
            //_object.Remove(p);
            //context.SaveChanges();
            var deleteEntity = context.Entry(p); // Entity state kullanımı.
            deleteEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where) // buralara tekrar dönecegiz 94.ders
        {
            return _object.FirstOrDefault(where);
        }

        public T GetByID(int id)
        {
            return _object.Find(id);
        }

        public void Insert(T p)
        {
            //_object.Add(p);
            var addedEntity = context.Entry(p);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();  
        }

        public void Update(T p)
        {
            //context.SaveChanges();
            var updateEntity = context.Entry(p);
            updateEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
