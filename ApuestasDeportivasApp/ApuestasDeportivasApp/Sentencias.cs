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

            Console.WriteLine("Id de la opción a la que quieres apostar: ");
            String id_opcion = Console.ReadLine();
            int _id_opcion = Convert.ToInt32(id_opcion);

            dt = conexion.ejecutarConsulta("exec hacerApuesta " + _cantidad + "," + id_usuario + "," + _id_evento + "," + _id_opcion);
            dr = dt.Rows[0];

            if (int.Parse(dr[0].ToString()) == 0)
            {
                Console.WriteLine("Apuesta realizada correctamente");
            }
            else
                Console.WriteLine("Cantidad de saldo insuficiente");
        }

        public void apuestaGanada()
        {
            mostrarEventos();

            Console.WriteLine("Id del evento: ");
            String id_evento = Console.ReadLine();
            int _id_evento = Convert.ToInt32(id_evento);

            mostrarOpcionesEvento(_id_evento);

            Console.WriteLine("Id de la opción a la que quieres mirar: ");
            String id_opcion = Console.ReadLine();
            int _id_opcion = Convert.ToInt32(id_opcion);

            dt = conexion.ejecutarConsulta("exec apuestaGanada " + _id_evento + "," + _id_opcion);

            dr = dt.Rows[0];
            Console.WriteLine(dr[1].ToString());
        }

        public void insertarTipoEventos()
        {
            mostrarTipoEventos();

            Console.WriteLine("Insertar tipo eventos");
            Console.WriteLine("Nombre del tipo del evento: ");
            String nombre = Console.ReadLine();
            Console.WriteLine("Descripción del evento: ");
            String descripcion = Console.ReadLine();

            dt = conexion.ejecutarConsulta("exec insertarTipoEventos " + "'" + nombre + "','" + descripcion + "'");

            dr = dt.Rows[0];
            Console.WriteLine(dr[1].ToString());
        }

        public void insertarEventos()
        {
            mostrarEventos();

            Console.WriteLine("Insertar eventos");
            Console.WriteLine("Nombre del evento: ");
            String nombre = Console.ReadLine();

            Console.WriteLine("Fecha del evento (Formato: AA-MM-DD HH:MM:SS)");
            String fecha =Console.ReadLine();
            DateTime _fecha = Convert.ToDateTime(fecha);

            mostrarTipoEventos();

            Console.WriteLine("Id del tipo del evento: ");
            String id_tipoEvento = Console.ReadLine();
            int _id_tipoEvento = Convert.ToInt32(id_tipoEvento);

            dt = conexion.ejecutarConsulta("exec insertarEventos " + "'" + nombre + "','" + _fecha + "'," + _id_tipoEvento);

            dr = dt.Rows[0];
            Console.WriteLine(dr[1].ToString());
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

        public void mostrarTipoEventos()
        {
            dt = conexion.ejecutarConsulta("exec mostrarTipoEventos");

            dr = dt.Rows[0];
            Console.WriteLine(dr[0].ToString());
        }
    }

}
