using MVCEmail.Models;
using System.Net;
using System.Net.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;


namespace AsiaTravels.Controllers
{

    public class HomeController : Controller
    {
        private string body;

        public SmtpDeliveryMethod DeliveryMethod { get; private set; }
        public bool UseDefaultCredentials { get; private set; }

        public ActionResult Index()
        {
            return View();
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


        //public ActionResult SendEmails(EmailFormModel model)
        //{
        //    try { 
        //    if (ModelState.IsValid)
        //    {
        //        MailAddress senderEmail = new MailAddress("musamasood@gmail.com", "Demo");
        //        var receiverEmail = new MailAddress(receiver, "Receiver");
        //        var password = "Um9-5Tz)(,5tanx";
        //            var sub = Name;
        //            string body = message;

        //            var smtp = new SmtpClient
        //        {
        //                Host = "smtp.gmail.com",
        //            Port = 587,
        //            EnableSsl = true,
        //            DeliveryMethod = SmtpDeliveryMethod.Network,
        //            Credentials = new NetworkCredential(senderEmail.Address, password)
        //        };

        //            using (var mess = new MailMessage(senderEmail, receiverEmail)
        //        {
        //            Subject = (string)subject,
        //            Body = body,
        //        })
        //        {
        //            smtp.Send(mess);
        //        }
        //          ViewBag.Index = "Sucessfully sent";
        //        return RedirectToAction("Index");
        //    }
        //    }
        //    catch (Exception)
        //    {
        //        ViewBag.Error = "Some Error";
        //        return RedirectToAction("Some Error");
        //    }
        //    return View();


        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendEmails(string Name, string FromEmail, string Message, double Phone, string Subject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress("musamasood1122@gmail.com", "Demo");
                    var receiverEmail = new MailAddress("ussama.ahmed05@gmail.com");
                    var password = "Um9-5Tz)(,5tanx";
                    var sub = Subject;
                    var body = Message;
                    var name = Name;
                    var mail = FromEmail;
                    var ph=Phone;

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = Subject,
                        Body = body
                        
                    })
                    {
                        smtp.Send(mess);
                    }
                //    ViewBag.Index = "Sucessfully sent";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception)
            {
                //ViewBag.Error = "Some Error";
                return RedirectToAction("Some Error");
            }
            return View();
        }



        private new ActionResult View(object model)
        {
            throw new NotImplementedException();
        }

        public ActionResult Sent()
        {
            return View();
        }
    }
}
    