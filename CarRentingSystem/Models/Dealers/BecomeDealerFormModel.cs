using System.ComponentModel.DataAnnotations;

namespace CarRentingSystem.Models.Dealers
{
    using static Data.DataConstants;
    public class BecomeDealerFormModel
    {
        [Required]
        [StringLength(DealerNameMaxLength, MinimumLength = DealerNameMinLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(DealerPhoneNumberMaxLength, MinimumLength = DealerPhoneNumberMinLength)]
        [Display(Name="Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
