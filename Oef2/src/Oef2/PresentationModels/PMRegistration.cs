using Microsoft.AspNetCore.Mvc.Rendering;
using Oef2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oef2.PresentationModels{
    public class PMRegistration{
        //in te vullen door gebruiker
        public Registration newRegistration { get; set; }

        //Om lijsten op te vullen
        public List<SelectListItem> Slot1 { get; set; }
        public List<SelectListItem> Slot2 { get; set; }
        public List<SelectListItem> Slot3 { get; set; }
        public List<SelectListItem> Organizations { get; set; }
        public List<Device> Devices { get; set; }
    }
}
