using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oef2.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Oef2.Controllers
{
    public class MobileController : Controller {
        // GET: /<controller>/
       
        [HttpGet]
        [Route("api/sessions")]
        public IActionResult GetSessions() {
            //internal server error voorkomen
            try { 
                List<Session> all = new List<Session>();
                all.AddRange(Data.GetSessions(1));
                all.AddRange(Data.GetSessions(2)); all.AddRange(Data.GetSessions(3));
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
               List<Session> sess =  Data.GetSessions(slot);
                if (sess == null || sess.Count == 0) return NotFound();
                return Ok(sess);
            } catch (Exception) {
                return new StatusCodeResult(400);
            }
           
        }

        [HttpGet]
        [Route("api/organizations")]
        public IActionResult GetOrg() {
            try {
                return Ok(Data.GetOrganizations());
            } catch (Exception) {

                return new StatusCodeResult(500);
            }
        }
        [HttpGet]
        [Route("api/registrations")]
        public IActionResult GetRegistrations() {
           
            try {
                return Ok(Data.GetRegistrations());
            } catch (Exception) {
                return new StatusCodeResult(500);
            }
        }

        [HttpPost]
        [Route("api/organizations")]
        //weet hij dat data moet opzoeken in body van httprequest
        public IActionResult AddOrg([FromBody] Organization orgz) {
            try {
                if (orgz == null) return BadRequest();

                Data.AddOrganisation(orgz);
                string url = string.Format("{0}://{1}/api/organizations/{2}", Request.Scheme, Request.Host, orgz.Id);
                return Created(url, orgz);

            } catch (Exception) {
                return new StatusCodeResult(500);
                
            }
        }

        [HttpGet]
        [Route("api/organization/{id}")]
        public IActionResult GetOrganization(int id) {
            try {
                return Ok(Data.GetOrganization(id));
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
