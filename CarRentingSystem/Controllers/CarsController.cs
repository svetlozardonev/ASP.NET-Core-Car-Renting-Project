using CarRentingSystem.Data;
using CarRentingSystem.Data.Models;
using CarRentingSystem.Models.Cars;
using CarRentingSystem.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace CarRentingSystem.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarRentingDbContext db;

        public CarsController(CarRentingDbContext data)
        {
            this.db = data;
        }
        public IActionResult Add() => View();

        [HttpPost]
        public IActionResult Add(AddCarFormModel car)
        {
            if (!ModelState.IsValid)
            {
                return View(car);
            }

            var carData = new Car
            {
                Brand = car.Brand,
                Model = car.Model,
                Description = car.Description,
                ImageUrl = car.ImageUrl,
                Year = car.Year
            };

            this.db.Cars.Add(carData);
            this.db.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        public IActionResult All(string searchTerm)
        {
            var carsQuery = this.db.Cars.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                carsQuery = carsQuery.Where(s => s.Brand.ToLower().Contains(searchTerm.ToLower()));
            }

            var cars = carsQuery
                .OrderByDescending(x => x.Id)
                .Select(x => new ListingCarViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    ImageUrl = x.ImageUrl,
                    Year = x.Year
                })
                .ToList();
            

            return View(new AllCarsQueryModel
            {
                Cars = cars,
                SearchTerm = searchTerm
            });
        }
    }
}
