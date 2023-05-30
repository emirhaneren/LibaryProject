using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibaryProject.Models.Entity;

namespace LibaryProject.Controllers
{
    public class AyarlarController : Controller
    {
		// GET: Ayarlar
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntity db = new DbLibaryEntity();
#pragma warning restore IDE0044 // Add readonly modifier
		public ActionResult Index()
        {
            var adminler=db.TblAdmin.ToList();
            return View(adminler);
        }
		[HttpGet]
		public ActionResult AddAdmin()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddAdmin(TblAdmin p)
		{
			db.TblAdmin.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		//Admin Silme işlemi
		public ActionResult DeleteAdmin(int id)
		{
			var admin= db.TblAdmin.Find(id);
			db.TblAdmin.Remove(admin);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		//Admin Çekme işlemi
		public ActionResult GetAdmin(int id)
		{
			var adm = db.TblAdmin.Find(id);
			return View("GetAdmin", adm);
		}
		public ActionResult UpdateAdmin(TblAdmin p)
		{
			var adm = db.TblAdmin.Find(p.ID);
			adm.Mail= p.Mail;
			adm.Sifre= p.Sifre;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}