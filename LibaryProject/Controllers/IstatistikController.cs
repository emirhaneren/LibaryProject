﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibaryProject.Controllers
{
	public class IstatistikController : Controller
	{
		// GET: Istatistik
		public ActionResult Index()
		{
			return View();
		}
		public ActionResult Hava()
		{
			return View();
		}
		public ActionResult HavaKart()
		{
			return View();
		}
		public ActionResult Galeri()
		{
			return View();
		}
		[HttpPost]
		public ActionResult ResimYukle(HttpPostedFileBase dosya)
		{ 
			if(dosya.ContentLength>0)
			{
				string dosyayolu = Path.Combine(Server.MapPath("~/WebSource/images/"),Path.GetFileName(dosya.FileName));
				dosya.SaveAs(dosyayolu);
			}
			return RedirectToAction("Galeri");
		}
	}
}