using LibaryProject.Models.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
namespace LibaryProject.Controllers
{
	public class OduncController : Controller
	{
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntities db = new DbLibaryEntities();
#pragma warning restore IDE0044 // Add readonly modifier
		// GET: Odunc
		public ActionResult Index()
		{
			var degerler = db.TblHareket.Where(x=>x.IslemDurum==false).ToList();
			return View(degerler);
		}
		//Ödünç verme işlemi
		[HttpGet]
		public ActionResult OduncVer()
		{
			return View();
		}
		[HttpPost]
		public ActionResult OduncVer(TblHareket p)
		{
			db.TblHareket.Add(p);
			db.SaveChanges();
			return View();
		}
		public ActionResult OduncIade(int id)
		{
			var odc = db.TblHareket.Find(id);
			return View("OduncIade", odc);
		}
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