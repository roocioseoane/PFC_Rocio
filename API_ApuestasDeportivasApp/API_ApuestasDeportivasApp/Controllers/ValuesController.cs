using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ApuestasDeportivasApp.Controllers
{
    [Route("CasaDeApuestas")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        Conexion conexion = new Conexion("localhost", "apuestasDeportivasApp", "RocioSeoane", "AbCdEf84");
        
        // POST Registrarse
        [HttpPost("Registrarse")]
        public void registrarse(string usuario, string clave)
        {
            string consulta = $"exec registrar '{usuario}', '{clave}'";
            DataTable dt;
            dt = conexion.ejecutarConsulta(consulta);
        }

        // GET Logearse
        [HttpGet("Logearse")]
        public IEnumerable<string> logearse(string login, string clave)
        {
            string consulta = $"exec logear '{login}', '{clave}'";
            DataTable dt;
            dt = conexion.ejecutarConsulta(consulta);

            return new string[] { dt.Rows[0]["id_usuario"].ToString() };
        }

        // POST IngresarTransaccion
        [HttpPost("IngresoTransaccion")]
        public void ingresarTransaccion(int cantidad, int id_usuario)
        {
            string consulta = $"exec ingresarTransaccion {cantidad}, {id_usuario}";
            DataTable dt;
            dt = conexion.ejecutarConsulta(consulta);
        }

        // POST RetiroTransaccion
        [HttpPost("RetiroTransaccion")]
        public void retiroTransaccion(int cantidad, int id_usuario)
        {
            string consulta = $"exec retirarTransaccion {cantidad}, {id_usuario}";
            DataTable dt;
            dt = conexion.ejecutarConsulta(consulta);
        }

        // POST InsertarTipoEventos
        [HttpPost("InsertarTipoEventos")]
        public void insertarTipoEventos(string nombre, string descripcion)
        {
            string consulta = $"exec insertarTipoEventos '{nombre}', '{descripcion}'";
            DataTable dt;
            dt = conexion.ejecutarConsulta(consulta);
        }

        // POST InsertarEventos
        [HttpPost("InsertarEventos")]
        public void insertarEventos(string nombre, string fecha, int id_tipoEvento)
        {
            string consulta = $"exec insertarEventos '{nombre}', '{fecha}', '{id_tipoEvento}'";
            DataTable dt;
            dt = conexion.ejecutarConsulta(consulta);
        }

        // POST InsertarOpciones
        [HttpPost("InsertarOpciones")]
        public void insertarOpciones(string nombre, int multiplicador, int id_evento)
        {
            string consulta = $"exec insertarOpciones '{nombre}', {multiplicador}, {id_evento}";
            DataTable dt;
            dt = conexion.ejecutarConsulta(consulta);
        }

        // POST HacerApuesta
        [HttpPost("HacerApuesta")]
        public void hacerApuesta(int cantidad, int id_usuario, int id_evento, int id_opcion)
        {
            string consulta = $"exec hacerApuesta {cantidad}, {id_usuario}, {id_evento}, {id_opcion}";
            DataTable dt;
            dt = conexion.ejecutarConsulta(consulta);
        }

        // POST ApuestaGanada
        [HttpPost("ApuestaGanada")]
        public void apuestaGanada(int id_evento, int id_opcion)
        {
            string consulta = $"exec apuestaGanada {id_evento}, {id_opcion}";
            DataTable dt;
            dt = conexion.ejecutarConsulta(consulta);
        }

    }
}
