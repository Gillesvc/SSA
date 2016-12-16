using Microsoft.AspNetCore.Mvc;
using Oef2.Models;
using Oef2.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oef2.Controllers{
    public class AgendaController: Controller {
        [HttpGet]
        public ActionResult Index() {
            PMAgenda pm = new PMAgenda();
            pm.Slot1 = Data.GetSessions(1);
            pm.Slot2 = Data.GetSessions(2);
            pm.Slot3 = Data.GetSessions(3);
            return View(pm);
        }
        [HttpGet]
        public ActionResult Detail(int? damn) {
            //id niet leeg, geldig & anders terug
            if(damn == null) {
                return RedirectToAction("Index");
            }
            
            Session det = Data.FindSession(damn.Value);
            if(det == null) return RedirectToAction("Index");
            return View(det);
            
            }
    }
}
