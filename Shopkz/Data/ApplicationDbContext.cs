using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shopkz.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shopkz.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Seazon> Seazon { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }


    }
}
