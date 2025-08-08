

using Aplicacion.Interface;
using Dominio.Entidates;
using Infraestructura.Persistencia.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Repositorio
{
    public class Repositorio<T> : IRepository<T> where T : class
    {
        private readonly Contexto _contexto;
        DbSet<T> _dbSet;

        public Repositorio(Contexto contexto)
        {
            _contexto = contexto;
            _dbSet = contexto.Set<T>();
        }

        public IEnumerable<T> GetReservas()
        {
            return _dbSet.ToList();
        }

        public void SetReservas(T model)
        {
            _dbSet.Add(model);
            _contexto.SaveChanges();
        }
    }
}
