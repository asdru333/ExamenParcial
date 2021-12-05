using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using PizzaNovita.Controllers;
using PizzaNovita.Handlers;
using PizzaNovita.Models;
using PizzaNovita.Moqs;
using Moq;

namespace PizzaNovita.Tests.Controllers
{
    [TestClass]
    public class ComboControllerTest
    {
        [TestMethod]
        public void TestListaCombosVistaNoEsNula()
        {
            //Arrange 
            ComboController comboController = new ComboController();

            //Act
            ActionResult vista = comboController.listaCombos();

            //Assert
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestListaCombosVistaResultado()
        {
            //Arrange 
            ComboController comboController = new ComboController();

            //Act 
            ViewResult vista = comboController.listaCombos() as ViewResult;

            //Assert 
            Assert.AreEqual("listaCombos", vista.ViewName);
        }

        [TestMethod]
        public void TestListaCombosListaNoEsNula()
        {
            var mockCombo = new Mock<IComboService>();
            mockCombo.Setup(servicio => servicio.obtenerCombos()).Returns(new List<ComboModel>());
            ComboController comboController = new ComboController(mockCombo.Object);

            ViewResult vistaResultado = comboController.listaCombos() as ViewResult;
            var listaCombos = vistaResultado.ViewBag.combo;

            Assert.IsNotNull(listaCombos);
        }

        [TestMethod]
        public void TestListaCombosListaEsTipoLista()
        {
            var mockCombo = new Mock<IComboService>();
            mockCombo.Setup(servicio => servicio.obtenerCombos()).Returns(new List<ComboModel>());
            ComboController comboController = new ComboController(mockCombo.Object);

            ViewResult vistaResultado = comboController.listaCombos() as ViewResult;
            var listaCombos = vistaResultado.ViewBag.combo;

            Assert.IsInstanceOfType(listaCombos, typeof(List<ComboModel>));
        }

        [TestMethod]
        public void TestListaCombosListaNoTieneNulos()
        {
            var mockCombo = new Mock<IComboService>();
            mockCombo.Setup(servicio => servicio.obtenerCombos()).Returns(new List<ComboModel>());
            ComboController comboController = new ComboController(mockCombo.Object);

            ViewResult vistaResultado = comboController.listaCombos() as ViewResult;
            var listaCombos = vistaResultado.ViewBag.combo;

            CollectionAssert.AllItemsAreNotNull(listaCombos);
        }

        [TestMethod]
        public void TestGetAgregarComboVistaNoNula()
        {
            //Arrange 
            ComboController comboController = new ComboController();

            //Act
            ActionResult vista = comboController.agregarCombo();

            //Assert
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestGetAgregarComboVistaResultado()
        {
            //Arrange 
            ComboController comboController = new ComboController();

            //Act 
            ViewResult vista = comboController.agregarCombo() as ViewResult;

            //Assert 
            Assert.AreEqual("agregarCombo", vista.ViewName);
        }

        [TestMethod]
        public void TestGetAgregarComboListaPizzasNoEsNula()
        {
            var mockCombo = new Mock<IComboService>();
            mockCombo.Setup(servicio => servicio.obtenerNombresPizzas()).Returns(new List<SelectListItem>());
            ComboController comboController = new ComboController(mockCombo.Object);

            ViewResult vistaResultado = comboController.agregarCombo() as ViewResult;
            var listaPizzas = vistaResultado.ViewBag.pizzas;

            Assert.IsNotNull(listaPizzas);
        }

        [TestMethod]
        public void TestGetAgregarComboListaPizzasEsTipoNula()
        {
            var mockCombo = new Mock<IComboService>();
            mockCombo.Setup(servicio => servicio.obtenerNombresPizzas()).Returns(new List<SelectListItem>());
            ComboController comboController = new ComboController(mockCombo.Object);

            ViewResult vistaResultado = comboController.agregarCombo() as ViewResult;
            var listaPizzas = vistaResultado.ViewBag.pizzas;

            Assert.IsInstanceOfType(listaPizzas, typeof(List<SelectListItem>));
        }

        [TestMethod]
        public void TestGetAgregarComboListaPizzasNoTieneNulos()
        {
            var mockCombo = new Mock<IComboService>();
            mockCombo.Setup(servicio => servicio.obtenerNombresPizzas()).Returns(new List<SelectListItem>());
            ComboController comboController = new ComboController(mockCombo.Object);

            ViewResult vistaResultado = comboController.agregarCombo() as ViewResult;
            var listaPizzas = vistaResultado.ViewBag.pizzas;

            CollectionAssert.AllItemsAreNotNull(listaPizzas);
        }

        [TestMethod]
        public void TestGetAgregarComboListaBebidasNoEsNula()
        {
            var mockCombo = new Mock<IComboService>();
            mockCombo.Setup(servicio => servicio.obtenerNombresBebidas()).Returns(new List<SelectListItem>());
            ComboController comboController = new ComboController(mockCombo.Object);

            ViewResult vistaResultado = comboController.agregarCombo() as ViewResult;
            var listaBebidas = vistaResultado.ViewBag.bebidas;

            Assert.IsNotNull(listaBebidas);
        }

        [TestMethod]
        public void TestGetAgregarComboListaBebidasEsTipoNula()
        {
            var mockCombo = new Mock<IComboService>();
            mockCombo.Setup(servicio => servicio.obtenerNombresBebidas()).Returns(new List<SelectListItem>());
            ComboController comboController = new ComboController(mockCombo.Object);

            ViewResult vistaResultado = comboController.agregarCombo() as ViewResult;
            var listaBebidas = vistaResultado.ViewBag.bebidas;

            Assert.IsInstanceOfType(listaBebidas, typeof(List<SelectListItem>));
        }

        [TestMethod]
        public void TestGetAgregarComboListaBebidasNoTieneNulos()
        {
            var mockCombo = new Mock<IComboService>();
            mockCombo.Setup(servicio => servicio.obtenerNombresBebidas()).Returns(new List<SelectListItem>());
            ComboController comboController = new ComboController(mockCombo.Object);

            ViewResult vistaResultado = comboController.agregarCombo() as ViewResult;
            var listaBebidas = vistaResultado.ViewBag.bebidas;

            CollectionAssert.AllItemsAreNotNull(listaBebidas);
        }

        [TestMethod]
        public void TestGetAgregarComboListaAcompanantesNoEsNula()
        {
            var mockCombo = new Mock<IComboService>();
            mockCombo.Setup(servicio => servicio.obtenerNombresAcompanantes()).Returns(new List<SelectListItem>());
            ComboController comboController = new ComboController(mockCombo.Object);

            ViewResult vistaResultado = comboController.agregarCombo() as ViewResult;
            var listaAcompanantes = vistaResultado.ViewBag.acompanantes;

            Assert.IsNotNull(listaAcompanantes);
        }

        [TestMethod]
        public void TestGetAgregarComboListaAcompanantesEsTipoNula()
        {
            var mockCombo = new Mock<IComboService>();
            mockCombo.Setup(servicio => servicio.obtenerNombresAcompanantes()).Returns(new List<SelectListItem>());
            ComboController comboController = new ComboController(mockCombo.Object);

            ViewResult vistaResultado = comboController.agregarCombo() as ViewResult;
            var listaAcompanantes = vistaResultado.ViewBag.acompanantes;

            Assert.IsInstanceOfType(listaAcompanantes, typeof(List<SelectListItem>));
        }

        [TestMethod]
        public void TestGetAgregarComboListaAcompanantesNoTieneNulos()
        {
            var mockCombo = new Mock<IComboService>();
            mockCombo.Setup(servicio => servicio.obtenerNombresAcompanantes()).Returns(new List<SelectListItem>());
            ComboController comboController = new ComboController(mockCombo.Object);

            ViewResult vistaResultado = comboController.agregarCombo() as ViewResult;
            var listaAcompanantes = vistaResultado.ViewBag.acompanantes;

            CollectionAssert.AllItemsAreNotNull(listaAcompanantes);
        }

        [TestMethod]
        public void TestPostAgregarComboVistaNoNula()
        {
            //Arrange 
            ComboController comboController = new ComboController();

            //Act
            ActionResult vista = comboController.agregarCombo(crearModeloCombo());

            //Assert
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestPostAgregarComboVistaResultado()
        {
            //Arrange 
            ComboController comboController = new ComboController();

            //Act 
            ViewResult vista = comboController.agregarCombo(crearModeloCombo()) as ViewResult;

            //Assert 
            Assert.AreEqual("agregarCombo", vista.ViewName);
        }

        private ComboModel crearModeloCombo()
        {
            ComboModel combo = new ComboModel
            {
                nombre = "Combo Prueba",
                precio = 10000,
                fotoTipo = "",
                pizza = "Pizza de Jamón",
                bebida = "Coca cola",
                acompanante = "Pan de ajo"
            };
            return combo;
        }
    }
}
