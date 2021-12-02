using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaNovita.Models;
using PizzaNovita.Handlers;


namespace PizzaNovita.Controllers
{
    public class ComboController : Controller
    {
        public ActionResult listaCombos()
        {
            ComboHandler accesoDatos = new ComboHandler();
            ViewBag.combo = accesoDatos.obtenerCombos();
            return View("listaCombos");
        }

        [HttpGet]
        public ActionResult obtenerImagen(string nombre)
        {
            ComboHandler comboHandler = new ComboHandler();
            var tupla = comboHandler.obtenerFoto(nombre);
            return File(tupla.Item1, tupla.Item2);
        }

        [HttpGet]
        public ActionResult agregarCombo()
        {
            ComboHandler comboHandler = new ComboHandler();
            ViewBag.pizzas = comboHandler.obtenerNombresPizzas();
            ViewBag.bebidas = comboHandler.obtenerNombresBebidas();
            ViewBag.acompanantes = comboHandler.obtenerNombresAcompanantes();
            return View("agregarCombo");
        }

        [HttpPost]
        public ActionResult agregarCombo(ComboModel combo)
        {
            ComboHandler comboHandler = new ComboHandler();
            ViewBag.pizzas = comboHandler.obtenerNombresPizzas();
            ViewBag.bebidas = comboHandler.obtenerNombresBebidas();
            ViewBag.acompanantes = comboHandler.obtenerNombresAcompanantes();
            ViewBag.ExitoAlCrear = false;
            try
            {
                if (ModelState.IsValid)
                {
                    ComboHandler accesoDatos = new ComboHandler();
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