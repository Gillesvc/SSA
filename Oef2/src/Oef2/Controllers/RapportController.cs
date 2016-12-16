using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Oef2.Models;
using Microsoft.EntityFrameworkCore.Storage;
using Oef2.DataAccess.Repositories;
using System.Collections;

namespace Oef2.Controllers
{
    public class RapportController : Controller
    {
        private RegistrationRepository _reg;
        public RapportController(RegistrationRepository Reg)
        {
            this._reg = Reg;
        }

        public IActionResult Index()
        {
            List<Registration> registration = new List<Models.Registration>();
            registration = _reg.GetRegistrations();
            try
            {
                return View(registration);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}