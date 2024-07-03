using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;

namespace SignUp.Models
{
    public class SignUpContext : DbContext
    {
        public SignUpContext() : base("adoConnectionString")
        {
        }

        public DbSet<SignUpModel> Users { get; set; }
    }
}