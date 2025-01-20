using stockSystem.DataAccess.Models;
using StockSystem.dataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.Services.Interfaces
{
    public interface ICategoryService
    {

        Category Get(int id);

        IEnumerable<Category> GetAll(
            Expression<Func<Category, bool>> filter = null,
            string incluirPropiedades = "", BaseFilter pagination = null);

        Category FindOne(
            Expression<Func<Category, bool>> filter = null,
            string incluirPropiedades = ""
            );

        void Add(Category entidad);

        void Update(Category entidad);

        void Remove(int id);

        void Remove(Category entidad);

        void RemoveRange(IEnumerable<Category> entidad);
    }
}
