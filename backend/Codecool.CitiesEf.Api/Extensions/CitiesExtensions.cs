using Codecool.CitiesEf.Api.Model;
using Codecool.CitiesEf.Data.Enities;

namespace Codecool.CitiesEf.Api.Extensions
{
    public static class CitiesExtensions
    {
        public static CityViewModel ToCityView(this City city)
        {
            return new CityViewModel()
            {
                Id = city.Id,
                Name = city?.Name
            };
        }
        public static List<CityViewModel> ToCityView(this List<City> cities)
        {
            List<CityViewModel> result = new List<CityViewModel>();
            foreach (var city in cities)
            {
                result.Add(ToCityView(city));
            }
            return result;
        }
    }
}
