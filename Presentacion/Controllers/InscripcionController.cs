using Aplicacion.DTOs;
using Aplicacion.Service;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    [Route("api/Inscripcoines")]
    [Produces("application/json")]
    [ApiController]
    public class InscripcionController : Controller
    {
        private readonly InscripcionService _service;
        
        public InscripcionController(InscripcionService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public IEnumerable<InscripcionesDTO> GetReservas()
        {
            return _service.GetAllRegistros();
        }

        [HttpGet("GetByID")]
        public InscripcionesDTO GetReservasByID(int ID)
        {
            return _service.GetRegistrosByID(ID);
        }
        [HttpPost]
        public void SetReservas(InscripcionesDTO model)
        {
            _service.PostRegistros(model);
        }
        [HttpDelete]
        public void DeleteReservasByID(int ID)
        {
            _service.DeleteById(ID);
        }
        [HttpPut]
        public void PutReservas(InscripcionesDTO model)
        {
            _service.PutRegistros(model);
        }
    }
}


