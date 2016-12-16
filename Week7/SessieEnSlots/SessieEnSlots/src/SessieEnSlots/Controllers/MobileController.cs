using Microsoft.AspNetCore.Mvc;
using SessieEnSlots.DataAccess;
using SessieEnSlots.DataAccess.Repositories;
using SessieEnSlots.Models;
using System;
using System.Collections.Generic;

namespace SessieEnSlots.Controllers {
    public class MobileController : Controller {

        private SessionRepository _sessionRepository;

        public MobileController(SessionRepository sessionRepository) {
            this._sessionRepository = sessionRepository;
        }


        [HttpGet]
        [Route("api/sessions")]
        public List<Session> GetSessions() {
            List<Session> all = new List<Session>();
            all = _sessionRepository.GetSessions();
            return all;
        }

        [HttpGet]
        [Route("api/sessions/slot/{id}")]
        public IActionResult GetSessions(int id) {

            try {
                if (id <= 0) {
                    return BadRequest();
                }
                var sessions = _sessionRepository.GetSessions(id);
                if (sessions == null || sessions.Count == 0)
                    return NotFound();

                return new JsonResult(sessions);
            }
            catch (Exception ex) {
                //logging
                return new StatusCodeResult(500);
            }

        }

        [HttpGet]
        [Route("api/organization/{id}")]
        public IActionResult GetOrganization(int id) {
            var org = Data.GetOrganization(id);
            if (org == null)
                return NotFound();
            return Ok(org);
        }

        [HttpDelete]
        [Route("api/organization/{id}")]
        public IActionResult DeleteOrganization(int id) {
            try {
                Organization org = Data.GetOrganization(id);
                if (org == null) {
                    return NotFound();
                }
               
                Data.DeleteOrganization(org);
                return Ok();
            }
            catch (Exception ex) {
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [Route("api/organizations/")]
        public IActionResult AddOrganization([FromBody]Organization org) {

            try {
                if (org == null)
                    return BadRequest();


                Data.AddOrganization(org);
                string url = string.Format("{0}://{1}/api/organization/{2}", Request.Scheme, Request.Host, org.Id);
                return Created(url, org);
            }
            catch (Exception ex) {
                return new StatusCodeResult(500);
            }
        }

        [HttpGet]
        [Route("api/organizations/")]
        public IActionResult GetOrganizations() {
            return new JsonResult(Data.GetOrganizations());
        }
    }
}
