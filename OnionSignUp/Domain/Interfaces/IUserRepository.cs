using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
        IEnumerable<User> GetAllUsers();
        void Edit(User user);
        void Delete(int userId);
        User GetUserById(int userId);
    }
}
