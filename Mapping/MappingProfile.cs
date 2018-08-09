using AutoMapper;

namespace DistripackAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<Product, Product>()
            //    .ForMember(d => d.Nick, o => o.MapFrom(s => s.Nick))
            //    .ForMember(d => d.CategoriesId,
            //        o => o.MapFrom(s => s.Categorias.Select(c => c.Id).ToArray()))
            //    .ForMember(d => d.Skus,
            //    o => o.MapFrom(s => s.Skus.Select(c => c.Id).ToArray()));

            //CreateMap<Models.Sku, Controllers.ApiModels.Sku>()
            //    .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
            //    .ForMember(d => d.Code, o => o.MapFrom(s => s.Code))
            //    .ForMember(d => d.Nick, o => o.MapFrom(s => s.Nick))
            //    .ForMember(d => d.Description, o => o.MapFrom(s => s.Description))
            //    .ForMember(d => d.Price, o => o.MapFrom(s => s.Price))
            //    .ForMember(d => d.Brand, o => o.MapFrom(s => s.Brand))
            //    .ForMember(d => d.Quantity, o => o.MapFrom(s => s.Quantity))
            //    .ForMember(d => d.Capacity, o => o.MapFrom(s => s.Capacity))
            //    .ForMember(d => d.Measures, o => o.MapFrom(s => s.Measures));


            //CreateMap<Category, Category>()
            //    .ForMember(d => d.Products, o => o.MapFrom(s => s.Productos))
            //    .ForMember(d => d.IsCommercialType, o => o.MapFrom(s => s.EsRubro))
            //    .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));

            //CreateMap<Detalle, Item>()
            //    .ForMember(d => d.OrderId, o => o.MapFrom(s => s.OrderId))
            //    .ForMember(d => d.Price, o => o.MapFrom(s => s.PrecioUnitario))
            //    .ForMember(d => d.Quantity, o => o.MapFrom(s => s.Quantity))
            //    .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ProductId));

            //CreateMap<Order, Order>()
            //    .ForMember(d => d.Id, o => o.Ignore())
            //    .ForMember(d => d.ClientId, o => o.MapFrom(s => s.ClientId))
            //    .ForMember(d => d.Items, o => o.Ignore())
            //    .ForMember(d => d.Subtotal, o => o.MapFrom(s => s.Subtotal))
            //    .ForMember(d => d.State, o => o.MapFrom(s => s.Estado))
            //    .ForMember(d => d.CreationDate, o => o.MapFrom(s => s.CreatedAt))
            //    .ForMember(d => d.DeliveryDate, o => o.MapFrom(s => s.FechaEntrega));

            //CreateMap<Item, Detalle>()
            //    .ForMember(d => d.OrderId, o => o.MapFrom(s => s.OrderId))
            //    .ForMember(d => d.PrecioUnitario, o => o.MapFrom(s => s.Price))
            //    .ForMember(d => d.Quantity, o => o.MapFrom(s => s.Quantity))
            //    .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ProductId));

            //CreateMap<Order, Order>()
            //    .ForMember(d => d.ClientId, o => o.MapFrom(s => s.ClientId))
            //    .ForMember(d => d.Items, o => o.Ignore())
            //    .ForMember(d => d.Estado, o => o.MapFrom(s => s.State))
            //    .ForMember(d => d.CreatedAt, o => o.MapFrom(s => s.CreationDate))
            //    .ForMember(d => d.FechaEntrega, o => o.MapFrom(s => s.DeliveryDate));
        }
    }
}
