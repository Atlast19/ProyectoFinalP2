

using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidates
{
    public sealed class Reservas
    {
        [Key]
        public int IDCurso { get; set; }
        public string NombreMaestro { get; set; }
        public string NombreMateria { get; set; }
        public string Turno { get; set; }
        public string HorasInicioCurso { get; set; }
        public string HoraFinalCurso { get; set; }
        public int EspaciosDisponibles { get; set; }
        public bool Estado { get; set; }

    }
}
