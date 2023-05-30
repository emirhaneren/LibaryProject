using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using LibaryProject.Models.Entity;
namespace LibaryProject.Controllers
{
	public class OduncController : Controller
	{
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntity db = new DbLibaryEntity();
#pragma warning restore IDE0044 // Add readonly modifier
		// GET: Odunc
		public ActionResult Index()
		{
			var degerler = db.TblHareket.Where(x => x.IslemDurum == false).ToList();
			return View(degerler);
		}
		//Ödünç verme işlemi
		[HttpGet]
		public ActionResult OduncVer()
		{
			List<SelectListItem> deger1 = (from x in db.TblUyeler.ToList()
										   select new SelectListItem
										   {
											   Text = x.Ad + " " + x.Soyad,
											   Value = x.ID.ToString()
										   }).ToList();
			ViewBag.dgr1 = deger1;
			List<SelectListItem> deger2 = (from y in db.TblKitap.Where(x => x.Durum == true).ToList()
										   select new SelectListItem
										   {
											   Text = y.Ad,
											   Value = y.ID.ToString()
										   }).ToList();
			ViewBag.dgr2 = deger2;
			List<SelectListItem> deger3 = (from z in db.TblPersonel.ToList()
										   select new SelectListItem
										   {
											   Text = z.Personel,
											   Value = z.ID.ToString()
										   }).ToList();
			ViewBag.dgr3 = deger3;
			return View();
		}
		[HttpPost]
		public ActionResult OduncVer(TblHareket p)
		{
			var d1 = db.TblUyeler.Where(x => x.ID == p.TblUyeler.ID).FirstOrDefault();
			var d2 = db.TblKitap.Where(x => x.ID == p.TblKitap.ID).FirstOrDefault();
			var d3 = db.TblPersonel.Where(x => x.ID == p.TblPersonel.ID).FirstOrDefault();
			p.TblUyeler = d1;
			p.TblKitap = d2;
			p.TblPersonel = d3;
			db.TblHareket.Add(p);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		//Ödünç İade İşlemi
		public ActionResult OduncIade(TblHareket p)
		{
			var odc = db.TblHareket.Find(p.ID);
			DateTime baslangıc = DateTime.Parse(odc.IadeTarih.ToString());
			DateTime bugun = Convert.ToDateTime(DateTime.Now.ToShortDateString());
			TimeSpan sonuc = bugun - baslangıc;
			ViewBag.dgr = sonuc.TotalDays;
			return View("OduncIade", odc);
		}
		//Ödünç Güncelleme
		public ActionResult OduncGuncelle(TblHareket p)
		{
			var odc = db.TblHareket.Find(p.ID);
			odc.UyeGetirTarih = p.UyeGetirTarih;
			odc.IslemDurum = true;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}