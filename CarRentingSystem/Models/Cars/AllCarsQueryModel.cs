using System.Collections.Generic;

namespace CarRentingSystem.Models.Cars
{
    public class AllCarsQueryModel
    {
        public IEnumerable<string> Brands { get; init; }
        public string SearchTerm { get; init; }
        public CarSorting Sorting { get; init; }
        public IEnumerable<ListingCarViewModel> Cars { get; init; }
    }
}
