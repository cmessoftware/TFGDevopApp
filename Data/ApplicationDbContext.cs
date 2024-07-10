using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TFGDevopsApp1.Infraestructure.Entity.Mantis;

namespace TFGDevopsApp1.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<IssueEntity> Issues { get; set; }
    }
}
