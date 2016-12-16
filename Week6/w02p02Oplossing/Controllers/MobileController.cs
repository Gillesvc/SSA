using Newtonsoft.Json;
using Oefening_2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using w02p02Oplossing.Models;

namespace w02p02Oplossing.Controllers
{
    public class MobileController : ApiController
    {
        [HttpGet]
        [Route("api/sessions")]
        public List<Session> GetSessions()
        {
            List<Session> all = new List<Session>();
            all.AddRange(Data.GetSessions(1));
            all.AddRange(Data.GetSessions(2));
            all.AddRange(Data.GetSessions(3));

            return all;
        }

        [HttpGet]
        [Route("api/sessions/slot/{slot}")]
        public List<Session> GetFirstSession(int slot)
        {
            return Data.GetSessions(slot);
        }

        [HttpGet]
        [Route("api/organizations")]
        public List<Organization> GetOrganisations()
        {
            return Data.GetOrganizations();
        }

        [HttpGet]
        [Route("api/organizations/{idnull}")]
        public HttpResponseMessage GetOrganization(int? idnull)
        {
            if (idnull == null) return new HttpResponseMessage(HttpStatusCode.NoContent);

            int id = Convert.ToInt32(idnull);
            if (Data.GetOrganization(id) == null) return new HttpResponseMessage(HttpStatusCode.InternalServerError);

            Organization org = Data.GetOrganization(id);
            String json = JsonConvert.SerializeObject(org);

            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(json);
            return response;
        }

        [HttpPost]
        [Route("api/organizations")]
        public HttpResponseMessage AddOrganisation(Organization org)
        {
            if (org == null) return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            Data.AddOrganization(org);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpDelete]
        [Route("api/organizations/{orgidn}")]
        public HttpResponseMessage DeleteOrganizations(int? orgidn)
        {
            if (orgidn == null) return new HttpResponseMessage(HttpStatusCode.NoContent);
            int orgid = Convert.ToInt32(orgidn);

            if (Data.GetOrganization(orgid) == null) return new HttpResponseMessage(HttpStatusCode.BadRequest);
            Data.DeleteOrganizations(orgid);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPut]
        [Route("api/organizations/{orgidnull}")]
        public HttpResponseMessage UpdateOrganization(int? orgidnull, Organization org)
        {
            if (orgidnull == null) return new HttpResponseMessage(HttpStatusCode.NoContent);
            int orgid = Convert.ToInt32(orgidnull);

            if (Data.GetOrganization(orgid) == null) return new HttpResponseMessage(HttpStatusCode.BadGateway);

            Data.DeleteOrganizations(orgid);
            Data.AddOrganization(org);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [HttpGet]
        [Route("api/registrations")]
        public List<Registration> GetRegistrations()
        {
            return Data.GetRegistrations();
        }

        [HttpPost]
        [Route("api/organizations")]
        public IActionResult AddOrganization([FromBody]Organization org) {
            try
            {
                if (org == null)
                {
                    return BadRequest();
                }
                Data.AddOrganization(org);
                string url = string.Format("{0}://{1}/api/organization{2}", Request.Scheme, Request.Host, org.Id);
                return Created(url, org);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(500);
            }
        }

    }
}
