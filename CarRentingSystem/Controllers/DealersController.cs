﻿using CarRentingSystem.Data;
using CarRentingSystem.Data.Models;
using CarRentingSystem.Infrastructure;
using CarRentingSystem.Models.Dealers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CarRentingSystem.Controllers
{
    public class DealersController : Controller
    {
        private readonly CarRentingDbContext data;

        public DealersController(CarRentingDbContext data)
        {
            this.data = data;
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(BecomeDealerFormModel dealer)
        {
            var userId = this.User.GetId();

            var userIdAlreadyDealer = this.data
                .Dealers
                .Any(d => d.UserId == userId);

            if (userIdAlreadyDealer)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(dealer);
            }

            var dealerData = new Dealer
            {
                Name = dealer.Name,
                PhoneNumber = dealer.PhoneNumber,
                UserId = userId,
            };

            this.data.Dealers.Add(dealerData);
            this.data.SaveChanges();

            return RedirectToAction("All", "Cars");
        }
    }
}
