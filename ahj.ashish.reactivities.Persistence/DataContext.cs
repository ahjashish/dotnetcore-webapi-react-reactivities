using ahj.ashish.reactivities.Domain;
using Microsoft.EntityFrameworkCore;

namespace ahj.ashish.reactivities.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Value> Values { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Value>()
            .HasData(
                new Value { Id = 1, Name = "Value101" },
                new Value { Id = 2, Name = "Value201" },
                new Value { Id = 3, Name = "Value301" }
            );
        }
    }
}
