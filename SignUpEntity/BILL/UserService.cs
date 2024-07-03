using SignUp.DAL;
using SignUp.Models;
using System.Collections.Generic;

namespace SignUp.BLL
{
    public class UserService
    {
        private readonly SignUp.DAL.SignUp signUpRepository;

        public UserService()
        {
            signUpRepository = new SignUp.DAL.SignUp();
        }

        public bool AddUser(SignUpModel user)
        {
            return signUpRepository.AddUser(user);
        }

        public List<SignUpModel> GetAllUsers()
        {
            return signUpRepository.GetAllUsers();
        }
    }
}
