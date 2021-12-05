using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using PizzaNovita.Controllers;
using PizzaNovita.Models;
using PizzaNovita.Moqs;
using PizzaNovita.Handlers;
using Moq;

namespace PizzaNovita.Tests.Controllers
{
    [TestClass]
    public class ComestibleControllerTest
    {
        [TestMethod]
        public void TestListaComestiblesVistaNoNula()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ActionResult vista = comestibleController.listaComestibles();

            //Assert 
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestListaComestibleVista()
        {
            //Arrange 
            ComestibleController comestibleController = new ComestibleController();

            //Act 
            ViewResult vista = comestibleController.listaComestibles() as ViewResult;

            //Assert 
            Assert.AreEqual("listaComestibles", vista.ViewName);
        }

        [TestMethod]
        public void TestListaComestibleListaPizzasNoEsNula()
        {
            var mockComestible = new Mock<IComestibleService>();
            mockComestible.Setup(servicio => servicio.obtenerPizzas(0)).Returns(new List<PizzaModel>());
            ComestibleController comestibleController = new ComestibleController(mockComestible.Object);

            ViewResult vistaResultado = comestibleController.listaComestibles() as ViewResult;
            var listaPizzas = vistaResultado.ViewBag.pizza;

            Assert.IsNotNull(listaPizzas);
        }

        [TestMethod]
        public void TestListaComestibleListaPizzasEsTipoLista()
        {
            var mockComestible = new Mock<IComestibleService>();
            mockComestible.Setup(servicio => servicio.obtenerPizzas(0)).Returns(new List<PizzaModel>());
            ComestibleController comestibleController = new ComestibleController(mockComestible.Object);

            ViewResult vistaResultado = comestibleController.listaComestibles() as ViewResult;
            var listaPizzas = vistaResultado.ViewBag.pizza;

            Assert.IsInstanceOfType(listaPizzas, typeof(List<PizzaModel>));
        }

        [TestMethod]
        public void TestListaComestibleListaPizzasNoTienesNulos()
        {
            var mockComestible = new Mock<IComestibleService>();
            mockComestible.Setup(servicio => servicio.obtenerPizzas(0)).Returns(new List<PizzaModel>());
            ComestibleController comestibleController = new ComestibleController(mockComestible.Object);

            ViewResult vistaResultado = comestibleController.listaComestibles() as ViewResult;
            var listaPizzas = vistaResultado.ViewBag.pizza;

            CollectionAssert.AllItemsAreNotNull(listaPizzas);
        }

        [TestMethod]
        public void TestListaComestibleListaBebidasNoEsNula()
        {
            var mockComestible = new Mock<IComestibleService>();
            mockComestible.Setup(servicio => servicio.obtenerBebidas()).Returns(new List<BebidaModel>());
            ComestibleController comestibleController = new ComestibleController(mockComestible.Object);

            ViewResult vistaResultado = comestibleController.listaComestibles() as ViewResult;
            var listaBebidas = vistaResultado.ViewBag.bebida;

            Assert.IsNotNull(listaBebidas);
        }

        [TestMethod]
        public void TestListaComestibleListaBebidasEsTipoLista()
        {
            var mockComestible = new Mock<IComestibleService>();
            mockComestible.Setup(servicio => servicio.obtenerBebidas()).Returns(new List<BebidaModel>());
            ComestibleController comestibleController = new ComestibleController(mockComestible.Object);

            ViewResult vistaResultado = comestibleController.listaComestibles() as ViewResult;
            var listaBebidas = vistaResultado.ViewBag.bebida;

            Assert.IsInstanceOfType(listaBebidas, typeof(List<BebidaModel>));
        }

        [TestMethod]
        public void TestListaComestibleListaBebidasNoTienesNulos()
        {
            var mockComestible = new Mock<IComestibleService>();
            mockComestible.Setup(servicio => servicio.obtenerBebidas()).Returns(new List<BebidaModel>());
            ComestibleController comestibleController = new ComestibleController(mockComestible.Object);

            ViewResult vistaResultado = comestibleController.listaComestibles() as ViewResult;
            var listaBebidas = vistaResultado.ViewBag.bebida;

            CollectionAssert.AllItemsAreNotNull(listaBebidas);
        }

        [TestMethod]
        public void TestListaComestibleListaAcompanantesNoEsNula()
        {
            var mockComestible = new Mock<IComestibleService>();
            mockComestible.Setup(servicio => servicio.obtenerAcompanantes()).Returns(new List<AcompananteModel>());
            ComestibleController comestibleController = new ComestibleController(mockComestible.Object);

            ViewResult vistaResultado = comestibleController.listaComestibles() as ViewResult;
            var listaAcompanantes = vistaResultado.ViewBag.acompanante;

            Assert.IsNotNull(listaAcompanantes);
        }

        [TestMethod]
        public void TestListaComestibleListaAcompanantesEsTipoLista()
        {
            var mockComestible = new Mock<IComestibleService>();
            mockComestible.Setup(servicio => servicio.obtenerAcompanantes()).Returns(new List<AcompananteModel>());
            ComestibleController comestibleController = new ComestibleController(mockComestible.Object);

            ViewResult vistaResultado = comestibleController.listaComestibles() as ViewResult;
            var listaAcompanantes = vistaResultado.ViewBag.acompanante;

            Assert.IsInstanceOfType(listaAcompanantes, typeof(List<AcompananteModel>));
        }

        [TestMethod]
        public void TestListaComestibleListaAcompanantesNoTienesNulos()
        {
            var mockComestible = new Mock<IComestibleService>();
            mockComestible.Setup(servicio => servicio.obtenerAcompanantes()).Returns(new List<AcompananteModel>());
            ComestibleController comestibleController = new ComestibleController(mockComestible.Object);

            ViewResult vistaResultado = comestibleController.listaComestibles() as ViewResult;
            var listaAcompanantes = vistaResultado.ViewBag.acompanante;

            CollectionAssert.AllItemsAreNotNull(listaAcompanantes);
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
