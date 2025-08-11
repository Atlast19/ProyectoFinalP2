
using Aplicacion.DTOs;
using AutoMapper;
using Dominio.Entidates;

namespace Infraestructura.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<UsuarioDTO, Usuarios>();

        }
    }
}
