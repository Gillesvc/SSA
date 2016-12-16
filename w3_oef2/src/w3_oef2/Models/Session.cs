using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace w3_oef2.Models
{
    public class Session
    {
        public string Description { get; internal set; }
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public int Slot { get; internal set; }
    }
}
