using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codecool.CitiesEf.Data.Enities
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<PointOfInterest> PointOfInterests { get; set; } = new List<PointOfInterest>();
    }
}
