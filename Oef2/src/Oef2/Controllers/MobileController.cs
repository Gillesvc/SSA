using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oef2.Models;
using Oef2.DataAccess.Repositories;

namespace Oef2.Controllers{
    public class MobileController : Controller {
        private SessionRepository _sessionRepository;
        private RegistrationRepository _registerRepository;
        private OrganizationRepository _organizationRepository;
        private DeviceRepository _deviceRepository;
        public MobileController(SessionRepository sessionRepository, RegistrationRepository registrationRepository, OrganizationRepository organizationRepository, DeviceRepository deviceRepository) {
            this._sessionRepository = sessionRepository;
            this._registerRepository = registrationRepository;
            this._organizationRepository = organizationRepository;
            this._deviceRepository = deviceRepository;
        }
        // GET: /<controller>/
       
        [HttpGet]
        [Route("api/sessions")]
        public IActionResult GetSessions() {
            //internal server error voorkomen
            try { 
                List<Session> all = new List<Session>();
                all = _sessionRepository.GetSessions();
                return Ok(all);
            } catch (Exception) {
                return new StatusCodeResult(500);
            }
        }
        [HttpGet]
        [Route("api/sessions/slot/{slot}")]
        public IActionResult GetSessionid(int slot) {
            try {
                if (slot <= 0) return BadRequest();
               var sess =  _sessionRepository.GetSessions(slot);
                if (sess == null || sess.Count == 0) return NotFound();
                return Ok(sess);
            } catch (Exception) {
                return new StatusCodeResult(400);
            }
           
        }
        [HttpGet]
        [Route("api/registrations")]
        public IActionResult GetRegistrations() {
            try {
                return Ok(_registerRepository.GetRegistrations());
            } catch (Exception) {
                return new StatusCodeResult(500);
            }
        }


        [HttpGet]
        [Route("api/organizations")]
        public IActionResult GetOrg() {
            try {
                return Ok(_organizationRepository.GetOrganizations());
            } catch (Exception) {

                return new StatusCodeResult(500);
            }
        }
        

        /* De methode AddORganizations nog aanmaken
        [HttpPost]
        [Route("api/organizations")]
        //weet hij dat data moet opzoeken in body van httprequest
        public IActionResult AddOrg([FromBody] Organization orgz) {
            try {
                if (orgz == null) return BadRequest();

                _organizationRepository.AddOrganization(orgz);
                string url = string.Format("{0}://{1}/api/organizations/{2}", Request.Scheme, Request.Host, orgz.Id);
                return Created(url, orgz);

            } catch (Exception) {
                return new StatusCodeResult(500);
                
            }
        }*/

        [HttpGet]
        [Route("api/organization/{id}")]
        public IActionResult GetOrganization(int id) {
            try {
                return Ok(_organizationRepository.GetOrganization(id));
            } catch (Exception) {

                return new StatusCodeResult(500);
            }
        }

        [HttpDelete]
        [Route("api/organization/{organId}")]
        public IActionResult DelOrganization([FromRoute]int? organId) {
            return null;
            //try {
            //    if (organId == null) return BadRequest();
                
                
            //} catch (Exception) {

            //    return new StatusCodeResult(500);
            //}
        }
    }
}
