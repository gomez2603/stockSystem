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
            var update = _context.Products.FirstOrDefault(x=>x.id == product.id);
            if (update != null) {
            
                update.name = product.name;
                update.description = product.description;
                update.quantity = product.quantity;
                update.price = product.price;
                update.image = product.image;
                update.category = product.category;
                update.barcode = product.barcode;
                update.categoryId = product.categoryId;
                update.size = product.size;
                update.model = product.model;
                update.brand = product.brand;
                _context.Products.Update(update);
            }

        }

     
    }
}
