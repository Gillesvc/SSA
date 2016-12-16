using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Oef2.Models{
    public class Registration{
        public int RegisterId { get; set; }

        [Required(ErrorMessage = "Het veld Naam is vereist")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "Het veld Voornaam is vereist")]
        public string Voornaam { get; set; }

        public int Leeftijd { get; set; }
        [Required(ErrorMessage = "Het veld Email is vereist")]
        [EmailAddress]
        public string Email { get; set; }



        public int SelectedSlot1 { get; set; }
        public int SelectedSlot2 { get; set; }
        public int SelectedSlot3 { get; set; }


        public int SelectedOrganization { get; set; }
        public bool ClosingParty { get; set; }
        public int[] Accessoires { get; set; }

    }
}
