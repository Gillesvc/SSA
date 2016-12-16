using Microsoft.AspNetCore.Mvc;
using SessieEnSlots.DataAccess.Repositories;
using SessieEnSlots.Models;

namespace SessieEnSlots.Controllers {
    public class SessionController : Controller {
        private SessionRepository _sessionRepository;

        public SessionController(SessionRepository sessionRepository) {
            _sessionRepository = sessionRepository;
        }


        [HttpGet]
        public ActionResult Detail(int? id) {
            if (id == null)
                return View("Error");
            Session session = _sessionRepository.GetSession(id.Value);
            return View(session);
        }
    }
}
