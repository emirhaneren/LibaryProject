using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibaryProject.Models;
using LibaryProject.Models.Classes;

namespace LibaryProject.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeKitapResult()
        {
            return Json(Liste());
        }
        public List<Class2> Liste()
        {
            List<Class2> cs = new List<Class2>();
            cs.Add(new Class2()
            {
                YayinEvi = "Güneş",
                sayi=7
            });
            cs.Add(new Class2()
            {
                YayinEvi = "Mars",
                sayi = 18
            });
            cs.Add(new Class2()
            {
                YayinEvi = "Jüpiter",
                sayi = 34
            });
            return cs;
        }
    }
}