

using Aplicacion.Interface;
using Dominio.Entidates;
using System.Runtime.InteropServices;

namespace Aplicacion.Service
{
    public class ReservasService
    {
        private readonly IRepository<Reservas> _repository;

        public ReservasService(IRepository<Reservas> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Reservas> GetReservas() 
        {
            return _repository.GetAllRegistros().Where(e => e.Estado == true);
        }

        public Reservas GetReservasByID(int ID) 
        {
            return _repository.GetRegistrosByID(ID);
        }

        public void PostReservas(Reservas model) 
        {
            _repository.PostRegistros(model);
        }

        public void DeleteReservaById(int ID) 
        {
            _repository.DeleteById(ID);
        }

        public void PutReservas(Reservas model) 
        {
            _repository.PutRegistros(model);
        }

    }
}
