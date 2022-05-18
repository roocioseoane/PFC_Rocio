using Microsoft.AspNetCore.Mvc;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API_ApuestasDeportivasApp
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

        // GET MostrarEventos
        [HttpGet("MostrarEventos")]
        public IEnumerable<evento> mostrarEventos()
        {
            List<evento> lista = new List<evento>();
            DataTable dt;
            dt = conexion.ejecutarConsulta($"exec mostrarEventos");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                evento eve = new evento();
                eve.id_eventos = int.Parse(dt.Rows[i]["id_evento"].ToString());
                eve.nombre = dt.Rows[i]["nombre"].ToString();
                eve.fecha = dt.Rows[i]["fecha"].ToString();
                eve.id_tipoEvento = int.Parse(dt.Rows[i]["id_tipoEvento"].ToString());
                lista.Add(eve);
            }
            return lista;
        }

        // GET MostrarTransacciones
        [HttpGet("MostrarTransacciones")]
        public IEnumerable<transacciones> mostrarTransacciones(int id_usuario)
        {
            List<transacciones> lista = new List<transacciones>();
            DataTable dt;
            dt = conexion.ejecutarConsulta($"exec mostrarTransacciones {id_usuario}");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                transacciones tr = new transacciones();
                tr.id_transaccion = int.Parse(dt.Rows[i]["id_transaccion"].ToString());
                tr.fecha = dt.Rows[i]["fecha"].ToString();
                tr.saldoInicial = decimal.Parse(dt.Rows[i]["saldo_inicial"].ToString());
                tr.cantidad = decimal.Parse(dt.Rows[i]["cantidad"].ToString());
                tr.id_usuario = id_usuario;
                tr.id_tipoTransaccion = int.Parse(dt.Rows[i]["id_tipoTransaccion"].ToString());
                lista.Add(tr);
            }
            return lista;
        }

        / GET MostrarApuestas
        [HttpGet("MostrarApuestas")]
        public IEnumerable<apuestas> mostrarApuestas(int id_usuario)
        {
            List<apuestas> lista = new List<apuestas>();
            DataTable dt;
            dt = conexion.ejecutarConsulta($"exec mostrarApuestas {id_usuario}");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                apuestas ap = new apuestas();
                ap.id_apuesta = int.Parse(dt.Rows[i]["id_apuesta"].ToString());
                ap.fecha = dt.Rows[i]["fecha"].ToString();
                ap.cantidad = int.Parse(dt.Rows[i]["cantidad"].ToString());
                ap.multiplicador = int.Parse(dt.Rows[i]["multiplicador"].ToString());
                ap.ganador = bool.Parse(dt.Rows[i]["ganador"].ToString());
                ap.id_usuario = id_usuario;
                ap.id_opcion = int.Parse(dt.Rows[i]["id_opcion"].ToString());
                ap.id_transaccionC = int.Parse(dt.Rows[i]["id_TransaccionC"].ToString());
                ap.id_transaccionP = int.Parse(dt.Rows[i]["id_TransaccionP"].ToString());
                lista.Add(ap);
            }
            return lista;
        }


    }
}
