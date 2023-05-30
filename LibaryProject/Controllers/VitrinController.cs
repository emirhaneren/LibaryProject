using LibaryProject.Models.Classes;
using PagedList;
using System.Linq;
using System.Web.Mvc;
using LibaryProject.Models.Entity;
namespace LibaryProject.Controllers
{
	[AllowAnonymous]
	public class VitrinController : Controller
	{
		// GET: Vitrin
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntity db = new DbLibaryEntity();
#pragma warning restore IDE0044 // Add readonly modifier
		[HttpGet]
		public ActionResult Index(int sayfa = 1)
		{
			Class1 cs = new Class1
			{
				//KitapDeger = db.TblKitap.ToList()
				KitapDeger = db.TblKitap.ToList().ToPagedList(sayfa, 9),
				HakkimizdaDeger = db.TblHakkimizda.ToList()
			};
			return View(cs);
		}
		[HttpPost]
		public ActionResult Index(TblIletisim t)
		{
			db.TblIletisim.Add(t);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}