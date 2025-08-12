using Aplicacion.DTOs;
using Aplicacion.Service;
using Dominio.Entidates;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    [Route("api/Reservas")]
    [Produces("application/json")]
    [ApiController]

    public class ReservasController : Controller
    {
        private readonly ReservasService _service;
        public ReservasController(ReservasService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public IActionResult GetReservas()
        {
            try
            {
                var list = _service.GetAllRegistros().ToList().Where(x=> x.Estado == true);
                return Ok(list);
            }
            catch (Exception ex) 
            {
                return BadRequest(new {Error = "Error al Cargar los datos!"});
            }
        }

        [HttpGet("GetByID")]
        public ReservasDTO GetReservasByID(int ID) 
        {
            return _service.GetRegistrosByID(ID);
        }

        [HttpPost]
        public IActionResult PostReservas([FromBody]ReservasDTO model) 
        {
            try
            {
                _service.PostRegistros(model);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(new { Error = "Los datos ingresados no son correctos!"});
            }
        }

        [HttpDelete]
        public IActionResult DeleteReservasByID(int ID) 
        {
            try
            {
                _service.DeleteById(ID);
                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(new {Error = "El codigo ingresado no es correcto!"});
            }
        }

        [HttpPut]
        public IActionResult PutReservas([FromBody]ReservasDTO model) 
        {
            try {
                _service.PutRegistros(model);
                return Ok();
            } catch (Exception ex) 
            {
                return BadRequest(new {Error = "Datos Incorrectos en la Actualizacion!"});
            }
        }


    }
}
