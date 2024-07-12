using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Entities;
using Repository;
using System.Data.Entity;
using System.Runtime.Remoting.Contexts;

namespace Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SignUpContext _context;

        public UserRepository()
        {
            _context = new SignUpContext();
        }

        public void Add(User user)
        {


            _context.Account.Add(user);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            var result = _context.Account.ToList();

            return _context.Account.ToList();
        }

        public void Edit(User user)
        {
            var existingUser = _context.Account.Find(user.Id);
            if (existingUser != null)
            {
                existingUser.Username = user.Username;
                existingUser.Email = user.Email;
                existingUser.Password = user.Password;
                existingUser.ConfirmPassword = user.ConfirmPassword;

                _context.Entry(existingUser).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Delete(int userId)
        {
            var user = _context.Account.Find(userId);
            if (user != null)
            {
                _context.Account.Remove(user);
                _context.SaveChanges();
            }
        }

        public User GetUserById(int userId)
        {
            return _context.Account.Find(userId);
        }
    }
}
    
