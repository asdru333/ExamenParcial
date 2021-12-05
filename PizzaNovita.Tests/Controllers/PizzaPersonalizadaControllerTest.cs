using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Web.Mvc;
using PizzaNovita.Controllers;
using PizzaNovita.Models;
using PizzaNovita.Handlers;
using System.Collections.Generic;
using System.Data;

namespace PizzaNovita.Tests.Controllers
{
    [TestClass]
    public class PizzaPersonalizadaControllerTest
    {
        [TestMethod]
        public void TestGetListaPizzaPersonalizadaNoEsNulo()
        {
            //Arrange 
            PizzaPersonalizadaController pizzaPersonalizadaController = new PizzaPersonalizadaController();

            //Act
            ActionResult vista = pizzaPersonalizadaController.agregarPizzaPersonalizada();

            //Assert
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestGetListaPizzaPersonalizadaVistaResultado()
        {
            //Arrange 
            PizzaPersonalizadaController pizzaPersonalizadaController = new PizzaPersonalizadaController();

            //Act
            ViewResult vista = pizzaPersonalizadaController.agregarPizzaPersonalizada() as ViewResult;

            //Assert 
            Assert.AreEqual("agregarPizzaPersonalizada", vista.ViewName);
        }

        [TestMethod]
        public void TestPostListaPizzaPersonalizadaNoEsNulo()
        { 
            PizzaPersonalizadaController pizzaPersonalizadaController = new PizzaPersonalizadaController();

            //Act
            ActionResult vista = pizzaPersonalizadaController.agregarPizzaPersonalizada(crearModeloPizza());

            //Assert
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestPostListaPizzaPersonalizadaVistaResultado()
        {
            //Arrange 
            PizzaPersonalizadaController pizzaPersonalizadaController = new PizzaPersonalizadaController();

            //Act
            ViewResult vista = pizzaPersonalizadaController.agregarPizzaPersonalizada(crearModeloPizza()) as ViewResult;

            //Assert 
            Assert.AreEqual("agregarPizzaPersonalizada", vista.ViewName);
        }

        [TestMethod]
        public void TestAgregarPizzaPersonalizadaNoEsNulo()
        {
            PizzaModel pizza = crearModeloPizza();

            //Arrange 
            PizzaPersonalizadaController pizzaPersonalizadaController = new PizzaPersonalizadaController();

            //Act
            ActionResult vista = pizzaPersonalizadaController.pedirPizzaPersonalizada(pizza);

            //Assert
            Assert.IsNotNull(vista);
        }

        [TestMethod]
        public void TestAgregarPizzaPersonalizadaListaResultado()
        {
            PizzaModel pizza = crearModeloPizza();

            //Arrange 
            PizzaPersonalizadaController pizzaPersonalizadaController = new PizzaPersonalizadaController();

            //Act
            ViewResult vista = pizzaPersonalizadaController.pedirPizzaPersonalizada(pizza) as ViewResult;

            //Assert 
            Assert.AreEqual("pedirPizzaPersonalizada", vista.ViewName);
        }

        private PizzaModel crearModeloPizza()
        {
            ComestibleHandler comestibleHandler = new ComestibleHandler();
            List<string> listaIngredientes = comestibleHandler.obtenerIngredientes("Pizza de jamón");
            PizzaModel pizza = new PizzaModel
            {
                nombre = "Pizza de Jamón",
                precio = 1000,
                salsa = "tomate",
                ingredientes = listaIngredientes
            };
            return pizza;
        }
    }
}
