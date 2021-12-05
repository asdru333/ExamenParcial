using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PizzaNovita.Models;

namespace PizzaNovita.Moqs
{
    public interface IComestibleService
    {
        List<PizzaModel> obtenerPizzas(int personalizada);

        List<BebidaModel> obtenerBebidas();

        List<AcompananteModel> obtenerAcompanantes();

        bool agregarPizza(PizzaModel pizza);

        bool agregarPizzaPersonalizada(PizzaModel pizza);

        bool agregarIngredientes(string pizza, string ingrediente);

        bool agregarBebida(BebidaModel bebida);

        bool agregarAcompanante(AcompananteModel acompanante);

        Tuple<byte[], string> obtenerFoto(string nombre);
    }
}