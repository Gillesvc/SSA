using Oefening_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using w02p02Oplossing.Models;
using w02p02Oplossing.PresentationModels;

namespace w02p02Oplossing.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            PMIndex pm = new PMIndex();
            pm.Slot1 = Data.GetSessions(1);
            pm.Slot2 = Data.GetSessions(2);
            pm.Slot3 = Data.GetSessions(3);
            return View(pm);
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");

            Session s = null;
            s = Data.GetSession(id.Value);

            if(Data.FindSession(id.Value) == null)  //Bij nullable types moet je .value achter plaatsen.
            {
                return View("KanSessieNietVinden");
            }
            return View(s);
        }

        [HttpGet]
        public ActionResult Register()
        {
            PMRegistration pm = new PMRegistration();
            pm.Slot1 = new SelectList(Data.GetSessions(1), "Id", "Name");
            pm.Slot2 = new SelectList(Data.GetSessions(2), "Id", "Name");
            pm.Slot3 = new SelectList(Data.GetSessions(3), "Id", "Name");
            pm.Organizations = new SelectList(Data.GetOrganizations(), "Id", "Name");
            return View(pm);
        }

        [HttpPost]

        public ActionResult Register(PMRegistration r)
        {
            if (ModelState.IsValid)
            {
                Data.AddRegistration(r.NewRegistration);
                return RedirectToAction("Index");
            }
            else
            {
                r.Slot1 = new SelectList(Data.GetSessions(1), "Id", "Name");
                r.Slot2 = new SelectList(Data.GetSessions(2), "Id", "Name");
                r.Slot3 = new SelectList(Data.GetSessions(3), "Id", "Name");
                r.Organizations = new SelectList(Data.GetOrganizations(), "Id", "Name");
                return View(r);
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}