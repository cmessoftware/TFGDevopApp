using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TFGDevopsApp.Core.Helpers;
using TFGDevopsApp.Entities;

namespace TFGDevopsApp.Data
{
    public class ApplicationDBContext : IdentityDbContext
    {

        public ApplicationDBContext() { }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<TaskCategory> Categories { get; set; } 
    }
}
