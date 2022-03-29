using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        void Insert(T p);  // executenonquery sayısal döndürdügü için int.

        void Update(T p);

        void Delete(T p);

        T GetByID(int id);

        List<T> List(Expression<Func<T,bool>> filter); //linq expression delegate kullanımı.

        T Find(Expression<Func<T, bool>> where);

    }
}
