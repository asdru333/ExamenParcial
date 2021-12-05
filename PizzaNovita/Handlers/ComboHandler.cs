using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System;
using System.Web.Mvc;
using PizzaNovita.Models;
using PizzaNovita.Moqs;

namespace PizzaNovita.Handlers
{
    public class ComboHandler : BaseDatosHandler, IComboService
    {
        ArchivosHandler manejadorDeImagen = new ArchivosHandler();

        public List<ComboModel> obtenerCombos()
        {
            string consulta = "SELECT * FROM Comestible C JOIN Combo Co ON C.nombrePK = Co.nombreFK;";
            List<ComboModel> combo = new List<ComboModel>();
            DataTable tabla = leerBaseDeDatos(consulta);
            foreach (DataRow columna in tabla.Rows)
            {
                combo.Add(
                    new ComboModel
                    {
                        nombre = Convert.ToString(columna["nombrePK"]),
                        precio = Convert.ToDouble(columna["precio"]),
                        pizza = Convert.ToString(columna["pizzaFK"]),
                        bebida = Convert.ToString(columna["bebidaFK"]),
                        acompanante = Convert.ToString(columna["acompananteFK"])
                    });
            }
            return combo;
        }

        public bool agregarCombo(ComboModel combo)
        {
            string ConsultaComestible = "INSERT INTO Comestible ( nombrePK, precio, fotoArchivo, fotoTipo ) "
                + "VALUES ( @nombre, @precio, @fotoArchivo, @fotoTipo );";

            string ConsultaCombo = "INSERT INTO Combo (nombreFK, pizzaFK, bebidaFK, acompananteFK ) "
                + "VALUES (@nombreCombo, @pizza, @bebida, @acompanante );";

            Dictionary<string, object> valoresParametrosComestible = new Dictionary<string, object> {
                {"@nombre", combo.nombre },
                {"@precio", combo.precio },
                {"@fotoTipo", combo.fotoArchivo.ContentType }
            };
            valoresParametrosComestible.Add("@fotoArchivo", manejadorDeImagen.ConvertirArchivoABytes(combo.fotoArchivo));

            Dictionary<string, object> valoresParametrosCombo = new Dictionary<string, object> {
                {"@nombreCombo", combo.nombre },
                {"@pizza", combo.pizza },
                {"@bebida", combo.bebida },
                {"@acompanante", combo.acompanante }
            };

            return (insertarEnBaseDatos(ConsultaComestible, valoresParametrosComestible) && insertarEnBaseDatos(ConsultaCombo, valoresParametrosCombo));
        }

        public Tuple<byte[], string> obtenerFoto(string nombre)
        {
            string columnaContenido = "fotoArchivo";
            string columnaTipo = "fotoTipo";
            string consulta = "SELECT " + columnaContenido + ", " + columnaTipo + " FROM Comestible WHERE nombrePK = @nombre";
            KeyValuePair<string, object> parametro = new KeyValuePair<string, object>("@nombre", nombre);
            return obtenerArchivo(consulta, parametro, columnaContenido, columnaTipo);
        }

        public List<SelectListItem> obtenerLista(string consulta)
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            DataTable tabla = leerBaseDeDatos(consulta);
            string item = "";
            foreach (DataRow columna in tabla.Rows)
            {
                item = (Convert.ToString(columna["nombrePK"]));
                lista.Add(new SelectListItem { Text = item, Value = item });
            }
            return lista;
        }

        public List<SelectListItem> obtenerNombresPizzas()
        {
            string consulta = "SELECT nombrePK FROM Comestible C JOIN Pizza P ON C.nombrePK = P.nombreFK WHERE P.personalizada = 0;";
            return obtenerLista(consulta);
        }

        public List<SelectListItem> obtenerNombresBebidas()
        {
            string consulta = "SELECT nombrePK FROM Comestible C JOIN Bebida B ON C.nombrePK = B.nombreFK;";
            return obtenerLista(consulta);
        }

        public List<SelectListItem> obtenerNombresAcompanantes()
        {
            string consulta = "SELECT nombrePK FROM Comestible C JOIN Acompanante A ON C.nombrePK = A.nombreFK;";
            return obtenerLista(consulta);
        }
    }
}