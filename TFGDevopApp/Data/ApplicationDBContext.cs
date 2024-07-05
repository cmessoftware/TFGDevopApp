using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Entities;

namespace TFGDevopsApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<TaskCategory> Categories { get; set; } 
    }
}
