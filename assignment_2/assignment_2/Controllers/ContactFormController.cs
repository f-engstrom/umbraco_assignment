using System;
using System.Net.Mail;
using System.Web.Mvc;
using assignment_2.Models;
using Umbraco.Web.Mvc;

namespace assignment_2.Controllers
{
    public class ContactFormController :SurfaceController
    {
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HandleContactForm(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }

            MailMessage email = new MailMessage("noreply@local.com", model.Email)
            {
                Subject = "Contact Request",
                Body = model.Message
            };

            try
            {
                SmtpClient smtp = new SmtpClient();

                smtp.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            TempData["IsSuccessful"] = true;

            return CurrentUmbracoPage();
        }
        
    }
}