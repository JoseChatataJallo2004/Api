using Microsoft.AspNetCore.Mvc;
using WebApiCoreBDClinica.DAO;
using WebApiCoreBDClinica.Entidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiCoreBDClinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicosAPIController : ControllerBase
    {

        private readonly MedicosDAO dao;
        private readonly ConsultasDAO consult_dao;
        public MedicosAPIController(MedicosDAO _dao,ConsultasDAO _consult_dao)
        {
            dao= _dao;
            consult_dao= _consult_dao;
        }

        [HttpGet("GetCitasMedicos/{codmed}")]
        public List<PA_CITAS_MEDICO> GetCitasMedicos(string codmed)
        {
            var listado = consult_dao.CITASMEDICOS(codmed);
            return listado;
        }


        // GET: api/<MedicosAPIController>
        [HttpGet("GetMedicos")]
        public List<Medicos> GetMedicos()
        {
            return dao.ListarMedicos();
        }

        // GET api/<MedicosAPIController>/5
        [HttpGet("GetMedicos/{id}")]
        public Medicos GetMedicoId(string id)
        {
            var medico=dao.ListarMedicos().Find(m=>m.codmed!.Equals(id));
            return medico!;
        }

        // POST api/<MedicosAPIController>
        [HttpPost("PostMedico")]
        public string PostMedico([FromBody] Medicos obj)
        {
            return dao.grabarmedico(obj);
        }

        // PUT api/<MedicosAPIController>/5
        [HttpPut("PutMedico")]
        public string PutMedico(int id, [FromBody] Medicos obj)
        {
            return dao.actualizarmedico(obj);
        }

        // DELETE api/<MedicosAPIController>/5
        [HttpDelete("DeleteMedico/{id}")]
        public string DeleteMedico(string id)
        {
            return dao.eliminarmedico(id);
        }
    }
}
