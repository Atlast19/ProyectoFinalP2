

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
            return _repository.GetReservas().Where(e => e.Estado == true);
        }
    }
}
