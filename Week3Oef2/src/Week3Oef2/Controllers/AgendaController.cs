using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Week3Oef2.PresentationModel;
using Week3Oef2.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Week3Oef2.Controllers
{
    public class AgendaController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        public ActionResult Index()
        {
            PMAgenda pm = new PMAgenda();
            pm.Slot1 = Data.GetSessions(1);
            pm.Slot2 = Data.GetSessions(2);
            pm.Slot3 = Data.GetSessions(3);

            return View(pm);
        }

        public ActionResult Detail(int? koekkoek) {

            if (koekkoek == null)
                return RedirectToAction("Index");

            Session s = Data.FindSession(koekkoek.Value);
            if (s == null)
                return RedirectToAction("Index");

            return View(s);
        }

         


        [HttpGet]
        public ActionResult Show() {

            PMAgenda pm = new PMAgenda();
            pm.Slot1 = Data.GetSessions(1);
            pm.Slot2 = Data.GetSessions(2);
            pm.Slot3 = Data.GetSessions(3);

            return View(pm);
        }
    }
}
