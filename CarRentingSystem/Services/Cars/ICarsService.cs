using CarRentingSystem.Models.Cars;
using System.Collections.Generic;

namespace CarRentingSystem.Services.Cars
{
    public interface ICarsService
    {
        CarQueryServiceModel All(
            string brand,
            string searchTerm,
            CarSorting sorting,
            int currentPage,
            int carsPerPage);

        IEnumerable<string> AllCarBrands();
    }
}
