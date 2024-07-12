using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Interfaces;
using Domain.Interfaces;
using System.IO;
using Domain.Entities;
using System.Web;
using System.Web.Mvc;
using Repository;


namespace Service
{
    public class UserService : IUserService

    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }
        [HttpPost]
        public void SignUp(string username, string email, string password, string confirmpassword)
        {
            if (password != confirmpassword)
            {
                throw new Exception("Passwords do not match");
            }


            var user = new User
            {
                Username = username,
                Email = email,
                Password = password,
                ConfirmPassword = confirmpassword,
             
            };

            _userRepository.Add(user);

        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public void EditUser(User user)
        {
            _userRepository.Edit(user);
        }

        public void DeleteUser(int userId)
        {
            _userRepository.Delete(userId);
        }

        public User GetUserById(int userId)
        {
            return _userRepository.GetUserById(userId);
        }
    }
}
