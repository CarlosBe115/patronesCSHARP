using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patronesCSHARP.AF.Clases
{
   public class PizzeriaValeros : Pizzeria
    {
        public override Pizza CrearPizza()
        {
            return new PizzaHawaiana();
        }
    }
}
