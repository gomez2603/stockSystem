using StockSystem.dataAccess.Models;
using stockSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using stockSystem.Services.Interfaces;
using stockSystem.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace stockSystem.Services
{
    public class SalesService:ISalesService
    {

        private readonly IUnitOfWork _unitOfWork;

        public SalesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Sales entidad)
        {
            _unitOfWork.salesRespository.Add(entidad);
            _unitOfWork.Save();
        }

        public void Update(Sales entidad)
        {
            _unitOfWork.salesRespository.Update(entidad);
            _unitOfWork.Save();
        }

        public Sales FindOne(Expression<Func<Sales, bool>> filter = null, string incluirPropiedades = "")
        {
            return _unitOfWork.salesRespository.FindOne(filter, incluirPropiedades);
        }

        public Sales Get(int id)
        {
            return _unitOfWork.salesRespository.Get(id);
        }

        public IEnumerable<Sales> GetAll(Expression<Func<Sales, bool>> filter = null, string incluirPropiedades = "", BaseFilter pagination = null)
        {
            return _unitOfWork.salesRespository.GetAll(filter, incluirPropiedades);
        }

        public void Remove(int id)
        {
            _unitOfWork.salesRespository.Remove(id);
            _unitOfWork.Save();
        }

        public void Remove(Sales entidad)
        {
            _unitOfWork.salesRespository.Remove(entidad);
            _unitOfWork.Save();
        }

        public void RemoveRange(IEnumerable<Sales> entidad)
        {
            _unitOfWork.salesRespository.RemoveRange(entidad);
            _unitOfWork.Save();
        }

        public bool ValidateTotalAsync(Sales sales)
        {
            var calculatedTotal = 0m;

            foreach (var detail in sales.salesDetails)
            {
                var product =  _unitOfWork.productRepository.FindOne(x=>x.id == detail.productId);
                if (product != null)
                {
                    calculatedTotal += product.price * detail.quantity;
                }

               
            }

            return sales.total == calculatedTotal;
        }
    }
}
