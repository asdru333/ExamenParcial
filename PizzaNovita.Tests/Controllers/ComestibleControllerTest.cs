using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using PizzaNovita.Controllers;

namespace PizzaNovita.Tests.Controllers
{
    [TestClass]
    public class ComestibleControllerTest
    {
        [TestMethod]
        public void TestListaComestiblesViewResultNotNull()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ActionResult vista = comestibleController.listaComestibles();

            //Assert 
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestAgregarPizzaViewResultNotNull()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ActionResult vista = comestibleController.agregarPizza();

            //Assert 
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestAgregarBebidaViewResultNotNull()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ActionResult vista = comestibleController.agregarBebida();
            //Assert 
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestAgregarComestibleViewResultNotNull()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ActionResult vista = comestibleController.agregarAcompanante();
            //Assert 
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestListaComestibleViewResult()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ViewResult vista = comestibleController.listaComestibles() as ViewResult;

            //Assert 
            Assert.AreEqual("listaComestibles", vista.ViewName);
        }

        [TestMethod]
        public void TestAgregarPizzaViewResult()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ViewResult vista = comestibleController.agregarPizza() as ViewResult;

            //Assert 
            Assert.AreEqual("agregarPizza", vista.ViewName);
        }

        [TestMethod]
        public void TestAgregarBebidaViewResult()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ViewResult vista = comestibleController.agregarBebida() as ViewResult;

            //Assert 
            Assert.AreEqual("agregarBebida", vista.ViewName);
        }

        [TestMethod]
        public void TestAgregarAcompananteViewResult()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ViewResult vista = comestibleController.agregarAcompanante() as ViewResult;

            //Assert 
            Assert.AreEqual("agregarAcompanante", vista.ViewName);
        }
    }
}
