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
    public class PedidoController : Controller
    {
        readonly IPedidoService accesoDatos;

        public PedidoController()
        {
            accesoDatos = new PedidoHandler();
        }

        public PedidoController(IPedidoService servicio)
        {
            accesoDatos = servicio;
        }

        public ActionResult listaPedidos()
        {
            ViewBag.pedidos = accesoDatos.obtenerPedidos();
            return View("listaPedidos");
        }

        [HttpGet]
        public ActionResult recoger(string nombre)
        {
            ComestibleHandler comestibleAccesoDatos = new ComestibleHandler();
            ComestibleModel comestible = comestibleAccesoDatos.obtenerComestible(nombre);
            ViewBag.nombreComestible = comestible.nombre;
            ViewBag.precio = comestible.precio;
            ViewBag.foto = comestible.fotoTipo;
            return View("recoger");
        }

        [HttpPost]
        public ActionResult recoger(PedidoModel pedido)
        {
            pedido.nombreComestible = Request.Form["nombreComestible"];
            pedido.precio = Double.Parse(Request.Form["precioComestible"]);
            pedido.direccion = "";
            pedido.tipo = "recoger";
            ViewBag.nombreComestible = pedido.nombreComestible;
            ViewBag.precio = pedido.precio;
            ViewBag.foto = Request.Form["fotoComestible"];
            ViewBag.exitoAlInscribir = false;
            try
            {
                ViewBag.exitoAlInscribir = accesoDatos.agregarPedido(pedido);
                if (ViewBag.exitoAlInscribir)
                {
                    ViewBag.Message = "El pedido fue realizado con exito";
                    ModelState.Clear();
                }
                return View("recoger");
            }
            catch
            {
                ViewBag.Message = "Algo salió mal.";
                return View("recoger");
            }
        }

        [HttpGet]
        public ActionResult aDomicilio(string nombre)
        {
            ComestibleHandler accesoDatos = new ComestibleHandler();
            ComestibleModel comestible = accesoDatos.obtenerComestible(nombre);
            ViewBag.nombreComestible = comestible.nombre;
            ViewBag.precio = comestible.precio + 1000;
            ViewBag.foto = comestible.fotoTipo;
            return View("aDomicilio");
        }

        [HttpPost]
        public ActionResult aDomicilio(PedidoModel pedido)
        {
            pedido.nombreComestible = Request.Form["nombreComestible"];
            pedido.precio = Double.Parse(Request.Form["precioComestible"]);
            pedido.tipo = "aDomicilio";
            ViewBag.nombreComestible = pedido.nombreComestible;
            ViewBag.precio = pedido.precio;
            ViewBag.foto = Request.Form["fotoComestible"];
            ViewBag.exitoAlInscribir = false;
            try
            {
                ViewBag.exitoAlInscribir = accesoDatos.agregarPedido(pedido);
                if (ViewBag.exitoAlInscribir)
                {
                    ViewBag.Message = "El pedido fue realizado con exito";
                    ModelState.Clear();
                }
                return View("aDomicilio");
            }
            catch
            {
                ViewBag.Message = "Algo salió mal.";
                return View("aDomicilio");
            }
        }
    }
}