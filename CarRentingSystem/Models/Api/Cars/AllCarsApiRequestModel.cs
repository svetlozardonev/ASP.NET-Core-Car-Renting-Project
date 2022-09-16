using CarRentingSystem.Models.Cars;

namespace CarRentingSystem.Models.Api.Cars
{
    public class AllCarsApiRequestModel
    {
        public string Brand { get; init; }
        public CarSorting Sorting { get; init; }
        public string SearchTerm { get; init; }
        public int CurrentPage { get; set; } = 1;
        public int CarsPerPage { get; set; } = 10;
    }
}
