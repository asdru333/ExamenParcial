using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using PizzaNovita.Controllers;
using PizzaNovita.Models;
using PizzaNovita.Moqs;
using PizzaNovita.Handlers;

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
        public void TestGetAgregarPizzaViewResultNotNull()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ActionResult vista = comestibleController.agregarPizza();

            //Assert 
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestPostAgregarPizzaViewResultNotNull()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ActionResult vista = comestibleController.agregarPizza(crearModeloPizza());

            //Assert 
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestGetAgregarPizzaViewResult()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ViewResult vista = comestibleController.agregarPizza() as ViewResult;

            //Assert 
            Assert.AreEqual("agregarPizza", vista.ViewName);
        }

        [TestMethod]
        public void TestPostAgregarPizzaViewResult()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ViewResult vista = comestibleController.agregarPizza(crearModeloPizza()) as ViewResult;

            //Assert 
            Assert.AreEqual("agregarPizza", vista.ViewName);
        }

        [TestMethod]
        public void TestGetAgregarBebidaViewResultNotNull()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ActionResult vista = comestibleController.agregarBebida();
            //Assert 
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestPostAgregarBebidaViewResultNotNull()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ActionResult vista = comestibleController.agregarBebida(crearModeloBebida());
            //Assert 
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestGetAgregarBebidaViewResult()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ViewResult vista = comestibleController.agregarBebida() as ViewResult;

            //Assert 
            Assert.AreEqual("agregarBebida", vista.ViewName);
        }

        [TestMethod]
        public void TestPostAgregarBebidaViewResult()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ViewResult vista = comestibleController.agregarBebida(crearModeloBebida()) as ViewResult;

            //Assert 
            Assert.AreEqual("agregarBebida", vista.ViewName);
        }

        [TestMethod]
        public void TestGetAgregarAcompananteViewResultNotNull()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ActionResult vista = comestibleController.agregarAcompanante();
            //Assert 
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestPostAgregarAcompananteViewResultNotNull()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ActionResult vista = comestibleController.agregarAcompanante(crearModeloAcompanante());
            //Assert 
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestGetAgregarAcompananteViewResult()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ViewResult vista = comestibleController.agregarAcompanante() as ViewResult;

            //Assert 
            Assert.AreEqual("agregarAcompanante", vista.ViewName);
        }

        [TestMethod]
        public void TestPostAgregarAcompananteViewResult()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ViewResult vista = comestibleController.agregarAcompanante(crearModeloAcompanante()) as ViewResult;

            //Assert 
            Assert.AreEqual("agregarAcompanante", vista.ViewName);
        }

        private PizzaModel crearModeloPizza()
        {
            ComestibleHandler comestibleHandler = new ComestibleHandler();
            List<string> listaIngredientes = comestibleHandler.obtenerIngredientes("Pizza de jamón");
            PizzaModel pizza = new PizzaModel
            {
                nombre = "Pizza de Jamón",
                precio = 1000,
                fotoTipo = "",
                salsa = "tomate",
                ingredientes = listaIngredientes
            };
            return pizza;
        }

        private BebidaModel crearModeloBebida()
        {
            ComestibleHandler comestibleHandler = new ComestibleHandler();
            BebidaModel bebida = new BebidaModel
            {
                nombre = "Coca cola",
                precio = 1000,
                fotoTipo = "",
                categoriaBebida = "Gaseosa",
                litros = 2
            };
            return bebida;
        }

        private AcompananteModel crearModeloAcompanante()
        {
            ComestibleHandler comestibleHandler = new ComestibleHandler();
            AcompananteModel acompanante = new AcompananteModel
            {
                nombre = "Pan de ajo",
                precio = 1500,
                fotoTipo = "",
                unidades = 4,
            };
            return acompanante;
        }   
    }
}
