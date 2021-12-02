using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaNovita.Models;
using PizzaNovita.Handlers;

namespace PizzaNovita.Controllers
{
    public class PizzaPersonalizadaController : Controller
    {
        public ActionResult agregarPizzaPersonalizada()
        {
            return View("agregarPizzaPersonalizada");
        }

        [HttpPost]
        public ActionResult agregarPizzaPersonalizada(PizzaModel pizza)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                ComestibleHandler accesoDatos = new ComestibleHandler();
                pizza.precio = calcularPrecio(pizza);
                ViewBag.ExitoAlCrear = accesoDatos.agregarPizzaPersonalizada(pizza);
                if (ViewBag.ExitoAlCrear)
                {
                    foreach (var variable in pizza.ingredientes)
                    {
                        accesoDatos.agregarIngredientes(pizza.nombre, variable);
                    }
                    ViewBag.Message = "La pizza " + pizza.nombre + " fue creada con éxito.";
                    ModelState.Clear();
                    return pedirPizzaPersonalizada(pizza);
                } else
                {
                    ViewBag.Message = "Algo salió mal y no fue posible crear la pizza";
                }
                return View("agregarPizzaPersonalizada");
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible crear la pizza";
                return View("agregarPizzaPersonalizada");
            }
        }

        public ActionResult pedirPizzaPersonalizada(PizzaModel pizza)
        {
            ViewBag.nombre = pizza.nombre;
            ViewBag.precio = pizza.precio;
            return View("pedirPizzaPersonalizada");
        }

        public double calcularPrecio(PizzaModel pizza)
        {
            double precioBase = 4000.0;
            if (pizza.salsa != "Tomate")
                precioBase += 1000.0;
            foreach (var variable in pizza.ingredientes)
            {
                precioBase += 500.0;
            }
            return precioBase;
        }
    }
}