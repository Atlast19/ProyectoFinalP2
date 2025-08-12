﻿

namespace Aplicacion.DTOs
{
    public sealed class ReservasDTO
    {
        public int IDCurso { get; set; }
        public string NombreMaestro { get; set; }
        public string NombreMateria { get; set; }
        public string Turno { get; set; }
        public string HorasInicioCurso { get; set; }
        public string HoraFinalCurso { get; set; }
        public int EspaciosDisponibles { get; set; }
        public DateOnly FechaFin { get; set; }
        public TimeOnly HoraFin { get; set; }
        public bool Estado { get; set; }
    }
}
