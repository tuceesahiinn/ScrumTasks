using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazilimSinamaStarsUpPlanner.Models.Entity;

namespace YazilimSinamaStarsUpPlanner.Controllers
{
    [Authorize]
    public class GorevDurumController : Controller
    {
        // GET: GorevDurum
        //modelin çağrılması
        dbStarsUpPlannerEntities db = new dbStarsUpPlannerEntities();
        public ActionResult Index()
        {
            //giriş yapan kullanıcıya göre listeleme yapma
            var uyeKullaniciAdi = (string)Session["KullaniciAdi"].ToString();
            var deger = db.GorevDurumları.Where(x=>x.Kullanicilar.KullaniciAdi==uyeKullaniciAdi.ToString()).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult GorevDurumEkle()
        {
            //get metodunda yani sayfa yüklendiğinde çağrılan görev durum ekleme action'ı
            List<SelectListItem> deger1 = (from i in db.Gorevler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.GorevAdi,
                                               Value = i.GorevId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.Durumlar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.DurumAdi,
                                               Value = i.DurumId.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from i in db.Kullanicilar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad+" "+i.Soyad,
                                               Value = i.KullaniciId.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult GorevDurumEkle(GorevDurumları d)
        {
            //post meteodunda çağrılan görev durum ekleme action'ı
            var grv = db.Gorevler.Where(k => k.GorevId == d.Gorevler.GorevId).FirstOrDefault();
            var drm = db.Durumlar.Where(k => k.DurumId == d.Durumlar.DurumId).FirstOrDefault();
            var klnci = db.Kullanicilar.Where(k => k.KullaniciId == d.Kullanicilar.KullaniciId).FirstOrDefault();
            d.Gorevler = grv;
            d.Durumlar = drm;
            d.Kullanicilar = klnci;
            db.GorevDurumları.Add(d);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GorevDurumGetir(int id)
        {
            //gorev durumlarının textboxa getirilmesi
            var grv = db.GorevDurumları.Find(id);
            List<SelectListItem> deger1 = (from i in db.Gorevler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.GorevAdi,
                                               Value = i.GorevId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from i in db.Durumlar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.DurumAdi,
                                               Value = i.DurumId.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from i in db.Kullanicilar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad + " " + i.Soyad,
                                               Value = i.KullaniciId.ToString()
                                           }).ToList();
            ViewBag.dgr3 = deger3;
            return View("GorevDurumGetir", grv);
        }
        public ActionResult GorevDurumGuncelle(GorevDurumları g)
        {
            //görev durum güncelleme metodu
            var grv = db.GorevDurumları.Find(g.GorevDurumId);
            grv.Aciklama = g.Aciklama;
            grv.GorevDurumTarihi = g.GorevDurumTarihi;
            grv.YapilacakIs1 = g.YapilacakIs1;
            grv.YapilacakIs2 = g.YapilacakIs2;
            grv.YapilacakIs3 = g.YapilacakIs3;
            grv.YapilacakIs4 = g.YapilacakIs4;
            var gorv = db.Gorevler.Where(k => k.GorevId == g.Gorevler.GorevId).FirstOrDefault();
            var drm = db.Durumlar.Where(k => k.DurumId == g.Durumlar.DurumId).FirstOrDefault();
            var kllnci = db.Kullanicilar.Where(k => k.KullaniciId == g.Kullanicilar.KullaniciId).FirstOrDefault();
            grv.GorevId = gorv.GorevId;
            grv.DurumId = drm.DurumId;
            grv.KullaniciId = kllnci.KullaniciId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GorevDurumSil(int id)
        {
            //görev durum silme action'ı
            var grv = db.GorevDurumları.Find(id);
            db.GorevDurumları.Remove(grv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}