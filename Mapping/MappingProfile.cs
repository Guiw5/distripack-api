using AutoMapper;
using DistripackAPI.Controllers.Resources;
using DistripackAPI.Models;
using System.Linq;

namespace DistripackAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Producto, ProductoResource>()
                .ForMember(d => d.CategoriasId,
                    o => o.MapFrom(s => s.Categorias.Select(c => c.Id).ToArray()));

            CreateMap<Categoria, CategoriaResource>();
        }
    }
}
