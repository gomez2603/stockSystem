using stockSystem.DataAccess.Models;
using StockSystem.dataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.Repository.Interfaces
{
    public interface ICategoryRespository: IBaseRepository<Category>
    {
        void Update(Category category);
    }
}
