using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patronesCSHARP.Decorator
{
    public class Canela : AgregadoDecorator
    {
        public Canela(BebidaComponent bebida) : base(bebida) { }
        public override double Costo => _bebida.Costo + 1.75;
        public override string Descripcion => string.Format($"{_bebida.Descripcion} con Canela");
    }
}
