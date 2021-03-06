using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PizzaNovita.Models
{
    public class AcompananteModel : ComestibleModel
    {
        [Display(Name = "Unidades")]
        [Required(ErrorMessage = "Es necesario que ingrese de cuantas unidades esta compuesto el acompañante")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Debe ingresar números")]
        public int unidades { get; set; }
    }
}