using LibaryProject.Models.Entity;
using System.Linq;
using System.Web.Mvc;
namespace LibaryProject.Controllers
{
	public class YazarController : Controller
	{
		// GET: Yazar
		//Create an entitiy
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntities db = new DbLibaryEntities();
#pragma warning restore IDE0044 // Add readonly modifier
							   //Listeleme işlemi
		public ActionResult Index()
		{
			var degerler = db.TblYazar.ToList();
			return View(degerler);
		}
		//Yazar ekleme işlemi
		[HttpGet]
		public ActionResult AddYazar()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddYazar(TblYazar p)
		{
			if(!ModelState.IsValid)
			{
				return View("AddYazar");
			}
			db.TblYazar.Add(p);
			db.SaveChanges();
			return View();
		}
		//Yazar Silme işlemi
		public ActionResult DeleteYazar(int id)
		{
			var yazar = db.TblYazar.Find(id);
			db.TblYazar.Remove(yazar);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		//Yazar Çekme işlemi
		public ActionResult GetYazar(int id)
		{
			var yzr = db.TblYazar.Find(id);
			return View("GetYazar", yzr);
		}
		//Yazar Güncelleme işlemi
		public ActionResult UpdateYazar(TblYazar p)
		{
			var yzr = db.TblYazar.Find(p.ID);
			yzr.Ad = p.Ad;
			yzr.Soyad = p.Soyad;
			yzr.Detay = p.Detay;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult YazarKitaplar(int id)
		{
			var yazar=db.TblKitap.Where(x=>x.Yazar==id).ToList();
			var yzrad = db.TblYazar.Where(y => y.ID == id).Select(z => z.Ad + " " + z.Soyad).FirstOrDefault();
			ViewBag.y1 = yzrad;
			return View(yazar);
		}
	}
}