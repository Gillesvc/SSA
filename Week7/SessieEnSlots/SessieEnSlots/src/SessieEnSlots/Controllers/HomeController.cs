using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SessieEnSlots.DataAccess.Repositories;

namespace SessieEnSlots.Controllers
{
    public class HomeController : Controller
    {
        private SessionRepository _sessionRepository;

        public HomeController(SessionRepository sessionRepository) {
            this._sessionRepository = sessionRepository;
        }

        public IActionResult Index()
        {
            ViewBag.Slot1 = _sessionRepository.GetSessions(1);
            ViewBag.Slot2 = _sessionRepository.GetSessions(2);
            ViewBag.Slot3 = _sessionRepository.GetSessions(3);
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
