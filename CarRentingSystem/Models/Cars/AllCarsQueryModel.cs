using System.Collections.Generic;

namespace CarRentingSystem.Models.Cars
{
    public class AllCarsQueryModel
    {
        public const int CarsPerPage = 8;
        public int CurrentPage { get; set; } = 1;
        public int TotalCars { get; set; }
        public string Brand { get; init; }
        public IEnumerable<string> Brands { get; set; }
        public string SearchTerm { get; init; }
        public CarSorting Sorting { get; init; }
        public IEnumerable<ListingCarViewModel> Cars { get; set; }
    }
}
