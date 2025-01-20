using stockSystem.Repository.Interfaces;
using StockSystem.dataAccess.context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly stockSystemContext _context;
        public IUserRepository userRepository { get; private set; }
        public IProductRepository productRepository { get; private set; }

        public ICategoryRespository categoryRepository { get; private set; }   

        public UnitOfWork(stockSystemContext context)
        {
            _context = context;
            userRepository = new UserRepository(context);
            productRepository = new ProductRepository(context);
            categoryRepository = new categoryRepository(context);

        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
