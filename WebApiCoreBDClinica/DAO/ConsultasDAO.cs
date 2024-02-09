using System.Data.SqlClient;
using WebApiCoreBDClinica.Entidades;

namespace WebApiCoreBDClinica.DAO
{
    public class ConsultasDAO
    {
        //la variable de la cadena de conexion
        private readonly string cad_conexion;

        public ConsultasDAO(IConfiguration _confi)
        {
            cad_conexion = _confi.GetConnectionString("cn1");
        }


        public List<PA_CITAS_MEDICO> CITASMEDICOS(string codmed)
        {
            var lista=new List<PA_CITAS_MEDICO>();

            SqlDataReader dr = SqlHelper.ExecuteReader(cad_conexion, "PA_CITAS_MEDICO", codmed);

            while (dr.Read())
            {
                lista.Add(new PA_CITAS_MEDICO()
                {
                    nrocita=dr.GetInt32(0),
                    fecha=dr.GetString(1),
                    codpac=dr.GetString(2),
                    nompac=dr.GetString(3),
                    pago=dr.GetDecimal(4),
                });

            }
            dr.Close();

            return lista;
        }


    }
}
