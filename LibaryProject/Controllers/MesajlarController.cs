using LibaryProject.Models.Entity;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LibaryProject.Controllers
{
	public class MesajlarController : Controller
	{
		// GET: Mesajlar
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntities db = new DbLibaryEntities();
#pragma warning restore IDE0044 // Add readonly modifier
		public ActionResult Index()
		{
			var uyemail = Session["Mail"].ToString();
			var mesajlar = db.TblMesajlar.Where(x => x.Alıcı == uyemail.ToString()).ToList();
			return View(mesajlar);
		}
		[HttpGet]
		public ActionResult YeniMesaj()
		{
			return View();
		}
		[HttpPost]
		public ActionResult YeniMesaj(TblMesajlar m)
		{
			var uyemail = Session["Mail"].ToString();
			m.Gonderen = uyemail.ToString();
			m.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
			db.TblMesajlar.Add(m);
			db.SaveChanges();
			return RedirectToAction("Gonderilen");
		}
		public ActionResult Gonderilen()
		{
			var uyemail = Session["Mail"].ToString();
			var mesajlar = db.TblMesajlar.Where(x => x.Gonderen == uyemail.ToString()).ToList();
			return View(mesajlar);
		}
	}
}