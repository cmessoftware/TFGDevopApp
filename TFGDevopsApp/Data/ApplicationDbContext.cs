using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TFGDevopsApp.Infraestructure.Entity.Mantis;

namespace TFGDevopsApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<IssueEntity> Issues { get; set; }
        public DbSet<IssueTracking> IssueTrackings { get;set; }
    }
}
