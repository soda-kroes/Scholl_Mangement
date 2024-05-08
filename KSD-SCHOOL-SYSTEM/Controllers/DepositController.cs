using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KSD_SCHOOL_SYSTEM.Controllers
{
    public class DepositController : Controller
    {
        public IActionResult ViewDeposit()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Code")))
            {
                return View();
            }
            return RedirectToAction("LoginPage", "Login");
        }

        public IActionResult CreateDeposit()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Code")))
            {
                return View();
            }
            return RedirectToAction("LoginPage", "Login");
        }
    }
}
