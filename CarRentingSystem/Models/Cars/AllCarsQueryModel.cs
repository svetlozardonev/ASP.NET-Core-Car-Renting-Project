using CarRentingSystem.Services.Cars;
using System.Collections.Generic;

namespace CarRentingSystem.Models.Cars
{
    public class AllCarsQueryModel
    {
        public const int CarsPerPage = 8;

        public string Brand { get; init; }
        public CarSorting Sorting { get; init; }
        public string SearchTerm { get; init; }
        public int CurrentPage { get; set; } = 1;
        public int TotalCars { get; set; }
        public IEnumerable<string> Brands { get; set; }
        public IEnumerable<CarServiceModel> Cars { get; set; }
    }
}
