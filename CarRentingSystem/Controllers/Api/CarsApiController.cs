using CarRentingSystem.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarRentingSystem.Controllers.Api
{
    [Route("api/cars")]
    [ApiController]
    public class CarsApiController : ControllerBase
    {
        private readonly CarRentingDbContext db;

        public CarsApiController(CarRentingDbContext data)
        {
            this.db = data;
        }
    }
}
