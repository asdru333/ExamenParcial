using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using System.Collections.Generic;
using PizzaNovita.Controllers;
using PizzaNovita.Moqs;
using PizzaNovita.Models;
using Moq;

namespace PizzaNovita.Tests.Controllers
{
    [TestClass]
    public class PedidoControllerTest
    {
        string nombre = "Pizza de jamón";

        [TestMethod]
        public void TestListaPedidosVistaNoEsNula()
        {
            // Arrange
            PedidoController pedidoController = new PedidoController();

            // Act
            ActionResult result = pedidoController.listaPedidos();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestListaPedidosVistaResultado()
        {
            //Arrange 
            PedidoController pedidoController = new PedidoController();

            //Act 
            ViewResult vista = pedidoController.listaPedidos() as ViewResult;

            //Assert 
            Assert.AreEqual("listaPedidos", vista.ViewName);
        }

        [TestMethod]
        public void TestListaPedidosListaNoEsNula()
        {
            var mockPedido = new Mock<IPedidoService>();
            mockPedido.Setup(servicio => servicio.obtenerPedidos()).Returns(new List<PedidoModel>());
            PedidoController pedidoController = new PedidoController(mockPedido.Object);

            ViewResult vistaResultado = pedidoController.listaPedidos() as ViewResult;
            var listaPedidos = vistaResultado.ViewBag.pedidos;

            Assert.IsNotNull(listaPedidos);
        }

        [TestMethod]
        public void TestListaPedidosListaEsTipoLista()
        {
            var mockPedido = new Mock<IPedidoService>();
            mockPedido.Setup(servicio => servicio.obtenerPedidos()).Returns(new List<PedidoModel>());
            PedidoController pedidoController = new PedidoController(mockPedido.Object);

            ViewResult vistaResultado = pedidoController.listaPedidos() as ViewResult;
            var listaPedidos = vistaResultado.ViewBag.pedidos;

            Assert.IsInstanceOfType(listaPedidos, typeof(List<PedidoModel>));
        }

        [TestMethod]
        public void TestListaPedidosListaNoTieneNulos()
        {
            var mockPedido = new Mock<IPedidoService>();
            mockPedido.Setup(servicio => servicio.obtenerPedidos()).Returns(new List<PedidoModel>());
            PedidoController pedidoController = new PedidoController(mockPedido.Object);

            ViewResult vistaResultado = pedidoController.listaPedidos() as ViewResult;
            var listaPedidos = vistaResultado.ViewBag.pedidos;

            CollectionAssert.AllItemsAreNotNull(listaPedidos);
        }

        [TestMethod]
        public void TestPedidoVistaNoNula()
        {
            //Arrange 
            PedidoController pedidoController = new PedidoController();

            //Act 
            ActionResult vista = pedidoController.recoger(nombre);

            //Assert 
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestRecogerVistaResultado()
        {
            //Arrange 
            PedidoController pedidoController = new PedidoController();

            //Act 
            ViewResult vista = pedidoController.recoger(nombre) as ViewResult;

            //Assert 
            Assert.AreEqual("recoger", vista.ViewName);
        }

        [TestMethod]
        public void TestAdomicilioViewResultNotNull()
        {
            //Arrange 
            PedidoController pedidoController = new PedidoController();

            //Act 
            ActionResult vista = pedidoController.aDomicilio(nombre);

            //Assert 
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestAdomicilioViewResult()
        {
            //Arrange 
            PedidoController pedidoController = new PedidoController();

            //Act 
            ViewResult vista = pedidoController.aDomicilio(nombre) as ViewResult;

            //Assert 
            Assert.AreEqual("aDomicilio", vista.ViewName);
        }

        public PedidoModel crearModeloPedido()
        {
            PedidoModel pedido =
                new PedidoModel
                {
                    nombreComestible = "Pizza de Jamón",
                    nombreCliente = "Asdrúbal",
                    apellidoCliente = "Villegas Molina",
                    direccion = "Una direcccion",
                    precio = 4500
                };
            return pedido;
        }
    }
}
