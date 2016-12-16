using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace w3_oef2.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public int SelectedSessionSlot1 { get; set; }
        public int SelectedSessionSlot2 { get; set; }
        public int SelectedSessionSlot3 { get; set; }

        public int SelectedOrganizationId { get; set; }

        public bool MyProperty { get; set; }
    }
}
