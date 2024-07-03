using System;
using System.Collections.Generic;
using System.Linq;
using SignUp.Models;

namespace SignUp.DAL
{
    public class SignUp
    {
        private SignUpContext db = new SignUpContext();

        public bool AddUser(SignUpModel user)
        {
            try
            {
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
