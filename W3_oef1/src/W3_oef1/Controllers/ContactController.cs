using CookieDemo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using W3_oef1.Models;

namespace W3_oef1.Controllers
{
    public class ContactController : Controller{
        private static List<Contact> _data = new List<Contact>();
        private static string REG_KEY;

        [HttpGet]
        public ActionResult Index() {
            ViewBag.Cookie = _data;
            return View();
        }
        [HttpPost]
        public ActionResult Save(Contact contacteer) {
            var registr = HttpContext.Session.GetObject<List<Contact>>(REG_KEY);
            if (registr == null) {
                List<Contact> list = new List<Models.Contact>();
                list.Add(contacteer);
                HttpContext.Session.SetObject<List<Contact>>(REG_KEY, list);
            } else {
                registr.Add(contacteer);
                HttpContext.Session.SetObject<List<Contact>>(REG_KEY, registr);
            }

            //response.cookies.Append(ALREADY_REG, "done");
            return View();
        }
        [HttpGet]
        public ActionResult Detail(int burb) {
            Contact cinfo = _data.Find(c => c.ContactInfoId == burb);
            return View(cinfo);
        }
    }
}
