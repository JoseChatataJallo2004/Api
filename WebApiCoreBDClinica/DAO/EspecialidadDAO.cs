using System.Data.SqlClient;
using WebApiCoreBDClinica.Entidades;

namespace WebApiCoreBDClinica.DAO
{
    public class EspecialidadDAO
    {

        /*public List<Especialidad> ListarEspecialidad()
        {
            var lista = new List<Especialidad>();
            SqlDataReader dr = SqlHelper.ExecuteReader(cad_conexion, "PA_ESPECIALIDAD");
            while (dr.Read())
            {
                lista.Add(new Especialidad()
                {
                    codesp = dr.GetString(0),
                    nomesp = dr.GetString(1),
                    costo = dr.GetDecimal(2),
                    eliminado = dr.GetString(3)
                });
            }
            dr.Close();


            return lista;
        }*/

    }
}
