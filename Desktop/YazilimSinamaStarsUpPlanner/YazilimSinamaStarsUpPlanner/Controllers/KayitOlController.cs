using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazilimSinamaStarsUpPlanner.Models.Entity;

namespace YazilimSinamaStarsUpPlanner.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        //modelin çağrılması
        dbStarsUpPlannerEntities db = new dbStarsUpPlannerEntities();
        [HttpGet]
        public ActionResult KayitOl()
        {
            //get metodunda yani sayfa yüklendiğinde çağrılan kayıt ol
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Kullanicilar k)
        {
            //post metodunda çağrılan kayıt ol
            //kayıt ol işlemleri
            if (!ModelState.IsValid)
            {
                return View("KayitOl");
            }
            db.Kullanicilar.Add(k);
            db.SaveChanges();
            return View();
        }
    }
}