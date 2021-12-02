using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PizzaNovita.Models;
using PizzaNovita.Handlers;

namespace PizzaNovita.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ComboHandler accesoDatos = new ComboHandler();
            ViewBag.combo = accesoDatos.obtenerCombos();
            return View("Index");
        }
    }
}