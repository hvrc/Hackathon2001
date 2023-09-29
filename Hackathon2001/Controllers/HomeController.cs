using Microsoft.AspNetCore.Mvc;
using Hackathon2001.Models;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System;
using Hackathon2001.Models;

namespace Hackathon2001.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            int hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View();
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(HackathonInvite hackathonInvite)
        {
            if (ModelState.IsValid)
            {
                // TODO: Email response to the party organizer
                return View("Thanks", hackathonInvite);
            }
            else
            {
                // There is a validation error, return to the form
                return View();
            }
        }

    }
}
