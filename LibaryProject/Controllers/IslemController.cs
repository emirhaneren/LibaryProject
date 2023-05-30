using System.Linq;
using System.Web.Mvc;
using LibaryProject.Models.Entity;
namespace LibaryProject.Controllers
{
	public class IslemController : Controller
	{
		// GET: Islem
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntity db = new DbLibaryEntity();
#pragma warning restore IDE0044 // Add readonly modifier
		public ActionResult Index()
		{
			var degerler = db.TblHareket.Where(x => x.IslemDurum == true).ToList();
			return View(degerler);
		}
	}
}