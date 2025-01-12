using StockSystem.dataAccess.Models;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;


namespace stockSystem.Services.Interfaces
{
    public interface IProductService
    {
        Product Get(int id);

        IEnumerable<Product> GetAll(
            Expression<Func<Product, bool>> filter = null,
            string incluirPropiedades = "", BaseFilter pagination = null);

        Product FindOne(
            Expression<Func<Product, bool>> filter = null,
            string incluirPropiedades = ""
            );

        void Add(Product entidad);

        void Update(Product entidad);

        void Remove(int id);

        void Remove(Product entidad);

        void RemoveRange(IEnumerable<Product> entidad);
       
        
            
        
    }
}
