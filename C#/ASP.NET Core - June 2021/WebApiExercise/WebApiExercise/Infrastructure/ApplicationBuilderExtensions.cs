namespace WebApiExercise.Infrastructure
{
    using System.Linq;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using WebApiExercise.Data;
    using WebApiExercise.Data.Models;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder ApplyMigrations(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            var service = serviceScope.ServiceProvider;

            var dbContext = service.GetRequiredService<WebApiDbContext>();
            dbContext.Database.Migrate();

            SeedProducts(dbContext);

            return app;
        }

        private static void SeedProducts(WebApiDbContext dbContext)
        {
            if (dbContext.Products.Any())
            {
                return;
            }

            dbContext.Products.AddRange(new[]
            {
                new Product{Name ="First",Description = "First added",Quantity=14},
                new Product{Name ="Second",Description = "Second added",Quantity=5},
            });

            dbContext.SaveChanges();
        }
    }
}
