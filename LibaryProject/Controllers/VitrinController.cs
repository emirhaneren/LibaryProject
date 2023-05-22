using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibaryProject.Models.Entity;
using LibaryProject.Models.Classes;
using Microsoft.Ajax.Utilities;
using PagedList;

namespace LibaryProject.Controllers
{
    public class VitrinController : Controller
    {
		// GET: Vitrin
#pragma warning disable IDE0044 // Add readonly modifier
		DbLibaryEntities db = new DbLibaryEntities();
#pragma warning restore IDE0044 // Add readonly modifier
		[HttpGet]
		public ActionResult Index(int sayfa = 1)
        {
			Class1 cs = new Class1
			{
				KitapDeger = db.TblKitap.ToList()
				/*KitapDeger = db.TblKitap.ToList().ToPagedList(sayfa, 6)*/,
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