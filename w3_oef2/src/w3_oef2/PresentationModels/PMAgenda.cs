using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using w3_oef2.Models;

namespace w3_oef2.PresentationModels
{
    public class PMAgenda
    {
        public List<Session> Slot1 { get; set; }
        public List<Session> Slot2 { get; set; }
        public List<Session> Slot3 { get; set; }
    }
}
