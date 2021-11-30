using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patronesCSHARP.AF.Clases
{
    public abstract class Pizza
    {
        protected string _descripcion;
        protected string _nombre;

        public object Descripcion
        {
            get
            {
                return _descripcion;
            }
        }
        public object Nombre
        {
            get
            {
                return _nombre;
            }
        }
    }
}
