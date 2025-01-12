using Microsoft.EntityFrameworkCore;
using stockSystem.Repository.Interfaces;
using StockSystem.dataAccess.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.Repository.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly stockSystemContext _context;
        internal DbSet<T> dbSet;

        public BaseRepository(stockSystemContext context)
        {
            _context = context;
            this.dbSet = _context.Set<T>();
        }

        public void Add(T entidad)
        {
            dbSet.Add(entidad);      // insert into  Table
        }

        public T Get(int id)
        {
            return dbSet.Find(id);    // select * from 
        }

        public T FindOne(Expression<Func<T, bool>> filter = null, string incluirPropiedades = null)
        {

            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);   // select * from where ...
            }

            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }
            }

            return query.FirstOrDefault();

        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> filter = null, string incluirPropiedades = null)
        {
            IQueryable<T> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);   // select * from where ...
            }
            
            if (incluirPropiedades != null)
            {
                foreach (var incluirProp in incluirPropiedades.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(incluirProp);
                }
            }


            return query;

        }

        public void Remove(int id)
        {
            T entidad = dbSet.Find(id);
            Remove(entidad);
        }

        public void Remove(T entidad)
        {
            dbSet.Remove(entidad);    // delete from 
        }

        public void RemoveRange(IEnumerable<T> entidad)
        {
            dbSet.RemoveRange(entidad);
        }


    }
}
