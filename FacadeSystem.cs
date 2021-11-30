using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patronesCSHARP
{
    public class FacadeSystem
    {
        private Autentificacion autentificacion = new Autentificacion();
        private Cajero cajero = new Cajero();
        private Cuenta cuenta = null;



        public void introducirCredenciales()
        {
            bool tarjeta_correcta = autentificacion.leerTarjeta();

            if (tarjeta_correcta)
            {
                String clave = autentificacion.introducirClave();

                bool clave_correcta = autentificacion.comprobarClave(clave);

                if (clave_correcta)
                {
                    cuenta = autentificacion.obtenerCuenta();

                    return;
                }
            }
            autentificacion.alFallar();
        }

        public void sacarDinero()
        {
            if (cuenta != null)
            {
                Console.Write("Cantidad A Retirar: ");
                int monto = int.Parse(Console.ReadLine());
                int cantidad = cajero.introducirCantidad(monto); ;
                bool tiene_dinero = cajero.tieneSaldo(cantidad);

                if (tiene_dinero)
                {
                    bool hay_saldo_suficiente = ((int)cuenta.comprobarSaldoDisponible()) >= monto;

                    if (hay_saldo_suficiente)
                    {
                        cuenta.bloquearCuenta();
                        cuenta.retirarSaldo(monto);
                        cuenta.actualizarCuenta();
                        cuenta.desbloquearCuenta();
                        cajero.expedirDinero(monto);
                        cajero.imprimirTicket();

                    }else cuenta.alFallar();
                }

            }

        }

    }

    public class Autentificacion
    {
        public bool leerTarjeta() { Console.WriteLine("Leyendo tarjeta..."); return true; }

        public String introducirClave() { Console.Write("Introduccir clave: "); return Console.ReadLine(); }

        public bool comprobarClave(String clave) { if (clave == "123") return true; else return false; }

        public Cuenta obtenerCuenta() { Cuenta cuenta = new Cuenta(); return cuenta; }

        public void alFallar() { Console.WriteLine("Auntenticacion Fallida"); }

    }

    public class Cajero
    {
        int saldo = 10000;

        public int introducirCantidad(int cantidad) { saldo -= cantidad; return saldo; }

        public bool tieneSaldo(int cantidad) { if (saldo > 0) { Console.WriteLine("Transaccion Aceptada"); return true; } else { Console.WriteLine("Transaccion Rechazada"); return false; } }

        public int expedirDinero(int cantidad) { Console.WriteLine("Liberando Dinero: "+cantidad); return cantidad; }

        public void imprimirTicket() { Random r = new Random(); 
            Console.WriteLine("Num. Proceso: "+ r.Next(0, 1000000).ToString()+ "\nFecha De Expedicion: "+DateTime.Now.ToString("dd-MM-yyyy")+"\nHora: "+DateTime.Now.ToString("HH:mm:ss")) ; }

    }

    public class Cuenta
    {

        int saldo = 1000;

        public double comprobarSaldoDisponible() { Console.WriteLine("\nEl saldo de cuenta es: "+ saldo); return saldo; }

        public bool bloquearCuenta() { Console.WriteLine("Cuenta Bloqueada, Iniciando Proceso..."); return true; }

        public bool desbloquearCuenta() { Console.WriteLine("Cuenta Desbloqueada, Proceso Finalizado..."); return true; }

        public void retirarSaldo(int cantidad) { saldo -= cantidad; Console.WriteLine("El saldo retirado es de: "+cantidad); }

        public bool actualizarCuenta() { Console.WriteLine("Actualizando cuenta...\nSaldo de cuenta actual: " + saldo) ; ; return true;  }

        public void alFallar() { Console.WriteLine("Saldo Insificiente"); }

    }

}
