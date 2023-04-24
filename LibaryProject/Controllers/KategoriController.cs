using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibaryProject.Models.Entity;
namespace LibaryProject.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori

        //Create an Entity
        DbLibaryEntities db = new DbLibaryEntities();
        public ActionResult Index()
        {
            //Listeleme işlemi
            var degerler = db.TblKategori.ToList();
            return View(degerler);
        }
        //Kategori Ekleme işlemi
        [HttpGet]
        public ActionResult AddKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddKategori(TblKategori p)
        {
            db.TblKategori.Add(p);
            db.SaveChanges();
            return View();
        }
        //Kategori Silme işlemi
        public ActionResult DeleteKategori(int id)
        {
            var kategori = db.TblKategori.Find(id);
            db.TblKategori.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //Kategori Çekme işlemi
        public ActionResult GetKategori(int id)
        {
            var ktg = db.TblKategori.Find(id);
            return View("GetKategori", ktg);
        }
        public ActionResult UpdateKategori (TblKategori p)
        {
            var ktg = db.TblKategori.Find(p.ID);
            ktg.Ad = p.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}