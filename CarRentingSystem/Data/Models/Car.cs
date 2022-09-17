using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Data.Models
{
    using static Data.DataConstants;
    public class Car
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(CarBrandMaxLength)]
        public string Brand { get; set; }

        [Required]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; }

        [Required]
        [MaxLength(CarDescriptionMaxLength)]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int Year { get; set; }
        //public decimal RentPrice { get; set; }
        //public int RentingDays { get; set; }
        public IEnumerable<Review> Reviews { get; init; } = new List<Review>();
        public int DealerId { get; set; }
        public Dealer Dealer { get; set; }
    }
}
