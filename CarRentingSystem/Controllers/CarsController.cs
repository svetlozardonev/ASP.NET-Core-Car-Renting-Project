using CarRentingSystem.Data;
using CarRentingSystem.Data.Models;
using CarRentingSystem.Models.Cars;
using Microsoft.AspNetCore.Mvc;

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

            return RedirectToAction("Index", "Home");
        }
    }
}
