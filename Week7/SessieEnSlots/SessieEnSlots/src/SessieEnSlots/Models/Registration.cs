

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SessieEnSlots.Models {
    public class Registration
    {
        [Required]
        [MaxLength(50)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Firstname")]
        public string FirstName { get; set; }

        [Required]
        [Range(18, 120)]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public int Slot1 { get; set; }
        [Required]
        public int Slot2 { get; set; }
        [Required]
        public int Slot3 { get; set; }

        [DisplayName("Are you coming to the closing party ?")]
        public bool ClosingParty { get; set; }

        [DisplayName("Laptop")]
        public bool IWearGun { get; set; }
        [DisplayName("Tablet")]
        public bool IWearProtableRocketLauncher { get; set; }
        [DisplayName("Apple Watch")]
        public bool IWearAppleWatch { get; set; }

        [Required]
        [DisplayName("Organization")]
        public int OrganizationId { get; set; }


    }
}