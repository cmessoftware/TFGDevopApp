using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TFGDevopsApp.Infraestructure.Entity.Mantis;
using TFGDevopsApp.Infraestructure.Entity.Plastic;
using TFGDevopsApp.Infraestructure.Entity.Project;

namespace TFGDevopsApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<IssueEntity> Issues { get; set; }
        public DbSet<IssueTracking> IssueTrackings { get;set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Changeset> Changesets { get; set; }
        public DbSet<ProjectBuild> ProjectBuilders { get; set; }

    }
}
