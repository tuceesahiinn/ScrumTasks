using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using YazilimSinamaStarsUpPlanner.Controllers;

namespace YazilimSinamaStarsUpPlannerTest
{
    [TestClass]
    public class KayitOlControllerTest
    {
        [TestMethod]
        public void ShouldReturnView()
        {
            var controller = new KayitOlController();
            var result = controller.KayitOl();
            Assert.IsInstanceOfType(result, typeof(ViewResult));
        }
    }
}
