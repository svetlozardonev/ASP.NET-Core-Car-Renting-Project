using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Data.Models
{
    using static Data.DataConstants;
    public class Review
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(ReviewTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(ReviewContentMaxLength)]
        public string Content { get; set; }
        public string CarId { get; set; }
        public Car Car { get; init; }
    }
}
