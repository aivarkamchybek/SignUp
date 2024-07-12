using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Service.Interfaces
{
    public interface IUserService
    {
        void SignUp(string username, string email, string password, string confirmpassword);
        IEnumerable<User> GetAllUsers();
        void EditUser(User user);
        void DeleteUser(int userId);
        User GetUserById(int userId);
    }
}
