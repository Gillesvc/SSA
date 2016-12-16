using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using w3_oef2.Models;
using w3_oef2.PresentationModels;
using Oefening_2;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace w3_oef2.Controllers
{
    public class AgendaController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
           
            PMAgenda pm = new PMAgenda();
            pm.Slot1 = Data.GetSessions(1);
            pm.Slot2 = Data.GetSessions(2);
            pm.Slot3 = Data.GetSessions(3);
            return View(pm);
        }
        public ActionResult Show()
        {
            return null;
        }
        public ActionResult Detail(int? koekoek)
        {
            return null;
        }
    }
}
