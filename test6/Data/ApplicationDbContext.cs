using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test6.Models;

namespace test6.Data
{
    public class ApplicationDbContext  :  IdentityDbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<ManageRoles> ManageRoles { get; set; }
        public DbSet<Issue> Issue { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
    }
}
