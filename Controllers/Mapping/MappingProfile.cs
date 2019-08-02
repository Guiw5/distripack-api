using AutoMapper;
using DistripackAPI.Controllers.ApiModels;
using System.Linq;
using Client = DistripackAPI.Models.Client;
using Item = DistripackAPI.Models.Item;
using Order = DistripackAPI.Models.Order;
using Product = DistripackAPI.Models.Product;

namespace DistripackAPI.Controllers.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //<Source, Destiny>
            CreateMap<Product, ApiModels.Product>()
                .ForMember(d => d.CategoriesId,
                    o => o.MapFrom(s => s.Categories.Select(c => c.Id).ToArray()));

            CreateMap<Item, ApiModels.Item>()
             .ForMember(d => d.SkuNick, opt => opt.MapFrom(s => s.Sku.Nick))
             .ForMember(d => d.Price, opt => opt.MapFrom(s => s.UnitPrice));

            CreateMap<Order, ApiModels.Order>()
                .ForMember(d => d.State, opt => opt.MapFrom(s => s.State.ToString()));

            CreateMap<Client, ApiModels.Client>()
                .ForMember(d => d.Nick, opt => opt.MapFrom(s => string.IsNullOrEmpty(s.Nick) ? s.FantasyName : s.Nick));

            CreateMap<Client, FullClient>();
            CreateMap<CreateClient, Client>();
            CreateMap<CreateWebClient, Client>();
            CreateMap<UpdateClient, Client>();
        }
    }
}
