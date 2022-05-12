using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nombrespacio
{
    class Sentencias
    {
        Conexion conexion = null;
        DataTable dt;
        DataRow dr;

        public int registrarUsuario()
        {
            Console.WriteLine("Registrar usuario");
            Console.WriteLine("Introduce nombre de usuario: ");
            String nombre = Console.ReadLine();
            Console.WriteLine("Introduce contraseña: ");
            String clave = Console.ReadLine();

            dt = conexion.ejecutarConsulta("exec registrar '" + nombre + "'" + "'" + clave + "'");

            dr = dt.Rows[0];

            Console.WriteLine(dr[0].ToString());

            return int.Parse(dr[1].ToString());
        }
        public int logearUsuario()
        {
            Console.WriteLine("Logear usuario");
            Console.WriteLine("Introduce nombre de usuario: ");
            String nombre = Console.ReadLine();
            Console.WriteLine("Introduce contraseña: ");
            String clave = Console.ReadLine();

            dt = conexion.ejecutarConsulta("exec logear '" + nombre + "'" + "'" + clave + "'");

            dr = dt.Rows[0];

            if(dt.Rows.Count ==2)
            {
                Console.WriteLine(dr[1].ToString());
                return -1;
            }
            else
                return int.Parse(dr[0].ToString());
        }
        public void ingresoTransccion(int id_usuario)
        {
            Console.WriteLine("Ingreso saldo");
            Console.WriteLine("Cantidad a ingresar: ");
            String cantidad = Console.ReadLine();
            decimal _cantidad = Convert.ToDecimal(cantidad);

            dt = conexion.ejecutarConsulta("exec ingresarTransaccion "+cantidad+","+id_usuario);

            dr = dt.Rows[0];

            Console.WriteLine(dr[1].ToString());
        }
        public void retiroTransaccion(int id_usuario)
        {
            Console.WriteLine("Retiro saldo");
            Console.WriteLine("Cantidad a retirar: ");
            String cantidad = Console.ReadLine();
            decimal _cantidad = Convert.ToDecimal(cantidad);

            dt = conexion.ejecutarConsulta("exec retirarTransaccion " + _cantidad + "," + id_usuario);

            dr=dt.Rows[0];
            Console.WriteLine (dr[1].ToString());
        }
        public void hacerApuesta(int id_usuario)
        {
            Console.WriteLine("Hacer apuesta");
            Console.WriteLine("Cantidad a apostar: ");
            String cantidad = Console.ReadLine();
            decimal _cantidad = Convert.ToDecimal(cantidad);

            mostrarEventos();

            Console.WriteLine("Id del evento: ");
            String id_evento = Console.ReadLine();
            int _id_evento = Convert.ToInt32(id_evento);

            mostrarOpcionesEvento(_id_evento);

        }
        public void mostrarEventos()
        {
            dt = conexion.ejecutarConsulta("exec mostrarEventos");

            dr = dt.Rows[0];

            Console.WriteLine(dr[0].ToString());
        }
        public void mostrarOpcionesEvento(int id_evento)
        {
            dt = conexion.ejecutarConsulta("exec mostrarOpcionesEvento " + id_evento);

            dr = dt.Rows[0];
            Console.WriteLine(dr[0].ToString());
        }
    }

}
