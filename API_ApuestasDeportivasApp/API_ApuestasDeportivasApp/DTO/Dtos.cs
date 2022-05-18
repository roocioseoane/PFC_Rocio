namespace API_ApuestasDeportivasApp
{
    public class evento
    {
        public int id_eventos { get; set; }
        public string nombre { get; set; }
        public string fecha { get; set; }
        public int id_tipoEvento { get; set; }
    }

    public class transacciones
    {
        public int id_transaccion { get; set; }
        public string fecha { get; set; }
        public decimal saldoInicial { get; set; }
        public decimal cantidad { get; set; }
        public int id_usuario { get; set; }
        public int id_tipoTransaccion { get; set; }
    }

    public class apuestas
    {
        public int id_apuesta { get; set; }
        public string fecha { get; set; }
        public int cantidad { get; set; }
        public int multiplicador { get; set; }
        public bool? ganador { get; set; }
        public int id_usuario { get; set; }
        public int id_opcion { get; set; }
        public int? id_transaccionC { get; set; }
        public int id_transaccionP { get; set; }
    }

    public class opcionesEvento
    {
        public int id_opcion { get; set; }
        public string nombre { get; set; }
        public int multiplicador { get; set; }
        public bool? ganador { get; set; }
        public int id_evento { get; set; }
    }

    public class tipoEventos
    {
        public int id_tipoEvento { get; set; }
        public string nombre { get; set; }
        public string? descripcion { get; set; }
    }

}
