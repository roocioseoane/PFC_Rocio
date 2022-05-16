﻿using Microsoft.AspNetCore.Mvc;
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

    }
}
