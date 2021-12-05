using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaNovita.Models;
using PizzaNovita.Handlers;
using PizzaNovita.Moqs;


namespace PizzaNovita.Controllers
{
    public class ComboController : Controller
    {
        readonly IComboService accesoDatos;

        public ComboController()
        {
            accesoDatos = new ComboHandler();
        }

        public ComboController(IComboService servicio)
        {
            accesoDatos = servicio;
        }

        public ActionResult listaCombos()
        {
            ViewBag.combo = accesoDatos.obtenerCombos();
            return View("listaCombos");
        }

        [HttpGet]
        public ActionResult obtenerImagen(string nombre)
        {
            var tupla = accesoDatos.obtenerFoto(nombre);
            return File(tupla.Item1, tupla.Item2);
        }

        [HttpGet]
        public ActionResult agregarCombo()
        {
            ViewBag.pizzas = accesoDatos.obtenerNombresPizzas();
            ViewBag.bebidas = accesoDatos.obtenerNombresBebidas();
            ViewBag.acompanantes = accesoDatos.obtenerNombresAcompanantes();
            return View("agregarCombo");
        }

        [HttpPost]
        public ActionResult agregarCombo(ComboModel combo)
        {
            ViewBag.pizzas = accesoDatos.obtenerNombresPizzas();
            ViewBag.bebidas = accesoDatos.obtenerNombresBebidas();
            ViewBag.acompanantes = accesoDatos.obtenerNombresAcompanantes();
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    ViewBag.ExitoAlCrear = accesoDatos.agregarCombo(combo);
                    if (ViewBag.ExitoAlCrear)
                    {
                        ViewBag.Message = "El combo " + combo.nombre + " fue creado con éxito.";
                        ModelState.Clear();
                    }
                }
                return View("agregarCombo");
            }
            catch
            {
                ViewBag.Message = "Algo salió mal y no fue posible crear el combo";
                return View("agregarCombo");
            }
        }
    }
}