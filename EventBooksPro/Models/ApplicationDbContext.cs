using EventBooksPro.Migrations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace EventBooksPro.Models
{
    public interface IApplicationDbContext
    {
        IDbSet<Client> Clients { get; set; }
        IDbSet<Event> Events { get; set; }
        IDbSet<EventType> EventTypes { get; set; }

        int SaveChanges();
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            :base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            base.OnModelCreating(modelBuilder);
        }

        public IDbSet<Client> Clients { get; set; }
        public IDbSet<Event> Events { get; set; }
        public IDbSet<EventType> EventTypes { get; set; }
    }
}