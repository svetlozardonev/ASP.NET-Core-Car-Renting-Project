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

        bool Edit(
            int id,
            string brand,
            string model,
            string description,
            string imageUrl,
            int year,
            int dealerId
            );

        CarDetailsServiceModel Details(int carId);

        IEnumerable<CarServiceModel> MyCars(string userId);

        IEnumerable<string> AllCarBrands();
    }
}
