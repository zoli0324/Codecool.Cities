using Codecool.CitiesEf.Api.Model;
using Codecool.CitiesEf.Data;
using Codecool.CitiesEf.Data.Enities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Codecool.CitiesEf.Api.Extensions;

namespace Codecool.CitiesEf.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly CitiesDataContext citiesDataContext;

        public CitiesController(CitiesDataContext citiesDataContext)
        {
            this.citiesDataContext = citiesDataContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<City>> GetAll()
        {
            var result = citiesDataContext.Cities?.ToList().ToCityView();
             return Ok(result);
        }
    }
}
