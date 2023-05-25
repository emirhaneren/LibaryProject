using System.Web.Mvc;
namespace LibaryProject.Controllers
{
	[AllowAnonymous]
	public class AdminLoginController : Controller
	{
		// GET: AdminLogin
		public ActionResult Login()
		{
			return View();
		}
	}
}