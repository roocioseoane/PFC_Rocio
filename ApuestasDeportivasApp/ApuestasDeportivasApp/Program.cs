using Microsoft.Data.SqlClient;
using System.Data;
using nombrespacio;

Conexion conexion = new Conexion("localhost", "apuestasDeportivasApp", "RocioSeoane", "AbCdEf84");
Usuarios usuarios = new Usuarios();
Admin admin = new Admin();

int _opcion, id_usuario = -1;
String opcion;

int menu()
{
    Console.WriteLine("OPCIONES DE LA APLICACIÓN");
    Console.WriteLine("\n_________________________");
    Console.WriteLine("\n0.\tSalir");
    Console.WriteLine("\n1.\tRegistrarse");
    Console.WriteLine("\n2.\tLogearse");
    do
    {
        opcion = Console.ReadLine();
        _opcion = Convert.ToInt32(opcion);
    } while (_opcion < 0 || _opcion > 2);

    return _opcion;
}