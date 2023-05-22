using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibaryProject.Models.Classes;
using System.Web.Security;
using LibaryProject.Models.Entity;

namespace LibaryProject.Controllers
{
    public class LoginController : Controller
    {
		// GET: Login
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntities db = new DbLibaryEntities();
#pragma warning restore IDE0044 // Add readonly modifier
		public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TblUyeler p)
        {
            var bilgiler =db.TblUyeler.FirstOrDefault(x=>x.Mail==p.Mail && x.Sifre==p.Sifre);
            if(bilgiler!= null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
				Session["Mail"] = bilgiler.Mail.ToString();
                Session["Ad"] = bilgiler.Ad.ToString();
                Session["Soyad"]=bilgiler.Soyad.ToString();
                //Session["Ad"]=bilgiler.Ad.ToString();
                //Session["Soyad"] = bilgiler.Soyad.ToString();
                //Session["KullaniciAdi"] = bilgiler.KullanıcıAdi.ToString();
                //Session["Sifre"]=bilgiler.Sifre.ToString();
                //Session["Okul"]=bilgiler.Okul.ToString();
                //Session["ID"] = bilgiler.ID.ToString();
                //------------------------------------------------------------//
				//TempData["Ad"] = bilgiler.Ad.ToString();
				//TempData["Soyad"] = bilgiler.Soyad.ToString();
				//TempData["KullaniciAdi"] = bilgiler.KullanıcıAdi.ToString();
				//TempData["Sifre"] = bilgiler.Sifre.ToString();
				//TempData["Okul"] = bilgiler.Okul.ToString();
				//TempData["ID"] = bilgiler.ID.ToString();
				return RedirectToAction("Index","Panel");
            }
            else
            {
                return View();
            }
        }
    }
}