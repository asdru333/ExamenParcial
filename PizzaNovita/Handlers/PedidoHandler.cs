using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System;
using System.Web.Mvc;
using PizzaNovita.Models;

namespace PizzaNovita.Handlers
{
    public class PedidoHandler : BaseDatosHandler
    {
        public List<PedidoModel> obtenerPedidos()
        {
            string consulta = "SELECT * FROM Pedido;";
            List<PedidoModel> pedido = new List<PedidoModel>();
            DataTable tabla = leerBaseDeDatos(consulta);
            foreach (DataRow columna in tabla.Rows)
            {
                pedido.Add(
                    new PedidoModel
                    {
                        ID = Convert.ToInt32(columna["pedidoIDPK"]),
                        nombreComestible = Convert.ToString(columna["nombreComestibleFK"]),
                        nombreCliente = Convert.ToString(columna["nombreCliente"]),
                        apellidoCliente = Convert.ToString(columna["apellidoCliente"]),
                        direccion = Convert.ToString(columna["direccion"]),
                        precio = Convert.ToDouble(columna["precio"]),
                        tipo = Convert.ToString(columna["tipo"])
                    });
            }
            return pedido;
        }

        public bool agregarPedido(PedidoModel pedido)
        {
            string consulta = "INSERT INTO Pedido ( nombreComestibleFK, nombreCliente, apellidoCliente, direccion, precio, tipo ) "
                + "VALUES ( @comestible, @nombreCliente, @apellidoCliente, @direccion, @precio, @tipo );";

            Dictionary<string, object> valoresParametros = new Dictionary<string, object> {
                {"@comestible", pedido.nombreComestible },
                {"@nombreCliente", pedido.nombreCliente },
                {"@apellidoCliente", pedido.apellidoCliente },
                {"@direccion", pedido.direccion },
                {"@precio", pedido.precio },
                {"@tipo", pedido.tipo }
            };

            return (insertarEnBaseDatos(consulta, valoresParametros));
        }
    }
}
