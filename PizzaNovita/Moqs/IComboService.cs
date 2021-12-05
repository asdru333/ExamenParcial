using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using PizzaNovita.Models;


namespace PizzaNovita.Moqs
{
    public interface IComboService
    {
        List<ComboModel> obtenerCombos();

        bool agregarCombo(ComboModel combo);

        Tuple<byte[], string> obtenerFoto(string nombre);

        List<SelectListItem> obtenerNombresPizzas();

        List<SelectListItem> obtenerNombresBebidas();

        List<SelectListItem> obtenerNombresAcompanantes();
    }
}