﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibaryProject.Models.Entity;
namespace LibaryProject.Controllers
{
    public class IslemController : Controller
    {
        // GET: Islem
        DbLibaryEntities db = new DbLibaryEntities();
        public ActionResult Index()
        {
			var degerler = db.TblHareket.Where(x => x.IslemDurum == true).ToList();
			return View(degerler);
        }
    }
}