using stockSystem.DataAccess.Models;
using System.Linq.Expressions;


namespace stockSystem.Services.Interfaces
{
    public interface ISalesService
    {
        Sales Get(int id);

        IEnumerable<Sales> GetAll(
            Expression<Func<Sales, bool>> filter = null,
            string incluirPropiedades = "", BaseFilter pagination = null);

        Sales FindOne(
            Expression<Func<Sales, bool>> filter = null,
            string incluirPropiedades = ""
            );

        void Add(Sales entidad);

        void Update(Sales entidad);

        void Remove(int id);

        void Remove(Sales entidad);

        void RemoveRange(IEnumerable<Sales> entidad);


        bool ValidateTotalAsync(Sales sales);
    }
}
