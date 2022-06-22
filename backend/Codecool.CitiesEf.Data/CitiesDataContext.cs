using Codecool.CitiesEf.Data.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.CitiesEf.Data
{
    public class CitiesDataContext :DbContext
    {
        public DbSet<City>? Cities { get; set; }
        public DbSet<PointOfInterest>? PointOfInterests { get; set; }
        public CitiesDataContext(DbContextOptions<CitiesDataContext> options)
         : base(options)
        {
        }
    }
}
