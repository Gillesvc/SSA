using Microsoft.AspNetCore.Mvc;
using Oef2.Models;
using Oef2.PresentationModel;
using Oef2.PresentationModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Oef2.DataAccess.Repositories;

namespace Oef2.Controllers{
    public class RegisterController: Controller {
        private SessionRepository _sessionRepository;
        private RegistrationRepository _registerRepository;
        private OrganizationRepository _organizationRepository;
        private DeviceRepository _deviceRepository;
        public RegisterController(SessionRepository sessionRepository, RegistrationRepository registrationRepository, OrganizationRepository organizationRepository, DeviceRepository deviceRepository) {
            this._sessionRepository = sessionRepository;
            this._registerRepository = registrationRepository;
            this._organizationRepository = organizationRepository;
            this._deviceRepository = deviceRepository;
        }
        private static List<Registration> damn = new List<Registration>();

        [HttpGet]
        public ActionResult Index() {
            PMRegistration pm = new PMRegistration();
            pm.newRegistration = new Registration();
            pm.Slot1 = ConvertToSelectListItem(_sessionRepository.GetSessions(1));
            pm.Slot2 = ConvertToSelectListItem(_sessionRepository.GetSessions(2));
            pm.Slot3 = ConvertToSelectListItem(_sessionRepository.GetSessions(3));
            pm.Organizations = ConvertOrgToSelectListItem(_organizationRepository.GetOrganizations());
            pm.Devices = ConvertDeviceToSelectListItem(_deviceRepository.GetDevices());
            return View(pm);
        }

        private List<SelectListItem> ConvertToSelectListItem(List<Session> list) {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var sess in list) {
                items.Add(new SelectListItem() { Text = sess.Name, Value = sess.Id.ToString() });
            }
            return items;
        }
        private List<Device> ConvertDeviceToSelectListItem(List<Device> list) {
            List<Device> items = new List<Device>();
            foreach (var device in list) {
                items.Add(new Device() { Name = device.Name, Id= device.Id });
            }
            return items;
        }
        private List<SelectListItem> ConvertOrgToSelectListItem(List<Organization> list) {
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var org in list) {
                items.Add(new SelectListItem() { Text = org.Name, Value = org.Id.ToString() });
            }
            return items;
        }

        [HttpPost]
        public ActionResult Overview(PMRegistration pm) {
            if (ModelState.IsValid) {
                pm.newRegistration.RegisterId = damn.Count + 1;
                damn.Add(pm.newRegistration);

                return View("Overview", pm.newRegistration);
            } else {
                return View("Error");
            }
        }
       
    }
}
