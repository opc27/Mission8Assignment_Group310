using Microsoft.EntityFrameworkCore;

namespace Mission8Assignment_Group310.Models
{
    public class TasklistContext : DbContext
    {
        public TasklistContext(DbContextOptions<TasklistContext> options) : base(options) { } //Constructor

        public DbSet<Task> Tasks { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, CategoryName = "Home" },
                new Category { CategoryID = 2, CategoryName = "School" },
                new Category { CategoryID = 3, CategoryName = "Work" },
                new Category { CategoryID = 4, CategoryName = "Church" }
            );
        }


    }

}

