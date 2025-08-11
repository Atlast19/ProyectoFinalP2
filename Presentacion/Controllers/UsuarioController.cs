using Aplicacion.DTOs;
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
        public IEnumerable<UsuarioDTO> GetAllUsuarios() 
        {
            return _service.GetAllRegistros().ToList() ;
        }
        [HttpGet("GetById")]
        public UsuarioDTO GetUsuarioByID(int ID) 
        {
            return _service.GetRegistrosByID(ID);
        }
        [HttpPost]
        public void PostUsuarios(UsuarioDTO model) 
        {
            _service.PostRegistros(model);
        }
        [HttpPut]
        public void PutUsuarios(UsuarioDTO model) 
        {
            _service.PutRegistros(model);
        }
        [HttpDelete]
        public void DeleteUsuarioByID(int ID) 
        {
            _service.DeleteById(ID);
        }


    }
}
