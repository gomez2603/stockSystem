
using stockSystem.Repository.Interfaces;
using stockSystem.DataAccess.Models;
using StockSystem.dataAccess.context;

namespace stockSystem.Repository.Implementation
{
    internal class categoryRepository : BaseRepository<Category>, ICategoryRespository
    {
        private readonly stockSystemContext _context;
        public categoryRepository(stockSystemContext context) : base(context)
        {
            _context = context;
        }

        public void Update(Category category)
        {
           var entity = _context.Category.FirstOrDefault(x=> x.Id == category.Id);
            if (entity != null)
            {
                entity.Name = category.Name;
                _context.Category.Update(entity);
            }
        }
    }
}
