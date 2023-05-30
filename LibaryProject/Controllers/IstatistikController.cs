using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibaryProject.Models.Entity;
namespace LibaryProject.Controllers
{
	public class IstatistikController : Controller
	{
		// GET: Istatistik
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntity db = new DbLibaryEntity();
#pragma warning restore IDE0044 // Add readonly modifier
		public ActionResult Index()
		{
			var deger1 = db.TblUyeler.Count();
			var deger2 = db.TblKitap.Count();
			var deger3 = db.TblHareket.Count();
			var deger4 = db.TblCezalar.Sum(x => x.Para);
			ViewBag.dgr1 = deger1;
			ViewBag.dgr2 = deger2;
			ViewBag.dgr3 = deger3;
			ViewBag.dgr4 = deger4;
			return View();
		}
		public ActionResult Hava()
		{
			return View();
		}
		public ActionResult HavaKart()
		{
			return View();
		}
		public ActionResult Galeri()
		{
			return View();
		}
		[HttpPost]
		public ActionResult ResimYukle(HttpPostedFileBase dosya)
		{
			if (dosya.ContentLength > 0)
			{
				string dosyayolu = Path.Combine(Server.MapPath("~/WebSource/images/"), Path.GetFileName(dosya.FileName));
				dosya.SaveAs(dosyayolu);
			}
			return RedirectToAction("Galeri");
		}
		public ActionResult LinqKart()
		{
			var deger1 = db.TblKitap.Count();
			var deger2 = db.TblUyeler.Count();
			var deger3 = db.TblCezalar.Sum(x => x.Para);
			var deger4 = db.TblKitap.Where(x => x.Durum == false).Count();
			var deger5 = db.TblKategori.Count();
			var deger6 = db.EnAktifUye().FirstOrDefault();
			var deger7 = db.EnFazlaOkunanKitap().FirstOrDefault();
			var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
			var deger9 = db.TblKitap.GroupBy(x => x.YayınEvi).OrderByDescending(z => z.Count()).Select(y => new { y.Key }).FirstOrDefault();
			//var deger9 = db.EnFazlaYayinEvi2().FirstOrDefault();
			var deger10 = db.EnCaliskanPersonel().FirstOrDefault();
			var deger11 = db.TblIletisim.Count();
			var deger12 = db.TblHareket.Count();
			ViewBag.dgr1 = deger1;
			ViewBag.dgr2 = deger2;
			ViewBag.dgr3 = deger3;
			ViewBag.dgr4 = deger4;
			ViewBag.dgr5 = deger5;
			ViewBag.dgr6 = deger6;
			ViewBag.dgr7 = deger7;
			ViewBag.dgr8 = deger8;
			ViewBag.dgr9 = deger9;
			ViewBag.dgr10 = deger10;
			ViewBag.dgr11 = deger11;
			ViewBag.dgr12 = deger12;
			return View();
		}
	}
}