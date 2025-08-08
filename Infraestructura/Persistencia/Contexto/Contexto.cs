

using Dominio.Entidates;
using Microsoft.EntityFrameworkCore;

namespace Infraestructura.Persistencia.Contexto
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> db) : base(db) { }
        public DbSet<Reservas> Reservas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Inscripciones> Inscripciones { get; set; }
    }
}
