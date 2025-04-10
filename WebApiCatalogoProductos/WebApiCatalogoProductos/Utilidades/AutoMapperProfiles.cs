using AutoMapper;
using WebApiCatalogoProductos.DTOs;
using WebApiCatalogoProductos.Entities;

namespace WebApiCatalogoProductos.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Producto, ProductoDTO>().ReverseMap();
        }
    }
}
