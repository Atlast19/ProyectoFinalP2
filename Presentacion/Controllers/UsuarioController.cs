using Aplicacion.Service;
using Dominio.Entidates;
using Microsoft.AspNetCore.Mvc;

namespace Presentacion.Controllers
{
    [Route("api/Usuarios")]
    [Produces("application/json")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly UsuarioService _service;

        public UsuarioController(UsuarioService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public IEnumerable<Usuarios> GetAllUsuarios() 
        {
            return _service.GetAllUsuarios().ToList();
        }
        [HttpGet("GetById")]
        public Usuarios GetUsuarioByID(int ID) 
        {
            return _service.GetUsuariosByID(ID);
        }
        [HttpPost]
        public void PostUsuarios(Usuarios model) 
        {
            _service.PostUsuarios(model);
        }
        [HttpPut]
        public void PutUsuarios(Usuarios model) 
        {
            _service.PutUsuarios(model);
        }
        [HttpDelete]
        public void DeleteUsuarioByID(int ID) 
        {
            _service.DeleteUsuariosById(ID);
        }


    }
}
