using StockSystem.dataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.Services.Interfaces
{
    public interface IUserService
    {
        User Get(int id);

        IEnumerable<User> GetAll(
            Expression<Func<User, bool>> filter = null,
            string incluirPropiedades = "", BaseFilter pagination = null);

        User FindOne(
            Expression<Func<User, bool>> filter = null,
            string incluirPropiedades = ""
            );

        void Add(User entidad);

        void Update(User entidad);

        void Remove(int id);

        void Remove(User entidad);

        void RemoveRange(IEnumerable<User> entidad);
    }
}
