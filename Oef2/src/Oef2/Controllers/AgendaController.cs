using Microsoft.AspNetCore.Mvc;
using Oef2.DataAccess.Repositories;
using Oef2.Models;
using Oef2.PresentationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oef2.Controllers{
    public class AgendaController: Controller {
        private SessionRepository _sessionRepository;
        public AgendaController(SessionRepository sessionRepository) {
            this._sessionRepository = sessionRepository;
        }
        [HttpGet]
        public ActionResult Index() {
            PMAgenda pm = new PMAgenda();
            pm.Slot1 = _sessionRepository.GetSessions(1);
            pm.Slot2 = _sessionRepository.GetSessions(2);
            pm.Slot3 = _sessionRepository.GetSessions(3);
            return View(pm);
        }
        [HttpGet]
        public ActionResult Detail(int? damn) {
            //id niet leeg, geldig & anders terug
            if(damn == null) {
                return RedirectToAction("Index");
            }
            
            Session det = _sessionRepository.FindSession(damn.Value);
            if(det == null) return RedirectToAction("Index");
            return View(det);
            
            }
    }
}
