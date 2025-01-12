using StockSystem.dataAccess.Models;
using stockSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StockSystem.dataAccess.context;

namespace stockSystem.Repository.Implementation
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly stockSystemContext _context;
        public ProductRepository(stockSystemContext context) : base(context)
        {
            _context = context;
        }


        public void Update(Product product)
        {
            var update = _context.Products.FirstOrDefault(x=>x.Id == product.Id);
            if (update != null) {
            
                update.Name = product.Name;
                update.Description = product.Description;
                update.Quantity = product.Quantity;
                update.Price = product.Price;
                update.Image = product.Image;
                _context.Products.Update(update);
            }

        }

     
    }
}
