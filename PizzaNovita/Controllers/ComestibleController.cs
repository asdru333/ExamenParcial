using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaNovita.Models;
using PizzaNovita.Handlers;

namespace PizzaNovita.Controllers
{
    public class ComestibleController : Controller
    {
        public ActionResult listaComestibles()
        {
            ComestibleHandler accesoDatos = new ComestibleHandler();
            string ingrediente = "";
            ViewBag.pizza = accesoDatos.obtenerPizzas();
            ViewBag.bebida = accesoDatos.obtenerBebidas();
            ViewBag.acompanante = accesoDatos.obtenerAcompanantes();
            ViewBag.ingrediente = ingrediente;
            return View("listaComestibles");
        }

        [HttpGet]
        public ActionResult ObtenerImagen(string nombre)
        {
            ComestibleHandler comestibleHandler = new ComestibleHandler();
            var tupla = comestibleHandler.obtenerFoto(nombre);
            return File(tupla.Item1, tupla.Item2);
        }

        [HttpGet]
        public ActionResult agregarPizza()
        {
            return View("agregarPizza");
        }

        [HttpPost]
        public ActionResult agregarPizza(PizzaModel pizza, string ingredientes)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    ComestibleHandler accesoDatos = new ComestibleHandler();
                    ViewBag.ExitoAlCrear = accesoDatos.agregarPizza(pizza);
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
                return View("agregarPizza");
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible crear la pizza";
                return View("agregarPizza");
            }
        }

        [HttpGet]
        public ActionResult agregarBebida()
        {
            return View("agregarBebida");
        }

        [HttpPost]
        public ActionResult agregarBebida(BebidaModel bebida)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    ComestibleHandler accesoDatos = new ComestibleHandler();
                    ViewBag.ExitoAlCrear = accesoDatos.agregarBebida(bebida);
                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "La bebida " + bebida.nombre + " fue creada con éxito.";
                        ModelState.Clear();
                    }
                }
                return View("agregarBebida");
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible crear la bebida";
                return View("agregarBebida");
            }
        }

        [HttpGet]
        public ActionResult agregarAcompanante()
        {
            return View("agregarAcompanante");
        }

        [HttpPost]
        public ActionResult agregarAcompanante(AcompananteModel acompanante)
        {
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    ComestibleHandler accesoDatos = new ComestibleHandler();
                    ViewBag.ExitoAlCrear = accesoDatos.agregarAcompanante(acompanante);
                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "El acompañante " + acompanante.nombre + " fue creado con éxito.";
                        ModelState.Clear();
                    }
                }
                return View("agregarAcompanante");
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible crear el acompañante";
                return View("agregarAcompanante");
            }
        }
    }
}