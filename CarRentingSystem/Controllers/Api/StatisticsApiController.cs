using CarRentingSystem.Data;
using CarRentingSystem.Models.Api.Statistics;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarRentingSystem.Controllers.Api
{
    [ApiController]
    [Route("api/statistics")]
    public class StatisticsApiController : ControllerBase
    {
        private readonly CarRentingDbContext data;
        public StatisticsApiController(CarRentingDbContext data)
            => this.data = data;

        [HttpGet]
        public StatisticsResponseModel GetStatistics()
        {
            var statistics = new StatisticsResponseModel
            {
                TotalCars = this.data.Cars.Count(),
                TotalUsers = 0
            };

            return statistics;
        }
    }
}
