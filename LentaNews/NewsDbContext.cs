using Microsoft.EntityFrameworkCore;

namespace LentaNews
{
    public class NewsDbContext : DbContext
    {
        public const string Connection = "Data Source=(localdb)\\MSSQLLocalDB;" +
                                         "Database=LentaNews;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Connection);
        }

        public DbSet<NewsModel> News { get; set; }
    }
}