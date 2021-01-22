using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazilimSinamaStarsUpPlanner.Models.Entity;

namespace YazilimSinamaStarsUpPlanner.Controllers
{
    [Authorize]
    public class GorevController : Controller
    {
        // GET: Gorev
        //modelin çağrılması
        dbStarsUpPlannerEntities db = new dbStarsUpPlannerEntities();

        public ActionResult Index()
        {
            //giriş yapan kullanıcıya göre listeleme yapma
            var uyeKullaniciAdi = (string)Session["KullaniciAdi"].ToString();
            var deger = db.Gorevler.Where(x => x.Kullanicilar.KullaniciAdi == uyeKullaniciAdi.ToString()).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult GorevEkle()
        {
            //get metodunda yani sayfa yüklendiğinde çağrılan görev ekleme action'ı
            List<SelectListItem> deger1 = (from i in db.Kullanicilar.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Ad+" "+i.Soyad,
                                               Value = i.KullaniciId.ToString()
                                           }).ToList();
            ViewBag.dgr1 = deger1;
            return View();
        }
        [HttpPost]
        public ActionResult GorevEkle(Gorevler g)
        {
            //post meteodunda çağrılan görev ekleme action'ı
            var kullanici = db.Kullanicilar.Where(k => k.KullaniciId == g.Kullanicilar.KullaniciId).FirstOrDefault();
            g.Kullanicilar = kullanici;
            db.Gorevler.Add(g);
            db.SaveChanges();
            return RedirectToAction("Index");      
        }
        public ActionResult GorevGetir(int id)
        {
            //gorevlerin textboxa getirilmesi
            var grv = db.Gorevler.Find(id);
            //List<SelectListItem> deger1 = (from i in db.Kullanicilar.ToList()
            //                               select new SelectListItem
            //                               {
            //                                   Text = i.Ad+" "+i.Soyad,
            //                                   Value = i.KullaniciId.ToString()
            //                               }).ToList();
            //ViewBag.dgr1 = deger1;
            return View("GorevGetir", grv);
        }
        public ActionResult GorevGuncelle(Gorevler g)
        {
            //görev güncelleme metodu
            var grv = db.Gorevler.Find(g.GorevId);
            grv.Aciklama = g.Aciklama;
            grv.GerceklesenTarih = g.GerceklesenTarih;
            grv.GorevAdi = g.GorevAdi;
            grv.GorevTarih = g.GorevTarih;
            grv.Notlar= g.Notlar;
            grv.TahminiTarih = g.TahminiTarih;
            //var kullanici = db.Kullanicilar.Where(k => k.KullaniciId == g.Kullanicilar.KullaniciId).FirstOrDefault();
            //grv.KullaniciId = kullanici.KullaniciId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GorevSil(int id)
        {
            //görev silme action'ı
            var grv = db.Gorevler.Find(id);
            db.Gorevler.Remove(grv);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}