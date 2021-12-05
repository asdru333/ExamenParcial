using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaNovita.Models;

namespace PizzaNovita.Moqs
{
    public interface IPedidoService
    {
        List<PedidoModel> obtenerPedidos();

        bool agregarPedido(PedidoModel pedido);
    }
}