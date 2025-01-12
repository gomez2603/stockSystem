using StockSystem.dataAccess.Models;
using stockSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using stockSystem.Services.Interfaces;

namespace stockSystem.Services
{
    public class ProductService:IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Product entidad)
        {
            _unitOfWork.productRepository.Add(entidad);
            _unitOfWork.Save();
        }

        public void Update(Product entidad)
        {
            _unitOfWork.productRepository.Update(entidad);
            _unitOfWork.Save();
        }

        public Product FindOne(Expression<Func<Product, bool>> filter = null, string incluirPropiedades = "")
        {
            return _unitOfWork.productRepository.FindOne(filter, incluirPropiedades);
        }

        public Product Get(int id)
        {
            return _unitOfWork.productRepository.Get(id);
        }

        public IEnumerable<Product> GetAll(Expression<Func<Product, bool>> filter = null, string incluirPropiedades = "", BaseFilter pagination = null)
        {
            return _unitOfWork.productRepository.GetAll(filter, incluirPropiedades);
        }

        public void Remove(int id)
        {
            _unitOfWork.productRepository.Remove(id);
            _unitOfWork.Save();
        }

        public void Remove(Product entidad)
        {
            _unitOfWork.productRepository.Remove(entidad);
            _unitOfWork.Save();
        }

        public void RemoveRange(IEnumerable<Product> entidad)
        {
            _unitOfWork.productRepository.RemoveRange(entidad);
            _unitOfWork.Save();
        }
    }
}
