using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Week3Oef2.Models
{
    public class Registration
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Verplicht")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Verplicht")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Verplicht")]
        public int Age { get; set; }

        [EmailAddress(ErrorMessage = "Geen geldig mail adres")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Verplicht")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Verplicht")]
        public int Slot1Id { get; set; }

        [Required(ErrorMessage = "Verplicht")]
        public int Slot2Id { get; set; }

        [Required(ErrorMessage = "Verplicht")]
        public int Slot3Id { get; set; }

        // public bool Laptop { get; set; }
        // public bool Tablet { get; set; }
        // public bool AppleWatch { get; set; }

        public int[] Accesoires { get; set; }

        [Required(ErrorMessage = "Verplicht")]
        public int OrganisationId { get; set; }

        public bool CommingToParty { get; set; }
    }
}
