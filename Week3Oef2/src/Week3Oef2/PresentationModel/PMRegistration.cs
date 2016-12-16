using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week3Oef2.Models;

namespace Week3Oef2.PresentationModel
{
    public class PMRegistration
    {
        //in te vullen door de gebruiker
        public Registration NewRegistration { get; set; }

        //nodig om de lijsten op te vullen
        public List<SelectListItem> Slot1 { get; set; }
        public List<SelectListItem> Slot2 { get; set; }
        public List<SelectListItem> Slot3 { get; set; }

        public List<SelectListItem> Organisations { get; set; }

        public List<Device> Devices { get; set; }
    }
}
