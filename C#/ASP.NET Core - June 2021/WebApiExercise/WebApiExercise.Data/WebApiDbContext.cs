namespace WebApiExercise.Data
{
    using Microsoft.EntityFrameworkCore;
    using WebApiExercise.Data.Models;

    public class WebApiDbContext : DbContext
    {
        
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }


}
