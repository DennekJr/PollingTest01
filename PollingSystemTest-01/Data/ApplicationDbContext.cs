using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PollingSystemTest_01.Models;

namespace PollingSystemTest_01.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<PollQuestion> Questions { get; set; }
        public DbSet<PollOption> Options { get; set; }
        public DbSet<Vote> Votes { get; set; }
        public DbSet<UsersSelected> UsersSelected { get; set; }
    }
}

