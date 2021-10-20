#region using

using KSRepositories.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

#endregion

namespace KSRepositories.Db
{
    public class KonturStudentDbContext : DbContext
    {
        private readonly string connectionString;

        public KonturStudentDbContext(IConfiguration configuration)
        {
            connectionString = configuration["Postgres:ConnectionString"];
        }

        public KonturStudentDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(connectionString);
        }
    }
}