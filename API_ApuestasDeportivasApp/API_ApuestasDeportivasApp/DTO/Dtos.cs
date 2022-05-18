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

}
