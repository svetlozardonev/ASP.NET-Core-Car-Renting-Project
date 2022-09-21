using CarRentingSystem.Data;
using CarRentingSystem.Data.Models;
using CarRentingSystem.Models.Cars;
using CarRentingSystem.Services.Cars;
using System.Collections.Generic;
using System.Linq;

namespace CarRentingSystem.Models.Api.Cars
{
    public class CarService : ICarsService
    {
        private readonly CarRentingDbContext data;

        public CarService(CarRentingDbContext data)
        {
            this.data = data;
        }
        public CarQueryServiceModel All(
            string brand, 
            string searchTerm, 
            CarSorting sorting, 
            int currentPage,
            int carsPerPage)
        {
            var carsQuery = this.data.Cars.AsQueryable();

            if (!string.IsNullOrWhiteSpace(brand))
            {
                carsQuery = carsQuery.Where(c => c.Brand == brand);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                carsQuery = carsQuery.Where(s => s.Brand.ToLower().Contains(searchTerm.ToLower()));
            }

            var totalCars = carsQuery.Count();

            carsQuery = sorting switch
            {
                CarSorting.Year => carsQuery.OrderByDescending(c => c.Year),
                CarSorting.DateCreated or _ => carsQuery.OrderByDescending(c => c.Id)
            };

            var cars = GetCars(carsQuery
                .Skip((currentPage - 1) * carsPerPage)
                .Take(carsPerPage));

            return new CarQueryServiceModel
            {
                TotalCars = totalCars,
                CurrentPage = currentPage,
                CarsPerPage = carsPerPage,
                Cars = cars
            };
        }
        public IEnumerable<CarServiceModel> MyCars(string userId)
        {
            return this.GetCars(this.data.Cars
                .Where(c => c.Dealer.UserId == userId));
        }

        public IEnumerable<string> AllCarBrands()
        {
            return this.data
                .Cars
                .Select(c => c.Brand)
                .Distinct()
                .OrderBy(br => br)
                .ToList();
        }

        private IEnumerable<CarServiceModel> GetCars(IQueryable<Car> carQuery)
        {
            return carQuery.Select(c => new CarServiceModel
            {
                Id = c.Id,
                Brand = c.Brand,
                Model = c.Model,
                ImageUrl = c.ImageUrl,
                Year = c.Year
            })
            .ToList();
        }

        public CarDetailsServiceModel Details(int carId)
        {
            return this.data.Cars
                .Where(c => c.Id == carId)
                .Select(c => new CarDetailsServiceModel
                {
                    Id = c.Id,
                    Brand = c.Brand,
                    Model = c.Model,
                    Description = c.Description,
                    ImageUrl = c.ImageUrl,
                    Year = c.Year,
                    DealerId = c.DealerId,
                    UserId = c.Dealer.UserId
                }).FirstOrDefault();
        }

        public bool Edit(int id, string brand, string model, string description, string imageUrl, int year, int dealerId)
        {
            var carData = this.data.Cars.Find(id);

            if (carData.DealerId != dealerId)
            {
                return false;
            }

            carData.Brand = brand;
            carData.Model = model;
            carData.Description = description;
            carData.ImageUrl = imageUrl;
            carData.Year = year;

            this.data.SaveChanges();

            return true;
        }
    }
}
