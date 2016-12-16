using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Week3Oef2.Models;
using Week3Oef2.PresentationModel;
using Microsoft.AspNetCore.Http;
using System.Net.Mail;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Week3Oef2.Controllers
{
    public class RegisterController : Controller
    {

        private static List<Registration> _user = new List<Registration>();
        private const string REG_KEY = "regkey";
        private const string ALREADY_REG = "alkey";

        // GET: /<controller>/
        public IActionResult Index()
        {
            PMRegistration pm = new PMRegistration();
            pm.NewRegistration = new Registration();
            pm.Slot1 = ConvertToSelectListItem(Data.GetSessions(1));
            pm.Slot2 = ConvertToSelectListItem(Data.GetSessions(2));
            pm.Slot3 = ConvertToSelectListItem(Data.GetSessions(3));

            pm.Organisations = ConvertOrganisationsToSelectListItem(Data.GetOrganizations());

            pm.Devices = ConvertDeviceToSelectListItem(Data.GetDevices());

            return View(pm);
        }

        private List<SelectListItem> ConvertToSelectListItem(List<Session> list) {

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var session in list) {

                items.Add(new SelectListItem() { Text = session.Name, Value = session.Id.ToString() });
            }
            return items;
        }

        private List<Device> ConvertDeviceToSelectListItem(List<Device> list) {

            List<Device> items = new List<Device>();
            foreach (var device in list) {

                items.Add(new Device() { Name = device.Name , Id = device.Id });
            }
            return items;
        }

        private List<SelectListItem> ConvertOrganisationsToSelectListItem(List<Organization> list) {

            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var organisation in list) {

                items.Add(new SelectListItem() { Text = organisation.Name, Value = organisation.Id.ToString() });
            }
            return items;
        }



        [HttpPost]
        public ActionResult Save(PMRegistration user) {
            List<PMRegistration> registrations = HttpContext.Session.GetObject<List<PMRegistration>>(REG_KEY);
            if (registrations == null)
            {
                List<PMRegistration> list = new List<PMRegistration>();
                list.Add(user);
                HttpContext.Session.SetObject<List<PMRegistration>>(REG_KEY, list);
            }
            else {
                registrations.Add(user);
                HttpContext.Session.SetObject<List<PMRegistration>>(REG_KEY, registrations);
            }
            Response.Cookies.Append(ALREADY_REG, "done");
            if (ModelState.IsValid) {
                // is valid dus mag opslaan;
                
                user.NewRegistration.Id = _user.Count + 1;
                _user.Add(user.NewRegistration);
                return RedirectToAction("Overview");
            } else {
                //eigelijk mogen we in theorie hier nooit komen: omdat we ook nog client validatie doet! bv hackers die via fiderl of als js uit ligt,..
                return View("Index", user);
            }

        }



        [HttpGet]
        public ActionResult Overview() {
            ViewBag.Contacts = _user[0];
            
            return View();
        }

       
    }
}
