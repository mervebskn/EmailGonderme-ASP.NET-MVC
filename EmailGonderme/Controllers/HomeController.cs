using EmailGonderme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace EmailGonderme.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Email model)
        {
            MailMessage mailim = new MailMessage();
            mailim.To.Add("kime@gmail.com");                      //mesajı alacak kişinin maili - To.Add bi liste döner,birden çok kişiye atabiliriz..
            mailim.From = new MailAddress("kimden@gmail.com");    //mesajı atan kişinin maili.
            mailim.Subject = "Bize Ulaşın sayfasından mailiniz var." + model.Baslik;
            mailim.Body = "Sayın ytkili, " + model.Ad + " " + model.Soyad + " kişisinden gelen mesaj içeriği aşağıdaki gibidir. <br>" + model.Icerik;
            mailim.IsBodyHtml = true;   //mailin bodysi html olarak dönsün..

            //gmailin bağlantı özellikleri:
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("mailadresi@gmail.com","mailinsifresi");
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";  //gmailin mail gönderme standartı.
            smtp.EnableSsl  = true;

            try
            {
                smtp.Send(mailim);
                TempData["Message"]="Mesajınız gönderildi. En kısa zamanda dönüş yapacağız.";
            }
            catch(Exception ex)
            {
                TempData["Message"] = "Mesajınız gönderilemedi!"+ex.Message;
            }


            return View();
        }
    }
}