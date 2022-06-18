using Codecool.CitiesEf.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.CitiesEF.Test
{
    public class TestingWebAppFactory<T> : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContext = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CitiesDataContext>));
                if (dbContext != null)
                    services.Remove(dbContext);
                
                var serviceProvider = new ServiceCollection().AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                services.AddDbContext<CitiesDataContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryEmployeeTest");
                    options.UseInternalServiceProvider(serviceProvider);
                });
                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<CitiesDataContext>())
                    {
                        try
                        {
                            appContext.Database.EnsureDeleted();
                            appContext.Database.EnsureCreated();
                        }
                        catch (Exception ex)
                        {
                            //Log errors
                            throw;
                        }
                    }
                }
            });
        }
    }
}
