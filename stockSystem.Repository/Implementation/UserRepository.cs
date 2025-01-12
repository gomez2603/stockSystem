using stockSystem.Repository.Interfaces;
using StockSystem.dataAccess.context;
using StockSystem.dataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stockSystem.Repository.Implementation
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly stockSystemContext _context;
        public UserRepository(stockSystemContext context) : base(context)
        {
            _context = context;
        }


        public void Update(User user)
        {
            var userUpdate = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            if (user != null)
            {
                userUpdate.Name = user.Name;
                _context.Users.Update(userUpdate);

            }
        }
    }
}