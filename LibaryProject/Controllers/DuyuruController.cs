using System.Linq;
using LibaryProject.Models.Entity;
using System.Web.Mvc;

namespace LibaryProject.Controllers
{
	public class DuyuruController : Controller
	{
		// GET: Duyuru
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntity db = new DbLibaryEntity();
#pragma warning restore IDE0044 // Add readonly modifier
		public ActionResult Index()
		{
			var degerler = db.TblDuyurular.ToList();
			return View(degerler);
		}
		[HttpGet]
		public ActionResult YeniDuyuru()
		{
			return View();
		}
		[HttpPost]
		public ActionResult YeniDuyuru(TblDuyurular t)
		{
			db.TblDuyurular.Add(t);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult DuyuruSil(int id)
		{
			var duyuru = db.TblDuyurular.Find(id);
			db.TblDuyurular.Remove(duyuru);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult DuyuruDetay(TblDuyurular p)
		{
			var duyuru = db.TblDuyurular.Find(p.ID);
			return View("DuyuruDetay", duyuru);
		}
		public ActionResult DuyuruGuncelle(TblDuyurular t)
		{
			var duyuru = db.TblDuyurular.Find(t.ID);
			duyuru.Kategori = t.Kategori;
			duyuru.Duyuru = t.Duyuru;
			duyuru.Tarih = t.Tarih;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}