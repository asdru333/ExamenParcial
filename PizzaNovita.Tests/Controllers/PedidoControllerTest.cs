using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using PizzaNovita.Controllers;

namespace PizzaNovita.Tests.Controllers
{
    [TestClass]
    public class PedidoControllerTest
    {
        string nombre = "Pizza de jamón";

        [TestMethod]
        public void TestListaPedidosViewIsNotNull()
        {
            // Arrange
            PedidoController pedidoController = new PedidoController();

            // Act
            ActionResult result = pedidoController.listaPedidos();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestListaPedidosViewResult()
        {
            //Arrange 
            PedidoController pedidoController = new PedidoController();

            //Act 
            ViewResult vista = pedidoController.listaPedidos() as ViewResult;

            //Assert 
            Assert.AreEqual("listaPedidos", vista.ViewName);
        }

        [TestMethod]
        public void TestPedidoViewResultNotNull()
        {
            //Arrange 
            PedidoController pedidoController = new PedidoController();

            //Act 
            ActionResult vista = pedidoController.recoger(nombre);

            //Assert 
            Assert.IsNotNull(vista);
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
        public void TestRecogerViewResult()
        {
            //Arrange 
            PedidoController pedidoController = new PedidoController();

            //Act 
            ViewResult vista = pedidoController.recoger(nombre) as ViewResult;

            //Assert 
            Assert.AreEqual("recoger", vista.ViewName);
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
    }
}
