using StockSystem.dataAccess.Models;
using stockSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stockSystem.DataAccess.Models;
using StockSystem.dataAccess.context;

namespace stockSystem.Repository.Implementation
{
    public class SalesRespository : BaseRepository<Sales>, ISalesRepository
    {
        private readonly stockSystemContext _contex;
        public SalesRespository(stockSystemContext context) : base(context)
        {
            _contex = context;
        }

        public void Update(Sales sales)
        {
          var salesupdate = _contex.Sales.FirstOrDefault(x=>x.id == sales.id);
            if (salesupdate != null)
            {
                salesupdate.total = sales.total;
                salesupdate.salesBy = sales.salesBy;

            }
        }
    }
}
