using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YazilimSinamaStarsUpPlanner.Models.Entity;
using System.Web.Security;
namespace YazilimSinamaStarsUpPlanner.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        //modelin çağrılması
        dbStarsUpPlannerEntities db = new dbStarsUpPlannerEntities();
        public ActionResult GirisYap()
        {
            //get metodunda yani sayfa yüklendiğinde çağrılan giriş yap
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(Kullanicilar k)
        {
            //post metodunda çağrılan giriş yap
             //giriş yap işlemleri
             //kullanıcı adı ve şifre kontrolü
             var bilgiler = db.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == k.KullaniciAdi && x.Sifre == k.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAdi, false);
                //kullanıcıya ait bilgilerin listelenmesi için gereken session tanımlanması
                Session["KullaniciAdi"] = bilgiler.KullaniciAdi.ToString();
                return RedirectToAction("Index", "Gorev");
            }
            else
            {
                return View();
            }
           
        }
    }
}