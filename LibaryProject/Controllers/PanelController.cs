using LibaryProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibaryProject.Controllers
{
    public class PanelController : Controller
    {
		// GET: Panel
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntities db = new DbLibaryEntities();
#pragma warning restore IDE0044 // Add readonly modifier
		// [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            var degerler = db.TblUyeler.FirstOrDefault(z => z.Mail == uyemail);
            return View(degerler);
        }
        [HttpPost]
        public ActionResult Index2(TblUyeler p)
        {
            var kullanici = (string)Session["Mail"];
            var uye = db.TblUyeler.FirstOrDefault(x=>x.Mail==kullanici);
            uye.Sifre= p.Sifre;
            uye.Ad= p.Ad;
            uye.Fotograf= p.Fotograf;
            uye.Soyad= p.Soyad;
            uye.Okul= p.Okul;
            uye.KullanıcıAdi = p.KullanıcıAdi;
            uye.Telefon=p.Telefon;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}