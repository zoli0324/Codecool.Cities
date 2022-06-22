using Codecool.CitiesEf.Data.Enities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.CitiesEf.Data
{
    public class CitiesSeed
    {
        private readonly CitiesDataContext context;

        public CitiesSeed(CitiesDataContext context)
        {
            this.context = context;
        }
        public void Seed()
        {
            context.Database.Migrate();
            if(!context.Cities.Any())
            {
                context.Cities.AddRange(
                    new City
                    {
                        Name = "Budapest",
                    },
                    new City
                    {
                        Name = "Praga",
                    });
                context.SaveChanges();
            }
        }
    }
}
