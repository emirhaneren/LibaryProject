using LibaryProject.Models.Entity;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace LibaryProject.Controllers
{
	[AllowAnonymous]
	public class AdminLoginController : Controller
	{
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntity db = new DbLibaryEntity();
#pragma warning restore IDE0044 // Add readonly modifier
		// GET: AdminLogin
		public ActionResult Login()
		{
			return View();
		}
		[HttpPost]
		public ActionResult Login(TblAdmin t)
		{
			var bilgiler = db.TblAdmin.FirstOrDefault(x => x.Mail == t.Mail && x.Sifre == t.Sifre);
			if (bilgiler != null)
			{
				FormsAuthentication.SetAuthCookie(bilgiler.Mail, false);
				Session["Mail"] = bilgiler.Mail.ToString();
				return RedirectToAction("Index", "Kategori");
			}
			else
			{
				return View();
			}
		}
	}
}