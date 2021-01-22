using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace YazilimSinamaStarsUpPlanner.Controllers
{
    public class CikisYapController : Controller
    {
        // GET: CikisYap
        public ActionResult Index()
        {
            //çıkış yap işlemleri
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Anasayfa");
        }
    }
}