using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Entities;
using Domain.Interfaces;

using System.Data.Entity;

namespace Repository
{
    public class SignUpContext : DbContext
    {
        public SignUpContext() : base("adoConnectionString")
        {
        }

        public DbSet<User> Account { get; set; }
    }
}