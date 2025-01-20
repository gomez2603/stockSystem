using StockSystem.dataAccess.Models;
using stockSystem.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using stockSystem.DataAccess.Models;
using stockSystem.Services.Interfaces;

namespace stockSystem.Services
{
    public class CategoryService :ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Category entidad)
        {
            _unitOfWork.categoryRepository.Add(entidad);
            _unitOfWork.Save();
        }

        public void Update(Category entidad)
        {
            _unitOfWork.categoryRepository.Update(entidad);
            _unitOfWork.Save();
        }

        public Category FindOne(Expression<Func<Category, bool>> filter = null, string incluirPropiedades = "")
        {
            return _unitOfWork.categoryRepository.FindOne(filter, incluirPropiedades);
        }

        public Category Get(int id)
        {
            return _unitOfWork.categoryRepository.Get(id);
        }

        public IEnumerable<Category> GetAll(Expression<Func<Category, bool>> filter = null, string incluirPropiedades = "", BaseFilter pagination = null)
        {
            return _unitOfWork.categoryRepository.GetAll(filter, incluirPropiedades);
        }

        public void Remove(int id)
        {
            _unitOfWork.categoryRepository.Remove(id);
            _unitOfWork.Save();
        }

        public void Remove(Category entidad)
        {
            _unitOfWork.categoryRepository.Remove(entidad);
            _unitOfWork.Save();
        }

        public void RemoveRange(IEnumerable<Category> entidad)
        {
            _unitOfWork.categoryRepository.RemoveRange(entidad);
            _unitOfWork.Save();
        }
    }
}
