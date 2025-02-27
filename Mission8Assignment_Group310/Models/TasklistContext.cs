using Microsoft.EntityFrameworkCore;

namespace Mission8Assignment_Group310.Models
{
    public class TasklistContext : DbContext
    {
        public TasklistContext(DbContextOptions<TasklistContext> options) : base(options) { } //Constructor

        public DbSet<Task> Tasks { get; set; }
    }

}

