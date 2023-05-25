using LibaryProject.Models.Entity;
using System.Linq;
using System.Web.Mvc;
namespace LibaryProject.Controllers
{
	public class IslemController : Controller
	{
		// GET: Islem
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntities db = new DbLibaryEntities();
#pragma warning restore IDE0044 // Add readonly modifier
		public ActionResult Index()
		{
			var degerler = db.TblHareket.Where(x => x.IslemDurum == true).ToList();
			return View(degerler);
		}
	}
}