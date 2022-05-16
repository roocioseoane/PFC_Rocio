using DT = System.Data;
using QC = Microsoft.Data.SqlClient;
/**En Herramientas>Administrador de paquetes NuGet> 
Consola del Administrador de paquetes ponemos:
Install-Package Microsoft.Data.SqlClient -Version 3.0.0
para instalar los paquetes de microsoft data**/
/*Esta clase lleva a cabo toda la conexión de la base de datos*/
/*Esta clase puede ser copiada y pegada para cualquier tipo de
 * programa con conexión a base de datos*/

namespace API_ApuestasDeportivasApp
{
    public class Conexion
    {

        private QC.SqlConnection connection;

        public Conexion(string server, string bd, string user, string pass)
        {
            this.connection = new QC.SqlConnection(
                @$"Server={server}; Database={bd};
                User ID={user}; Password={pass};
                Encrypt=False;TrustServerCertificate=True;Connection Timeout=30;");
        }

        public System.Data.DataTable ejecutarConsulta(string consulta)
        {
            using (var command = new QC.SqlCommand())
            {
                command.Connection = this.connection;
                command.CommandType = DT.CommandType.Text;
                command.CommandText = consulta;

                command.Connection.Open();
                QC.SqlDataReader reader = command.ExecuteReader();
                System.Data.DataTable dt = new DT.DataTable();

                dt.Load(reader);
                command.Connection.Close();
                return dt;
            }
        }
    }

}
