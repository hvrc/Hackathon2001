using Microsoft.AspNetCore.Mvc;
using Hackathon2001.Models;
using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using System.Reflection;
using System;

namespace Hackathon2001.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action method for the default homepage
        public IActionResult Index()
        {
            return View();
        }

        // Action method for the privacy page
        public IActionResult Privacy()
        {
            return View();
        }

        // Action method to handle errors
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // HTTP GET request for displaying the RSVP form
        [HttpGet]
        public ViewResult RSVPForm()
        {
            return View();
        }

        // HTTP POST request to handle RSVP form submission
        [HttpPost]
        public ViewResult RSVPForm(HackathonInvite hacakthonInvite)
        {
            if (ModelState.IsValid)
            {
                // Check which button was clicked (Accept or Regrets)
                if (Request.Form.ContainsKey("AcceptButton"))
                {
                    hacakthonInvite.WillAttend = true;
                }
                else if (Request.Form.ContainsKey("RegretsButton"))
                {
                    hacakthonInvite.WillAttend = false;
                }

                try
                {
                    // Configure and send an email notification
                    using (var smtpClient = new SmtpClient("smtp.example.com"))
                    {
                        smtpClient.Port = 587;
                        smtpClient.EnableSsl = true;
                        smtpClient.Credentials = new NetworkCredential("mySmtpUsername", "mySmtpPassword");

                        var mailMessage = new MailMessage
                        {
                            From = new MailAddress("rsvps@example.com"),
                            Subject = "RSVP Notification",
                            Body = hacakthonInvite.Name + " is " + (hacakthonInvite.WillAttend.HasValue && hacakthonInvite.WillAttend.Value ? "attending" : "not attending")
                        };

                        mailMessage.To.Add("party-host@example.com");

                        smtpClient.Send(mailMessage);
                    }
                }
                catch (Exception)
                {
                    // Handle exceptions if there are issues with sending the email
                }

                // Display a "Thanks" view upon successful form submission
                return View("Thanks", hacakthonInvite);
            }
            else
            {
                // Return the RSVP form view with validation errors if the form data is invalid
                return View();
            }
        }
    }
}
