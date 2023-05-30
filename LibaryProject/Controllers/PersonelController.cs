using System.Linq;
using System.Web.Mvc;
using LibaryProject.Models.Entity;
namespace LibaryProject.Controllers
{
	public class PersonelController : Controller
	{
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntity db = new DbLibaryEntity();
#pragma warning restore IDE0044 // Add readonly modifier
		// GET: Personel
		public ActionResult Index()
		{
			var degerler = db.TblPersonel.ToList();
			return View(degerler);
		}
		//Personel Ekleme işlemi
		[HttpGet]
		public ActionResult AddPersonel()
		{
			return View();
		}
		[HttpPost]
		public ActionResult AddPersonel(TblPersonel p)
		{
			if (!ModelState.IsValid)
			{
				return View("AddPersonel");
			}
			db.TblPersonel.Add(p);
			db.SaveChanges();
			return View();
		}
		//Personel Silme işlemi
		public ActionResult DeletePersonel(int id)
		{
			var personel = db.TblPersonel.Find(id);
			db.TblPersonel.Remove(personel);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
		//Personel Çekme işlemi
		public ActionResult GetPersonel(int id)
		{
			var prs = db.TblPersonel.Find(id);
			return View("GetPersonel", prs);
		}
		public ActionResult UpdatePersonel(TblPersonel p)
		{
			var prs = db.TblPersonel.Find(p.ID);
			prs.Personel = p.Personel;
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}