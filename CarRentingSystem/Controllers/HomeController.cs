using CarRentingSystem.Data;
using CarRentingSystem.Models;
using CarRentingSystem.Models.Cars;
using CarRentingSystem.Models.Home;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace CarRentingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarRentingDbContext db;

        public HomeController(CarRentingDbContext data)
        {
            this.db = data;
        }
        public IActionResult Index()
        {
            var totalCars = this.db.Cars.Count();

            var cars = this.db
                .Cars
                .OrderByDescending(x => x.Id)
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    ImageUrl = x.ImageUrl,
                    Year = x.Year
                })
                .Take(3)
                .ToList();

            return View(new IndexViewModel
            {
                TotalCars = totalCars,
                Cars = cars
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
