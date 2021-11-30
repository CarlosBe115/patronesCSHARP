using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patronesCSHARP
{
    public abstract class Coccion
    {
        protected Filete filete;
        protected double currentTemp; //Temperatura actual
        protected double lowerTemp; //Temperatura menor
        protected double upperTemp; //Temperatura superior
        protected bool canEat; //¿Puede comer?

        public Filete Steaks
        {
            get { return filete; }
            set { filete = value; }
        }

        public double CurrentTemp
        {
            get { return currentTemp; }
            set { currentTemp = value; }
        }

        public abstract void AddTemp(double temp);
        public abstract void RemoveTemp(double temp);
        public abstract void DonenessCheck();
    }

    public class SinCocinar : Coccion
    {
        public SinCocinar(Coccion state)
        {
            currentTemp = state.CurrentTemp;
            filete = state.Steaks;
            Initialize();
        }

        private void Initialize()
        {
            lowerTemp = 0;
            upperTemp = 130;
            canEat = false;
        }

        //Subir temperatura
        public override void AddTemp(double amount)
        {
            currentTemp += amount;
            DonenessCheck();
        }

        //Bajar temperatura
        public override void RemoveTemp(double amount)
        {
            currentTemp -= amount;
            DonenessCheck();
        }

        //
        public override void DonenessCheck()
        {
            if (currentTemp > upperTemp)
            {
                filete.State = new Sellada(this);
            }
        }
    }

    public class Sellada : Coccion
    {
        public Sellada(Coccion state) : this(state.CurrentTemp, state.Steaks) { }

        public Sellada(double currentTemp, Filete filete)
        {
            this.currentTemp = currentTemp;
            this.filete = filete;
            canEat = true; //Se puede comer - No se recomienda
            Initialize();
        }

        private void Initialize()
        {
            lowerTemp = 130;
            upperTemp = 139.999999999999;
            canEat = true;
        }

        public override void AddTemp(double amount)
        {
            currentTemp += amount;
            DonenessCheck();
        }

        public override void RemoveTemp(double amount)
        {
            currentTemp -= amount;
            DonenessCheck();
        }

        public override void DonenessCheck()
        {
            if (currentTemp < lowerTemp) filete.State = new SinCocinar(this);
            else if (currentTemp > upperTemp) filete.State = new PocoHecha(this);
        }
    }

    public class PocoHecha : Coccion
    {
        public PocoHecha(Coccion state) : this(state.CurrentTemp, state.Steaks) { }

        public PocoHecha(double currentTemp, Filete filete)
        {
            this.currentTemp = currentTemp;
            this.filete = filete;
            canEat = true;
            Initialize();
        }

        private void Initialize()
        {
            lowerTemp = 140;
            upperTemp = 154.9999999999;
        }

        public override void AddTemp(double amount)
        {
            currentTemp += amount;
            DonenessCheck();
        }

        public override void RemoveTemp(double amount)
        {
            currentTemp -= amount;
            DonenessCheck();
        }

        public override void DonenessCheck()
        {
            if (currentTemp < 0.0)
            {
                filete.State = new SinCocinar(this);
            }
            else if (currentTemp < lowerTemp)
            {
                filete.State = new Sellada(this);
            }
            else if (currentTemp > upperTemp)
            {
                filete.State = new AlPunto(this);
            }
        }
    }

    public class AlPunto : Coccion
    {
        public AlPunto(Coccion state) : this(state.CurrentTemp, state.Steaks) { }

        public AlPunto(double currentTemp, Filete filete)
        {
            this.currentTemp = currentTemp;
            this.filete = filete;
            canEat = true;
            Initialize();
        }

        private void Initialize()
        {
            lowerTemp = 155;
            upperTemp = 169.9999999999;
        }

        public override void AddTemp(double amount)
        {
            currentTemp += amount;
            DonenessCheck();
        }

        public override void RemoveTemp(double amount)
        {
            currentTemp -= amount;
            DonenessCheck();
        }

        public override void DonenessCheck()
        {
            if (currentTemp < 130)
            {
                filete.State = new SinCocinar(this);
            }
            else if (currentTemp < lowerTemp)
            {
                filete.State = new PocoHecha(this);
            }
            else if (currentTemp > upperTemp)
            {
                filete.State = new Hecha(this);
            }
        }
    }

    public class Hecha : Coccion
    {
        public Hecha(Coccion state) : this(state.CurrentTemp, state.Steaks) { }

        public Hecha(double currentTemp, Filete filete)
        {
            this.currentTemp = currentTemp;
            this.filete = filete;
            canEat = true;
            Initialize();
        }

        private void Initialize()
        {
            lowerTemp = 170;
            upperTemp = 230;
        }

        public override void AddTemp(double amount)
        {
            currentTemp += amount;
            DonenessCheck();
        }

        public override void RemoveTemp(double amount)
        {
            currentTemp -= amount;
            DonenessCheck();
        }

        public override void DonenessCheck()
        {
            if (currentTemp < 0)
            {
                filete.State = new SinCocinar(this);
            }
            else if (currentTemp < lowerTemp)
            {
                filete.State = new AlPunto(this);
            }
        }
    }

    public class Filete
    {
        private Coccion _state;
        private string _beefCut;

        public Filete(string beefCut)
        {
            _beefCut = beefCut;
            _state = new Sellada(0.0, this);
        }

        public double CurrentTemp
        {
            get { return _state.CurrentTemp; }
        }

        public Coccion State
        {
            get { return _state; }
            set { _state = value; }
        }

        public void AddTemp(double amount)
        {
            _state.AddTemp(amount);
            Console.WriteLine("Incrementando en {0} grados.", amount);
            Console.WriteLine("Temperaruta actual {0}", CurrentTemp);
            Console.WriteLine("Estado es {0}", State.GetType().Name);
            Console.WriteLine("");
        }

        public void RemoveTemp(double amount)
        {
            _state.RemoveTemp(amount);
            Console.WriteLine("Decremento en {0} grados.", amount);
            Console.WriteLine("Temperaruta actual  {0}", CurrentTemp);
            Console.WriteLine("Estado es {0}", State.GetType().Name);
            Console.WriteLine("");
        }
    }

}
