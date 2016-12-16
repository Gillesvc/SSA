using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace w02p02Oplossing.Models
{
    public class Registration
    {
        [Required]
        [DisplayName("Name")]
        [MaxLength(30)]
        public String Name { get; set; }
        [Required]
        [DisplayName("FirstName")]
        [MaxLength(30)]
        public String Firstname { get; set; }
        [Required]
        [DisplayName("Age")]
        [Range(1, 120)]
        public int Age { get; set; }
        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public String Email { get; set; }
        [Required]
        [DisplayName("Slot1")]
        public int Slot1 { get; set; }
        [Required]
        [DisplayName("Slot2")]
        public int Slot2 { get; set; }
        [Required]
        [DisplayName("Slot3")]
        public int Slot3 { get; set; }
        [Required]
        [DisplayName("Laptop")]
        public bool Laptop { get; set; }
        [Required]
        [DisplayName("Tablet")]
        public bool Tablet { get; set; }
        [Required]
        [DisplayName("Apple Watch")]
        public bool Watch { get; set; }
        [Required]
        [DisplayName("Organization")]
        public int SelectedOrganization { get; set; }
        [Required]
        [DisplayName("Are you coming to the closing party?")]
        public bool ClosingParty { get; set; }
    }
}
