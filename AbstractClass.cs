using System;

namespace patronesCSHARP
{
    public abstract class AbstractClass
    {
        public void TemplateMethod(double medida)
        {
            this.OperacionExample();
            this.Area(medida);
            this.Perimetro(medida);
        }

        protected void OperacionExample()
        {
            Console.WriteLine("Iniciando cualculos...");
        }

        protected abstract void Area(double medida);

        protected abstract void Perimetro(double medida);
    }

    class ConcreteClassSquare : AbstractClass
    {
        protected override void Area(double medida)
        {
            Console.WriteLine("\tArea de un cuadrado");
            Console.WriteLine("\t\tMedida de un lado: {0} \t Area resultante: {1}", medida, Math.Pow(medida, 2));
        }

        protected override void Perimetro(double medida)
        {
            Console.WriteLine("\tPerimetro de un cuadrado");
            Console.WriteLine("\t\tMedida de un lado: {0} \t Perimetro resultante: {1}", medida, medida * 4);
        }
    }

    class ConcreteClassCircle : AbstractClass
    {
        protected override void Area(double medida)
        {
            Console.WriteLine("\tArea de un circulo");
            Console.WriteLine("\t\tRadio: {0} \t Area resultante: {1}", medida, Math.PI * Math.Pow(medida, 2));
        }

        protected override void Perimetro(double medida)
        {
            Console.WriteLine("\tPerimetro de un circulo");
            Console.WriteLine("\t\tMedida del diametro: {0} \t Perimetro resultante: {1}", medida * 2, Math.PI * (medida * 2));
        }
    }

    class ClientTM
    {
        public static void ClientCode(AbstractClass abstractClass, double medida)
        {
            abstractClass.TemplateMethod(medida);
        }
    }

}
