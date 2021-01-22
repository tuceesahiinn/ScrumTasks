using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazilimSinamaStarsUpPlanner.Models.Entity;
using YazilimSinamaStarsUpPlanner.CocomoModulu;

namespace YazilimSinamaStarsUpPlanner.Controllers
{
    [Authorize]
    public class PlannerController : Controller
    {
        // GET: Planner
        //modelin çağrılması
        dbStarsUpPlannerEntities db = new dbStarsUpPlannerEntities();

        public ActionResult Index()
        {
            //giriş yapan kullanıcıya göre listeleme yapma
            var uyeKullaniciAdi = (string)Session["KullaniciAdi"].ToString();
            var degerler = db.GorevDurumları.Where(x => x.Kullanicilar.KullaniciAdi == uyeKullaniciAdi.ToString()).FirstOrDefault();
            //var degerler = db.GorevDurumları.FirstOrDefault();
            //tempdata ile bilgilerin bu sayafya taşınması
            TempData["YapilacakIs1"] = degerler.YapilacakIs1.ToString();
            TempData["YapilacakIs2"] = degerler.YapilacakIs2.ToString();
            TempData["YapilacakIs3"] = degerler.YapilacakIs3.ToString();
            TempData["YapilacakIs4"] = degerler.YapilacakIs4.ToString();
            TempData["TahminiTarih"] = degerler.Gorevler.TahminiTarih.ToString();
            return View();
        }
    }
}