using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        T Get(int id);

        IQueryable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            string incluirPropiedades = ""
            );

        T FindOne(
            Expression<Func<T, bool>> filter = null,
            string incluirPropiedades = ""
            );

        void Add(T entidad);

        void Remove(int id);

        void Remove(T entidad);

        void RemoveRange(IEnumerable<T> entidad);
    }
}
