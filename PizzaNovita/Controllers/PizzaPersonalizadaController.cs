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
        public ActionResult agregarPizzaPersonalizada(PizzaModel pizza, string ingredientes)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    ComestibleHandler accesoDatos = new ComestibleHandler();
                    ViewBag.ExitoAlCrear = accesoDatos.agregarPizza(pizza, 1);
                    if (ViewBag.ExitoAlCrear)
                    {
                        foreach (var variable in pizza.ingredientes)
                        {
                            accesoDatos.agregarIngredientes(pizza.nombre, variable);
                        }
                        ViewBag.Message = "La pizza " + pizza.nombre + " fue creada con éxito.";
                        ModelState.Clear();
                    }
                }
                return View("agregarPizzaPersonalizada");
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible crear la pizza";
                return View("agregarPizzaPersonalizada");
            }
        }
    }
}