

namespace Aplicacion.Interface
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetReservas();

        void SetReservas(T model);
    }
}
