using Microsoft.EntityFrameworkCore;
using TrainingManagement.Models;

namespace TrainingManagement.Context
{
    public class TrainingDbContext:DbContext
    {
        public TrainingDbContext()
        {

        }

        public TrainingDbContext(DbContextOptions<TrainingDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Batch> Batches { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<TrainingManagement.Models.BatchViewModel>? BatchViewModel { get; set; }
        //public DbSet<Batch> Batches { get; set; }

        //public DbSet<Course> Courses { get; set; }
        //public DbSet<Request>Requests { get; set; }
    }
}
