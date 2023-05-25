using LibaryProject.Models.Entity;
using PagedList;
using System.Linq;
using System.Web.Mvc;

namespace LibaryProject.Controllers
{

	public class UyeController : Controller
	{
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntities db = new DbLibaryEntities();
#pragma warning restore IDE0044 // Add readonly modifier
		// GET: Uye
		public ActionResult Index(int sayfa = 1)
		{
			//Paged list kullanımı
			var degerler = db.TblUyeler.ToList().ToPagedList(sayfa, 10);
			return View(degerler);
		}
		//Personel Ekleme işlemi
		[HttpGet]
		public ActionResult AddUye()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddUye(TblUyeler p)
		{
			if (!ModelState.IsValid)
			{
				return View("AddUye");
			}
			db.TblUyeler.Add(p);
			db.SaveChanges();
			return View();
		}
		//Üye Silme işlemi
		public ActionResult DeleteUye(int id)
		{
			var uye = db.TblUyeler.Find(id);
			db.TblUyeler.Remove(uye);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		//Üye Çekme işlemi
		public ActionResult GetUye(int id)
		{
			var uye = db.TblUyeler.Find(id);
			return View("GetUye", uye);
		}
		public ActionResult UpdateUye(TblUyeler p)
		{
			var uye = db.TblUyeler.Find(p.ID);
			uye.Ad = p.Ad;
			uye.Soyad = p.Soyad;
			uye.Mail = p.Mail;
			uye.KullanıcıAdi = p.KullanıcıAdi;
			uye.Sifre = p.Sifre;
			uye.Telefon = p.Telefon;
			uye.Okul = p.Okul;
			uye.Fotograf = p.Fotograf;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		public ActionResult UyeKitapGecmis(int id)
		{
			var kitapgecmis = db.TblHareket.Where(x => x.Uye == id).ToList();
			var uyead = db.TblUyeler.Where(y => y.ID == id).Select(z => z.Ad + " " + z.Soyad).FirstOrDefault();
			ViewBag.uyead1 = uyead;
			return View(kitapgecmis);
		}
	}
}