using Microsoft.EntityFrameworkCore;
using TrainingScheduler.DAL.Common.Models;

namespace TrainingScheduler.DAL.Contexts
{
    public class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<TrainingArchive> TrainingArchives { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TrainingArchive>()
                .HasOne(c => c.User)
                .WithMany(x => x.TrainingArchives)
                .IsRequired()
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>().HasIndex(n => n.Name).IsUnique();
            modelBuilder.Entity<Exercise>().HasIndex(n => n.Name).IsUnique();
        }
    }
}