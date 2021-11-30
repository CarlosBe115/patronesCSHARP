using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace patronesCSHARP
{
    public class Originator
    {
        private string _stateFruit;

        public Originator(string state)
        {
            this._stateFruit = state;
            Console.WriteLine("Mi estado inicial es: " + state);
        }

        public void DoSomething()
        {
            Console.Write("Ingresa: "); this._stateFruit = Console.ReadLine();
        }

        public IMemento Save() { return new ConcreteMemento(this._stateFruit); }

        // Restores the Originator's state from a memento object.
        public void Restore(IMemento memento)
        {
            if (!(memento is ConcreteMemento))
                throw new Exception("Clase de recuerdo desconocida " + memento.ToString());

            this._stateFruit = memento.GetState();
            Console.Write($"Estado ha cambiado a: {_stateFruit}");
        }
    }

    //Proporciona forma de recuperar, No expone estado
    public interface IMemento
    {
        string GetName();
        string GetState();
        DateTime GetDate();
    }

    //El Concrete Memento contiene la infraestructura para almacenarr
    class ConcreteMemento : IMemento
    {
        private string _stateFruit;
        private DateTime _date;

        public ConcreteMemento(string state)
        {
            this._stateFruit = state;
            this._date = DateTime.Now;
        }

        public string GetState() { return this._stateFruit; }

        public string GetName() { return $"{this._date} / ({this._stateFruit})..."; }

        public DateTime GetDate() { return this._date; }
    }

    // The Caretaker no depende de la clase Concrete Memento.
    // Funciona con todos los recuerdos a través de la interfaz base de Memento.
    class Caretaker
    {
        private List<IMemento> _mementos = new List<IMemento>();
        private Originator _originator = null;

        public Caretaker(Originator originator) {this._originator = originator;}

        public void Backup()
        {
            Console.WriteLine("\nGuardando el estado del originador ...");
            this._mementos.Add(this._originator.Save());
        }

        public void Undo()
        {
            if (this._mementos.Count == 0) { return;}

            var memento = this._mementos.Last();
            this._mementos.Remove(memento);

            Console.WriteLine("Restaurando el estado a: " + memento.GetName());

            try { this._originator.Restore(memento); }
            catch (Exception) { this.Undo(); }
        }

        public void ShowHistory()
        {
            Console.WriteLine("Aquí está la lista de guardado: ");

            foreach (var memento in this._mementos)
            {
                Console.WriteLine(memento.GetName());
            }
        }
    }
}
