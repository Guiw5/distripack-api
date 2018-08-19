using AutoMapper;
using DistripackAPI.Models;
using System.Linq;
using GetModel = DistripackAPI.Controllers.ApiModels.Get;
using PostModel = DistripackAPI.Controllers.ApiModels.Post;

namespace DistripackAPI.Controllers.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, GetModel.Product>()
                .ForMember(d => d.CategoriesId,
                    o => o.MapFrom(s => s.Categories.Select(c => c.Id).ToArray()));


            CreateMap<Item, GetModel.Item>()
                .ForMember(d => d.Price, o => o.MapFrom(s => s.UnitPrice));

            CreateMap<PostModel.Item, Item>()
                .ForMember(d => d.UnitPrice, o => o.MapFrom(s => s.Price));

            CreateMap<Item, PostModel.Item>()
                .ForMember(d => d.SkuNick, opt => opt.MapFrom(s => s.Sku.Nick))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.UnitPrice));

            CreateMap<PostModel.Order, Order>();
            CreateMap<PostModel.Client, Client>();
            CreateMap<Client, GetModel.Client>();
        }
    }
}
