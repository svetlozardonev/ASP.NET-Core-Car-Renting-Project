using CarRentingSystem.Models.Api.Cars;
using CarRentingSystem.Services.Cars;
using Microsoft.AspNetCore.Mvc;

namespace CarRentingSystem.Controllers.Api
{
    [Route("api/cars")]
    [ApiController]
    public class CarsApiController : ControllerBase
    {
        private readonly ICarsService cars;

        public CarsApiController(ICarsService cars)
        {
            this.cars = cars;
        }

        [HttpGet]
        public CarQueryServiceModel All([FromQuery] AllCarsApiRequestModel query)
        {
            return this.cars.All(query.Brand,
                query.SearchTerm,
                query.Sorting, query.CurrentPage,
                query.CarsPerPage);

        }
    }
}
