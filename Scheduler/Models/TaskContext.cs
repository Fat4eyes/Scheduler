using System.Data.Entity;

namespace Scheduler.Models
{
    public class TaskContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
    }
}