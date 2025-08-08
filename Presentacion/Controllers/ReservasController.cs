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
       private readonly  ReservasService _service;

        public ReservasController(ReservasService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Reservas> GetReservas() 
        {
            return _service.GetReservas();
        }
    }
}
