using StockSystem.dataAccess.Models;
using stockSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using stockSystem.DataAccess.Models;
using StockSystem.dataAccess.context;
using Microsoft.EntityFrameworkCore;

namespace stockSystem.Repository.Implementation
{
    public class SalesDetailsRepository : BaseRepository<SalesDetail>,ISalesDetails
    {
        private readonly stockSystemContext _context;
        public SalesDetailsRepository(stockSystemContext context) : base(context)
        {
            _context = context;
        }

        public void Update(SalesDetail entity)
        {
            var salesupdate = _context.SalesDetail.FirstOrDefault(x=>x.salesId==entity.salesId);
            if (salesupdate != null)
            {
              salesupdate.productId = entity.productId;
              salesupdate.quantity = entity.quantity;
                _context.SalesDetail.Update(salesupdate);
            }
        }
    }
}
