using System.Data.SqlClient;
using WebApiCoreBDClinica.Entidades;

namespace WebApiCoreBDClinica.DAO
{
    public class MedicosDAO
    {
        //la variable de la cadena de conexion
        private readonly string cad_conexion;
        //en el constructor le asignaremos la cadena de conexion del appsettings.json
        public MedicosDAO(IConfiguration config)
        {
            cad_conexion = config.GetConnectionString("cn1");
        }

        public List<Medicos> ListarMedicos()
        {
            var lista=new List<Medicos>();
            SqlDataReader dr = SqlHelper.ExecuteReader(cad_conexion, "PA_MEDICOS");
            while (dr.Read())
            {
                lista.Add(new Medicos()
                {
                    codmed=dr.GetString(0),
                    nommed=dr.GetString(1),
                    anio_colegio=dr.GetInt32(2),
                    codesp=dr.GetString(3),
                    coddis=dr.GetString(4),
                    eliminado=dr.GetString(5)
                });
            }
            dr.Close();


            return lista;
        }


        public string grabarmedico(Medicos obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cad_conexion,"PA_INSERTAR_MEDICO",obj.codmed!,obj.nommed!,obj.anio_colegio,obj.codesp!,obj.coddis!);

                return $"El Medico {obj.nommed} fue registrado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }



        public string actualizarmedico(Medicos obj)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cad_conexion, "PA_ACTUALIZAR_MEDICO", obj.codmed!, obj.nommed!, obj.anio_colegio, obj.codesp!, obj.coddis!);

                return $"El Medico con codigo  {obj.codmed} fue actualizado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }


        public string eliminarmedico(string codmed)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(cad_conexion, "PA_ELIMINAR_MEDICO_LOG", codmed!);

                return $"El Medico con codigo  {codmed} fue eliminado correctamente";
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }

        //Consultas


        public List<Especialidad> ListarEspecialidad()
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
        }


        public List<Distritos> ListarDistritos()
        {
            var lista = new List<Distritos>();
            SqlDataReader dr =
              SqlHelper.ExecuteReader(cad_conexion, "PA_DISTRITOS");
            while (dr.Read())
            {
                lista.Add(
                  new Distritos()
                  {
                      coddis = dr.GetString(0),
                      nomdis = dr.GetString(1),
                      eliminado = dr.GetString(2)
                  });
            }
            dr.Close();
            return lista;
        }

    }
}
