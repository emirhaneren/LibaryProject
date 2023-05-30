using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using SelectListItem = System.Web.Mvc.SelectListItem;
using LibaryProject.Models.Entity;

namespace LibaryProject.Controllers
{
	public class KitapController : Controller
	{
		// GET: Kitap
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntity db = new DbLibaryEntity();
#pragma warning restore IDE0044 // Add readonly modifier
		public ActionResult Index(string p)
		{
			var kitaplar = from k in db.TblKitap select k;
			if (!string.IsNullOrEmpty(p))
			{
				kitaplar = kitaplar.Where(x => x.Ad.Contains(p));
			}
			//  var kitaplar=db.TblKitap.ToList();
			return View(kitaplar.ToList());
		}
		[HttpGet]
		public ActionResult AddKitap()
		{
			//DropDownList veri çekme
			List<SelectListItem> deger1 = (from i in db.TblKategori.ToList()
										   select new SelectListItem
										   {
											   Text = i.Ad,
											   Value = i.ID.ToString()
										   }).ToList();
			ViewBag.dgr1 = deger1;

			List<SelectListItem> deger2 = (from i in db.TblYazar.ToList()
										   select new SelectListItem
										   {
											   Text = i.Ad + ' ' + i.Soyad,
											   Value = i.ID.ToString()
										   }).ToList();
			ViewBag.dgr2 = deger2;
			return View();
		}
		[HttpPost]
		public ActionResult AddKitap(TblKitap p)
		{
			var ktg = db.TblKategori.Where(k => k.ID == p.TblKategori.ID).FirstOrDefault();
			var yzr = db.TblYazar.Where(y => y.ID == p.TblYazar.ID).FirstOrDefault();
			p.TblKategori = ktg;
			p.TblYazar = yzr;
			db.TblKitap.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult DeleteKitap(int id)
		{
			var kitap = db.TblKitap.Find(id);
			db.TblKitap.Remove(kitap);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult GetKitap(int id)
		{
			var kitap = db.TblKitap.Find(id);
			List<SelectListItem> deger1 = (from i in db.TblKategori.ToList()
										   select new SelectListItem
										   {
											   Text = i.Ad,
											   Value = i.ID.ToString()
										   }).ToList();
			ViewData["dgr1"] = deger1;

			List<SelectListItem> deger2 = (from i in db.TblYazar.ToList()
										   select new SelectListItem
										   {
											   Text = i.Ad + ' ' + i.Soyad,
											   Value = i.ID.ToString()
										   }).ToList();
			ViewData["dgr2"] = deger2;
			return View("GetKitap", kitap);
		}
		public ActionResult UpdateKitap(TblKitap p)
		{
			var kitap = db.TblKitap.Find(p.ID);
			kitap.Ad = p.Ad;
			kitap.BasımYılı = p.BasımYılı;
			kitap.SayfaSayısı = p.SayfaSayısı;
			kitap.YayınEvi = p.YayınEvi;
			kitap.Durum = true;

			var ktg = db.TblKategori.Where(k => k.ID == p.TblKategori.ID).FirstOrDefault();
			var yzr = db.TblYazar.Where(y => y.ID == p.TblYazar.ID).FirstOrDefault();
			kitap.Kategori = ktg.ID;
			kitap.Yazar = yzr.ID;

			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}