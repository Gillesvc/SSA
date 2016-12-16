using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week3Oef2.Models;

namespace Week3Oef2.PresentationModel
{
    public class PMAgenda
    {
        public List<Session> Slot1 { get; set; }
        public List<Session> Slot2 { get; set; }
        public List<Session> Slot3 { get; set; }
    }
}
