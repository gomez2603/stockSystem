using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository userRepository { get; }
        IProductRepository productRepository { get; }

        ICategoryRespository categoryRepository { get; }
        void Save();
    }
}
