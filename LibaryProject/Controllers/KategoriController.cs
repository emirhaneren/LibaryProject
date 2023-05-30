using System.Linq;
using System.Web.Mvc;
using LibaryProject.Models.Entity;
using PagedList;

namespace LibaryProject.Controllers
{
	public class KategoriController : Controller
	{
		// GET: Kategori

		//Create an Entity
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntity db = new DbLibaryEntity();
#pragma warning restore IDE0044 // Add readonly modifier
		public ActionResult Index(int sayfa = 1)
		{
			//Listeleme işlemi
			var degerler = db.TblKategori.Where(x => x.Durum == true).ToList().ToPagedList(sayfa,10);
			return View(degerler);
		}
		//Kategori Ekleme işlemi
		[HttpGet]
		public ActionResult AddKategori()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddKategori(TblKategori p)
		{
			db.TblKategori.Add(p);
			db.SaveChanges();
			return View();
		}
		//Kategori Silme işlemi
		public ActionResult DeleteKategori(int id)
		{
			var kategori = db.TblKategori.Find(id);
			//db.TblKategori.Remove(kategori);
			kategori.Durum = false;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		//Kategori Çekme işlemi
		public ActionResult GetKategori(int id)
		{
			var ktg = db.TblKategori.Find(id);
			return View("GetKategori", ktg);
		}
		public ActionResult UpdateKategori(TblKategori p)
		{
			var ktg = db.TblKategori.Find(p.ID);
			ktg.Ad = p.Ad;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}