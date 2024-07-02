using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using SignUp.Models;

namespace SignUp.DAL
{
    public class SignUpDAL
    {
        private SignUpContext db = new SignUpContext();

        public bool AddUser(string username, string email, string password, string confirmPassword, string profilePicturePath)
        {
            try
            {
                var user = new SignUpModel
                {
                    Username = username,
                    Email = email,
                    Password = password,
                    ConfirmPassword = confirmPassword,
                    ProfilePicturePath = profilePicturePath
                };

                db.Users.Add(user);
                db.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
                return false;
            }
        }

        public List<SignUpModel> GetAllUsers()
        {
            try
            {
                return db.Users.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while fetching users", ex);
            }
        }
    }
}
