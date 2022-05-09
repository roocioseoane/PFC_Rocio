using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apuestas
{
    class Usuarios
    {
        public int menu()
        {
            string opcion;
            int op;
            Console.WriteLine("OPCIONES DE USUARIO");
            Console.WriteLine("\n___________________");
            Console.WriteLine("\n0.\tSalir");
            Console.WriteLine("\n1.\tIngresar dinero");
            Console.WriteLine("\n2.\tRetirar dinero");
            Console.WriteLine("\n3.\tRealizar apuesta");
            Console.WriteLine("\n4.\tComprobar apuesta");
            Console.WriteLine("\n5.\tVer eventos");
            Console.WriteLine("\n6.\tVer transacciones");
            Console.WriteLine("\n7.\tVer apuestas");

            do
            {
                opcion = Console.ReadLine();
                op = Convert.ToInt32(opcion);
            } while (op < 0 || op > 7);

            return op;
        }

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
    }
}