using Browser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Browser.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Ootan sind mimu people! Palun tule!!!";
            int hour = DateTime.Now.Hour;
            if (hour <= 6 && hour > 0)
            {
                ViewBag.Greeting = "Good night";
            }
            else if (hour <= 12 && hour > 6)
            {
                ViewBag.Greeting = "Good morning";
            }
            else if (hour <= 18 && hour > 12)
            {
                ViewBag.Greeting = "Good afternoon";
            }
            else if (hour <= 24 && hour > 18)
            {
                ViewBag.Greeting = "Good evening";
            }
            return View();
        }

        [HttpGet]
        public ViewResult Ankeet()
        {
            return View();
        }
        [HttpPost]
        public ViewResult Ankeet(Guest guest)
        {
            E_mail(guest);
            if(ModelState.IsValid)
            { return View("Thanks", guest); }
            else
            { return View(); }
            
        }
        public void E_mail(Guest guest)
        {
            try
            {
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "vladislav.narozni@gmail.com";
                WebMail.Password = "Dream450894TeamMee";
                WebMail.From = "vladislav.narozni@gmail.com";

                WebMail.Send("vladislav.narozni@gmail.com", "Vastus kutsele", guest.Name + " vastas " + ((guest.WillAttend ?? false) ? "tuleb peole " : "ei tule peole"));
                ViewBag.Message = "Kiri on saatnud!";
            }
            catch (Exception)
            {
                ViewBag.Message = "Mul on kahju! Ei saa kirja saada!";
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}