using stockSystem.Repository.Implementation;
using stockSystem.Repository.Interfaces;
using stockSystem.Services.Interfaces;
using StockSystem.dataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(User entidad)
        {
            _unitOfWork.userRepository.Add(entidad);
            _unitOfWork.Save();
        }

        public void Update(User entidad)
        {
            _unitOfWork.userRepository.Update(entidad);
            _unitOfWork.Save();
        }

        public User FindOne(Expression<Func<User, bool>> filter = null, string incluirPropiedades = "")
        {
            return _unitOfWork.userRepository.FindOne(filter, incluirPropiedades);
        }

        public User Get(int id)
        {
            return _unitOfWork.userRepository.Get(id);
        }

        public IEnumerable<User> GetAll(Expression<Func<User, bool>> filter = null, string incluirPropiedades = "", BaseFilter pagination = null)
        {
            return _unitOfWork.userRepository.GetAll(filter, incluirPropiedades);
        }

        public void Remove(int id)
        {
            _unitOfWork.userRepository.Remove(id);
            _unitOfWork.Save();
        }

        public void Remove(User entidad)
        {
            _unitOfWork.userRepository.Remove(entidad);
            _unitOfWork.Save();
        }

        public void RemoveRange(IEnumerable<User> entidad)
        {
            _unitOfWork.userRepository.RemoveRange(entidad);
            _unitOfWork.Save();
        }
    }
}
