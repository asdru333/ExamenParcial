using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using PizzaNovita.Controllers;

namespace PizzaNovita.Tests.Controllers
{
    [TestClass]
    public class ComboControllerTest
    {
        [TestMethod]
        public void TestListaCombosViewResultNotNull()
        {
            //Arrange 
            ComboController comboController = new ComboController();

            //Act
            ActionResult vista = comboController.listaCombos();

            //Assert
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestAgregarComboViewResultNotNull()
        {
            //Arrange 
            ComboController comboController = new ComboController();

            //Act
            ActionResult vista = comboController.agregarCombo();

            //Assert
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestListaCombosViewResult()
        {
            //Arrange 
            ComboController comboController = new ComboController();

            //Act 
            ViewResult vista = comboController.listaCombos() as ViewResult;

            //Assert 
            Assert.AreEqual("listaCombos", vista.ViewName);
        }

        [TestMethod]
        public void TestAgregarComboViewResult()
        {
            //Arrange 
            ComboController comboController = new ComboController();

            //Act 
            ViewResult vista = comboController.agregarCombo() as ViewResult;

            //Assert 
            Assert.AreEqual("agregarCombo", vista.ViewName);
        }
    }
}
