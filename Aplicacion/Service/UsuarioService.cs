

using Aplicacion.Interface;
using Dominio.Entidates;

namespace Aplicacion.Service
{
    public class UsuarioService
    {
        private readonly IRepository<Usuarios> _repository;

        public UsuarioService(IRepository<Usuarios> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Usuarios> GetAllUsuarios() 
        {
            return _repository.GetAllRegistros();
        }

        public Usuarios GetUsuariosByID(int ID)
        {
            return _repository.GetRegistrosByID(ID); 
        }

        public void PostUsuarios(Usuarios model)
        {
            _repository.PostRegistros(model);
        }

        public void DeleteUsuariosById(int ID)
        {
            _repository.DeleteById(ID);
        }

        public void PutUsuarios(Usuarios model)
        {
            _repository.PutRegistros(model);
        }
    }
}
