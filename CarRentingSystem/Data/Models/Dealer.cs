using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Data.Models
{
    using static Data.DataConstants;
    public class Dealer
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(DealerNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DealerPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; }

        [Required]
        public string UserId { get; set; }
        //public IdentityUser User { get; set; }
        public IEnumerable<Car> Cars { get; init; } = new List<Car>();
    }
}
