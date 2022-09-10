using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Models.Cars
{
    using static Data.DataConstants;
    public class AddCarFormModel
    {

        [Required]
        [StringLength(CarBrandMaxLength,
            MinimumLength = CarBrandMinLength)]
        public string Brand { get; init; }

        [Required]
        [StringLength(CarModelMaxLength,
            MinimumLength = CarModelMinLength)]
        public string Model { get; init; }

        [Required]
        [StringLength(CarDescriptionMaxLength,
            MinimumLength = CarDescriptionMinLength,
            ErrorMessage = "Your description must be between {2} - {1} length.")]
        public string Description { get; init; }

        [Display(Name = "Image URL")]
        [Url]
        [Required(ErrorMessage = "You must enter a valid URL!")]
        public string ImageUrl { get; init; }

        [Range(CarMinYear, CarMaxYear)]
        public int Year { get; init; }
    }
}