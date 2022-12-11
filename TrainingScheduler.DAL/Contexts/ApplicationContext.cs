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
    }
}