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
        public IEnumerable<Reservas> GetReservas()
        {
            return _service.GetReservas();
        }

        [HttpGet("GetByID")]

        public Reservas GetReservasByID(int ID) 
        {
            return _service.GetReservasByID(ID);
        }

        [HttpPost]
        public void SetReservas(Reservas model) 
        {
            _service.PostReservas(model);
        }

        [HttpDelete]
        public void DeleteReservasByID(int ID) 
        {
            _service.DeleteReservaById(ID);
        }

        [HttpPut]
        public void PutReservas(Reservas model) 
        {
            _service.PutReservas(model);
        }


    }
}
