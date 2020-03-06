using Microsoft.EntityFrameworkCore;

namespace SportingEvents.Models
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
                : base(options) { }

        public DbSet<Responses> UserInfo { get; set; }

    }
}
