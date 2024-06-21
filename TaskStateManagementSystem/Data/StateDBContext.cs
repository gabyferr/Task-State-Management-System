using Microsoft.EntityFrameworkCore;
using TaskStateManagementSystem.State;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace TaskStateManagementSystem.Data
    //Cria o Banco APpartir do Entity
{
    public class StateDBContext : DbContext
    {
        public StateDBContext(DbContextOptions<StateDBContext> options) : base(options) { }
        public DbSet<TaskStateSystemModel> TaskStateSystemModel { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskStateSystemModel>().Property(t => t.State);

            base.OnModelCreating(modelBuilder);
        }
    }
}
