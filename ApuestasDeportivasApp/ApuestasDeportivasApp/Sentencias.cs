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

    }

}
