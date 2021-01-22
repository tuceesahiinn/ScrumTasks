using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YazilimSinamaStarsUpPlanner.Controllers;

namespace YazilimSinamaStarsUpPlannerTest
{
    [TestClass]
    public class GirisYapControllerTest
    {
        [TestMethod]
        public void ShouldReturnView()
        {
            var controller = new GirisYapController();
            var result = controller.GirisYap();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
