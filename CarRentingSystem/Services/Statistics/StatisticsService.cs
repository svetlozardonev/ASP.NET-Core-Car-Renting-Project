using CarRentingSystem.Data;
using System.Linq;

namespace CarRentingSystem.Services.Statistics
{
    public class StatisticsService : IStatisticsService
    {
        private readonly CarRentingDbContext data;

        public StatisticsService(CarRentingDbContext data)
        {
            this.data = data;
        }
        public StatisticsServiceModel Total()
        {
            var totalUsers = this.data.Users.Count();
            var totalCars = this.data.Cars.Count();

            return new StatisticsServiceModel
            {
                TotalUsers = totalUsers,
                TotalCars = totalCars,
            };
        }
    }
}
