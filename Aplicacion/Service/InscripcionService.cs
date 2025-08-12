
using Aplicacion.DTOs;
using Aplicacion.Interface;
using Aplicacion.Service.Base;
using AutoMapper;
using Dominio.Entidates;

namespace Aplicacion.Service
{
    public class InscripcionService : IBaseService<InscripcionesDTO>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Inscripciones> _repository;
        public InscripcionService(IMapper mapper, IRepository<Inscripciones> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public void DeleteById(int ID)
        {
            _repository.DeleteById(ID);
        }

        public IEnumerable<InscripcionesDTO> GetAllRegistros()
        {
            var list =_repository.GetAllRegistros().ToList();
            return _mapper.Map<IEnumerable<InscripcionesDTO>>(list);
        }

        public InscripcionesDTO GetRegistrosByID(int ID)
        {
            var code = _repository.GetRegistrosByID(ID);
            return _mapper.Map<InscripcionesDTO>(code);
        }

        public void PostRegistros(InscripcionesDTO model)
        {
            var models = _mapper.Map<Inscripciones>(model);
            _repository.PostRegistros(models);
        }

        public void PutRegistros(InscripcionesDTO model)
        {
            var models = _mapper.Map<Inscripciones>(model);
            _repository.PutRegistros(models);
        }
    }
}
