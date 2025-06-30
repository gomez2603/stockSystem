using Microsoft.EntityFrameworkCore;
using stockSystem.Repository.Interfaces;
using stockSystem.Repository.Utils;
using StockSystem.dataAccess.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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

        public Utils.PagedResult<T> GetAll(QueryParameters parameters, string[] includeProps = null)
        {
            IQueryable<T> query = dbSet;

            // Filtros dinámicos
            foreach (var filtro in parameters.Filters)
            {
                var propInfo = typeof(T).GetProperty(filtro.Key);
                if (propInfo != null)
                {
                    query = query.Where($"{filtro.Key}.ToString().Contains(@0)", filtro.Value);
                }
            }

            int totalCount = query.Count();

            // Includes controlados por backend
            if (includeProps != null)
            {
                foreach (var include in includeProps)
                {
                    query = query.Include(include);
                }
            }

            query = query.OrderBy($"{parameters.OrderBy} {(parameters.Desc ? "descending" : "ascending")}");

            var items = query
                .Skip((parameters.Page - 1) * parameters.PageSize)
                .Take(parameters.PageSize)
                .ToList();

            return new Utils.PagedResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                Page = parameters.Page,
                PageSize = parameters.PageSize
            };
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
