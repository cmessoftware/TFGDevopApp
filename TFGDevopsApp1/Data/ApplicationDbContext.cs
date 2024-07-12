using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TFGDevopsApp.Infraestructure.Entity.Mantis;

namespace TFGDevopsApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<IssueEntity> Issues { get; set; }
    }
}
