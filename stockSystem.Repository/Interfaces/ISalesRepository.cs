using stockSystem.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.Repository.Interfaces
{
    public interface ISalesRepository : IBaseRepository<Sales>
    {
        void Update(Sales sales);
    }
}
