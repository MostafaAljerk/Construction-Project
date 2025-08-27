using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    public class ConstructionContext: DbContext
    {
        public DbSet<ConstructionProject> ConstructionProjects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<ResourceUsage> ResourcesUsage { get; set; }
        public DbSet<PaymentTransaction> PaymentTransactions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB ; Initial Catalog = ConstructionApp1_Cource19");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.ProjectTasks)
                .WithMany(Pt => Pt.Employees)
                .UsingEntity<EmployeeProjectTask>()
                .Property(et => et.CreateTime).HasDefaultValueSql("getDate()");
            
        }
    }
}
