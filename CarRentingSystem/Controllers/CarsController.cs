using CarRentingSystem.Data;
using CarRentingSystem.Data.Models;
using CarRentingSystem.Infrastructure;
using CarRentingSystem.Models.Cars;
using CarRentingSystem.Services.Cars;
using CarRentingSystem.Services.Dealers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarRentingSystem.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarRentingDbContext db;
        private readonly IDealerService dealers;
        private readonly ICarsService cars;

        public CarsController(
            CarRentingDbContext data,
            IDealerService dealer,
            ICarsService cars)
        {
            this.db = data;
            this.dealers = dealer;
            this.cars = cars;
        }

        [Authorize]
        public IActionResult Add()
        {
            if (!this.dealers.IsDealer(this.User.GetId()))
            {
                return RedirectToAction("Create", "Dealers");
            }

            return View();
        }


        [HttpPost]
        [Authorize]
        public IActionResult Add(AddCarFormModel car)
        {
            var dealerId = this.db
                .Dealers
                .Where(d => d.UserId == this.User.GetId())
                .Select(d => d.Id)
                .FirstOrDefault();

            if (dealerId == 0)
            {
                return RedirectToAction("Create", "Dealers");
            }

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
                Year = car.Year,
                DealerId = dealerId
            };

            this.db.Cars.Add(carData);
            this.db.SaveChanges();

            return RedirectToAction(nameof(All));
        }

        public IActionResult All([FromQuery]AllCarsQueryModel query)
        {
            var queryResult = this.cars.All(
                query.Brand, 
                query.SearchTerm, 
                query.Sorting, 
                query.CurrentPage, 
                AllCarsQueryModel.CarsPerPage);

            var carBrands = this.cars.AllCarBrands();

            query.Brands = carBrands;
            query.Cars = queryResult.Cars;
            query.TotalCars = queryResult.TotalCars;

            return View(query);
        }

        [Authorize]
        public IActionResult MyCars()
        {
            var myCars = this.cars.MyCars(this.User.GetId());

            return View(myCars);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            if (!this.dealers.IsDealer(this.User.GetId()))
            {
                return RedirectToAction("Create", "Dealers");
            }

            var car = this.cars.Details(id);

            if (car.UserId != this.User.GetId())
            {
                return Unauthorized();
            }

            return View(new AddCarFormModel 
            {
                Brand = car.Brand,
                Model = car.Model,
                Description = car.Description,
                Year = car.Year,
                ImageUrl = car.ImageUrl
            });
        }

        [HttpPost]
        [Authorize]
        public IActionResult Edit(int id, AddCarFormModel car)
        {
            var dealerId = this.db
                .Dealers
                .Where(d => d.UserId == this.User.GetId())
                .Select(d => d.Id)
                .FirstOrDefault();

            if (dealerId == 0)
            {
                return RedirectToAction("Create", "Dealers");
            }

            if (!ModelState.IsValid)
            {
                return View(car);
            }

            var carEdited = this.cars.Edit
                (
                id,
                car.Brand,
                car.Model,
                car.Description,
                car.ImageUrl,
                car.Year,
                dealerId
                );

            if (!carEdited)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(All));
        }
        
    }
}
