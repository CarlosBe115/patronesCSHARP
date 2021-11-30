using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patronesCSHARP
{
    public class Flyweight
    {
        private Car _sharedState;

        public Flyweight(Car car) {this._sharedState = car;}

        public void Operation(Car uniqueState)
        {
            string s = JsonConvert.SerializeObject(this._sharedState);
            string u = JsonConvert.SerializeObject(uniqueState);
            Console.WriteLine($"Flyweight: Mostrando estado {s} compartido y exclusivo {u}");
        }
    }
 
    public class FlyweightFactory
    {
        private List<Tuple<Flyweight, string>> flyweights = new List<Tuple<Flyweight, string>>();

        public FlyweightFactory(params Car[] args)
        {
            foreach (var elem in args)
            {
                flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(elem), this.getKey(elem)));
            }
        }

        // Returns a Flyweight's string hash for a given state.
        public string getKey(Car key)
        {
            List<string> elements = new List<string>();

            elements.Add(key.modelo);
            elements.Add(key.color);
            elements.Add(key.compañia);

            if (key.dueño != null && key.number != null)
            {
                elements.Add(key.number);
                elements.Add(key.dueño);
            }

            elements.Sort();

            return string.Join("_", elements);
        }

        //Devuelve
        public Flyweight GetFlyweight(Car sharedState)
        {
            string key = this.getKey(sharedState);

            if (flyweights.Where(t => t.Item2 == key).Count() == 0)
            {
                Console.WriteLine("FlyweightFactory: No se ha encontrado flyweights, creando uno nuevo.");
                this.flyweights.Add(new Tuple<Flyweight, string>(new Flyweight(sharedState), key));
            }
            else Console.WriteLine("FlyweightFactory: Reutilizando flyweights existente.");

            return this.flyweights.Where(t => t.Item2 == key).FirstOrDefault().Item1;
        }

        public void listFlyweights()
        {
            var count = flyweights.Count;
            Console.WriteLine($"\nFlyweightFactory: Hay {count} flyweights:");
            foreach (var flyweight in flyweights)
            {
                Console.WriteLine("\t"+flyweight.Item2);
            }
        }

    }

    public class Car
    {
        public string dueño { get; set; }

        public string number { get; set; }

        public string compañia { get; set; }

        public string modelo { get; set; }

        public string color { get; set; }
    }
}
