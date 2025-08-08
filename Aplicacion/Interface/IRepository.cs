

namespace Aplicacion.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetReservas();
    }
}
