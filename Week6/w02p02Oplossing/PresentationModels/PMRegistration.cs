using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using w02p02Oplossing.Models;

namespace w02p02Oplossing.PresentationModels
{
    public class PMRegistration
    {
        public PMRegistration()
        {
            NewRegistration = new Registration();
        }

        public Registration NewRegistration { get; set; }
        public SelectList Slot1 { get; set; }
        public SelectList Slot2 { get; set; }
        public SelectList Slot3 { get; set; }
        public SelectList Organizations { get; set; }

    }
}
