using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PizzaNovita.Models
{
    public class ComestibleModel
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Es necesario que ingrese el nombre del comestible")]
        public string nombre { get; set; }

        [Display(Name = "Precio")]
        [Required(ErrorMessage = "Es necesario que ingrese el precio del comestible")]
        [RegularExpression("^[0-9]+(.[0-9]+){0,1}$", ErrorMessage = "Debe ingresar números")]
        public double precio { get; set; }

        [Display(Name = "Foto del comestible")]
        [Required(ErrorMessage = "Es necesario que ingrese la foto del comestible")]
        public HttpPostedFileBase fotoArchivo { get; set; }

        public string fotoTipo { get; set; }
    }
}