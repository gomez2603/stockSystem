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
            
                update.name = product.Name;
                update.description = product.Description;
                update.image = product.Image;
                update.category = product.Category;
                update.barcode = product.Barcode;
                update.categoryId = product.CategoryId;
                update.size = product.Size;
                update.model = product.Model;
                update.brand = product.Brand;
                update.supplierId = product.SupplierId;
                update.cost = product.Cost;
                update.margin = product.Margin;
                _context.Products.Update(update);
            }

        }

     
    }
}
