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

            CreateMap<PostModel.Order, Order>()
                .ForMember(d => d.Items,
                    opt => opt.MapFrom(
                        s => s.Items
                            .Select(i => new Item { SkuId = i.SkuId, Quantity = i.Quantity, UnitPrice = i.Price })));
            CreateMap<PostModel.Item, Item>()
                   .ForMember(d => d.UnitPrice, o => o.MapFrom(s => s.Price));
            //CreateMap<Client, GetModel.Client>();
        }
    }
}
