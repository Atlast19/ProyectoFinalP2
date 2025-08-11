

using Aplicacion.DTOs;
using Aplicacion.Interface;
using Aplicacion.Service.Base;
using AutoMapper;
using Dominio.Entidates;

namespace Aplicacion.Service
{
    public class UsuarioService : IBaseService<UsuarioDTO>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Usuarios> _repository;

        public UsuarioService(IMapper mapper, IRepository<Usuarios> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void DeleteById(int ID)
        {
            _repository.DeleteById(ID);
        }

        public IEnumerable<UsuarioDTO> GetAllRegistros()
        {
            var list = _repository.GetAllRegistros();
            return _mapper.Map<IEnumerable<UsuarioDTO>>(list);
        }

        public UsuarioDTO GetRegistrosByID(int ID)
        {
            var code = _repository.GetRegistrosByID(ID);
            return _mapper.Map<UsuarioDTO>(code);
        }

        public void PostRegistros(UsuarioDTO model)
        {
            var modelo = _mapper.Map<Usuarios>(model);
            _repository.PostRegistros(modelo);

        }

        public void PutRegistros(UsuarioDTO model)
        {
            var modelo = _mapper.Map<Usuarios>(model);
            _repository.PutRegistros(modelo);
        }
    }
}
