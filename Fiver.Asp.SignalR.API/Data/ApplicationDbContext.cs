using Microsoft.EntityFrameworkCore;

namespace Fiver.Asp.SignalR.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Entities.Report> Reports { get; set; }
    }
}
