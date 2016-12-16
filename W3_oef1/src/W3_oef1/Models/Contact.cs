using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace W3_oef1.Models { 
    public class Contact{
        public int ContactInfoId { get; set; }

        [Required(ErrorMessage = "Het veld Naam is vereist")]
        [StringLength(50, MinimumLength = 3)]
        public string Naam { get; set; }

        [Required(ErrorMessage = "Het veld Email is vereist")]
        [StringLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Het veld Bericht is vereist")]
        [StringLength(500)]
        public string Bericht { get; set; }

        public bool ContactMe { get; set; }
    }
}
