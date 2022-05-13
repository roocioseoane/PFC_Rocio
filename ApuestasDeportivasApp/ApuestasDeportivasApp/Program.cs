using Microsoft.Data.SqlClient;
using System.Data;
using nombrespacio;

Conexion conexion = new Conexion("localhost", "apuestasDeportivasApp", "RocioSeoane", "AbCdEf84");
Usuarios usuarios = new Usuarios();
Sentencias sentencias = new Sentencias();
Admin admin = new Admin();

bool salirDelBucle = false;
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

int conseguirId()
{
    while (!salirDelBucle)
    {
        _opcion = menu();

        switch (_opcion)
        {
            case 0:
                salirDelBucle = true;
                break;
            case 1:
                if((id_usuario = sentencias.logearUsuario()) != -1)
                {
                    salirDelBucle = true;
                }
                break;
            case 2:
                if (sentencias.registrarUsuario() == 0)
                {
                    Console.WriteLine("Registrado correctamente");
                    salirDelBucle = false;
                }
                else
                    Console.WriteLine("No se ha podido registrar");
                break;
            default:
                Console.WriteLine("Error");
                break;
        }
    }
    return id_usuario;
}

salirDelBucle = false;

while (!salirDelBucle)
{
    _opcion=usuarios.menu();

    switch (_opcion)
    {
        case 0:
            salirDelBucle=true;
            break;
        case 1:
            sentencias.ingresoTransccion(id_usuario);
            break;
        case 2:
            sentencias.retiroTransaccion(id_usuario);
            break;
        case 3:
            sentencias.hacerApuesta(id_usuario);
            break;
        case 4:
            sentencias.apuestaGanada();
            break;
        case 5:
            sentencias.mostrarEventos();
            break;
        case 6:
            sentencias.mostrarTransacciones(id_usuario);
            break ;
        case 7:
            sentencias.mostrarApuestas(id_usuario);
            break;
        default:
            Console.WriteLine("Error");
            break;
    }
}