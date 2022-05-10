using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombrespacio
{

    class Admin
    {
        public int menu()
        {
            string op;
            int opcion;
            Console.WriteLine("OPCIONES DE ADMINISTRADOR");
            Console.WriteLine("\n_________________________");
            Console.WriteLine("\n0.\tSalir");
            Console.WriteLine("\n1.\tIngresar dinero");
            Console.WriteLine("\n2.\tRetirar dinero");
            Console.WriteLine("\n3.\tRealizar apuesta");
            Console.WriteLine("\n4.\tComprobar apuesta");
            Console.WriteLine("\n5.\tVer eventos");
            Console.WriteLine("\n6.\tVer transacciones");
            Console.WriteLine("\n7.\tVer apuestas");
            Console.WriteLine("\n8.\tInsertar tipo de eventos");
            Console.WriteLine("\n9.\tInsertar eventos");
            Console.WriteLine("\n10.\tInsertar opciones");
            do
            {
                op = Console.ReadLine();
                opcion = Convert.ToInt32(op);
            } while (opcion < 0 || opcion > 10);
            return opcion;
        }
        /*Opciones comunes con los usuarios normales*/
        public void salir()
        {
            return;
        }
        public void ingresarDinero()
        {

        }
        public void retirarDinero()
        {

        }
        public void realizarApuesta()
        {

        }
        public void comprobarApuesta()
        {

        }
        public void verEventos()
        {

        }
        public void verTransacciones()
        {

        }
        public void verApuestas()
        {

        }
        /*Opciones solas del administrador*/
        public void insertarTipoEventos()
        {

        }
        public void insertarEventos()
        {

        }
        public void insertarOpciones()
        {

        }
    }
}
