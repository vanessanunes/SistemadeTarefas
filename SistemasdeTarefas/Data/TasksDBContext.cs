using Microsoft.EntityFrameworkCore;
using SistemasdeTarefas.Data.Map;
using SistemasdeTarefas.Models;

namespace SistemasdeTarefas.Data
{
    public class TasksDBContext : DbContext
    {
        public TasksDBContext(DbContextOptions<TasksDBContext> options)
            : base(options)
        {
        }
        public DbSet<UserModel> Users { get; set;}
        public DbSet<TaskModel> Tasks { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());

            base.OnModelCreating(modelBuilder);

        }
    }
}
