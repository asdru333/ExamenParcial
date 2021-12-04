using Microsoft.VisualStudio.TestTools.UnitTesting;
using PizzaNovita;
using PizzaNovita.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PizzaNovita.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void TestIndexViewIsNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ActionResult result = controller.Index();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestIndexViewResult()
        {
            //Arrange 
            HomeController comestibleController = new HomeController();

            //Act 
            ViewResult vista = comestibleController.Index() as ViewResult;

            //Assert 
            Assert.AreEqual("Index", vista.ViewName);
        }

        public void TestAdministracionViewIsNotNull()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ActionResult result = controller.Index();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestAdministracionViewResult()
        {
            //Arrange 
            HomeController comestibleController = new HomeController();

            //Act 
            ViewResult vista = comestibleController.panelDeAdministracion() as ViewResult;

            //Assert 
            Assert.AreEqual("panelDeAdministracion", vista.ViewName);
        }
    }
}
