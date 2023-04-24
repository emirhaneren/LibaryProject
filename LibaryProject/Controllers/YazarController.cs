using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibaryProject.Models.Entity;
namespace LibaryProject.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        //Create an entitiy
        DbLibaryEntities db = new DbLibaryEntities();
        //Listeleme işlemi
        public ActionResult Index()
        {
            var degerler = db.TblYazar.ToList();
            return View(degerler);
        }
        //Yazar ekleme işlemi
        [HttpGet]
        public ActionResult AddYazar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddYazar(TblYazar p)
        {
            db.TblYazar.Add(p);
            db.SaveChanges();
            return View();
        }
        //Yazar Silme işlemi
        public ActionResult DeleteYazar(int id)
        {
            var yazar = db.TblYazar.Find(id);
            db.TblYazar.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Yazar Çekme işlemi
        public ActionResult GetYazar(int id)
        {
            var yzr = db.TblYazar.Find(id);
            return View("GetYazar",yzr);
        }
        //Yazar Güncelleme işlemi
        public ActionResult UpdateYazar(TblYazar p)
        {
            var yzr = db.TblYazar.Find(p.ID);
            yzr.Ad = p.Ad;
            yzr.Soyad = p.Soyad;
            yzr.Detay = p.Detay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}