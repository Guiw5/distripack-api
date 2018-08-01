using AutoMapper;
using DistripackAPI.Controllers.Resources;
using DistripackAPI.Models;
using System;
using System.Linq;

namespace DistripackAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Producto, ProductResource>()
                .ForMember(d => d.Nick, o => o.MapFrom(s => s.Alias))
                .ForMember(d => d.Description, o => o.MapFrom(s => s.Descripcion))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Precio))
                .ForMember(d => d.Brand, o => o.MapFrom(s => s.Marca))
                .ForMember(d => d.Quantity, o => o.MapFrom(s => s.Cantidad))
                .ForMember(d => d.Capacity, o => o.MapFrom(s => s.Capacidad))
                .ForMember(d => d.Code, o => o.MapFrom(s => s.Codigo))
                .ForMember(d => d.Measures, o => o.MapFrom(s => s.Medidas))
                .ForMember(d => d.CategoriesId,
                    o => o.MapFrom(s => s.Categorias.Select(c => c.Id).ToArray()));

            CreateMap<Categoria, CategoryResource>()
                .ForMember(d => d.Products, o => o.MapFrom(s => s.Productos))
                .ForMember(d => d.IsCommercialType, o => o.MapFrom(s => s.EsRubro))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Nombre));

            CreateMap<Detalle, ItemResource>()
                .ForMember(d => d.OrderId, o => o.MapFrom(s => s.PedidoId))
                .ForMember(d => d.Price, o => o.MapFrom(s => s.PrecioUnitario))
                .ForMember(d => d.Quantity, o => o.MapFrom(s => s.Cantidad))
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ProductoId));

            CreateMap<Pedido, OrderResource>()
                .ForMember(d => d.ClientId, o => o.MapFrom(s => s.ClienteId))
                .ForMember(d => d.Items, o => o.MapFrom(s => s.Detalles))
                .ForMember(d => d.Subtotal, o => o.MapFrom(s => s.Subtotal))
                .ForMember(d => d.State, o => o.MapFrom(s => s.Estado))
                .ForMember(d => d.CreationDate, o => o.MapFrom(s => s.FechaCreacion.ToShortDateString()))
                .ForMember(d => d.CreationTime, o => o.MapFrom(s => s.FechaCreacion.ToShortTimeString()))
                .ForMember(d => d.DeliveryDate,
                    o => o.MapFrom(s => s.FechaEntrega.HasValue ? s.FechaEntrega.Value.ToShortDateString() : null))
                .ForMember(d => d.DeliveryTime,
                    o => o.MapFrom(s => s.FechaEntrega.HasValue ? s.FechaEntrega.Value.ToShortTimeString() : null));

            CreateMap<ItemResource, Detalle>()
                .ForMember(d => d.PedidoId, o => o.MapFrom(s => s.OrderId))
                .ForMember(d => d.PrecioUnitario, o => o.MapFrom(s => s.Price))
                .ForMember(d => d.Cantidad, o => o.MapFrom(s => s.Quantity))
                .ForMember(d => d.ProductoId, o => o.MapFrom(s => s.ProductId));

            CreateMap<OrderResource, Pedido>()
                .ForMember(d => d.ClienteId, o => o.MapFrom(s => s.ClientId))
                .ForMember(d => d.Detalles, o => o.MapFrom(s => s.Items))
                .ForMember(d => d.Estado, o => o.MapFrom(s => s.State))
                .ForMember(d => d.FechaCreacion, o => o.MapFrom(s => DateTime.Parse(s.CreationDate + s.CreationTime)))
                .ForMember(d => d.FechaEntrega,
                    o => o.MapFrom(s => !String.IsNullOrEmpty(s.DeliveryDate + s.DeliveryTime)
                        ? DateTime.Parse(s.DeliveryDate + s.DeliveryTime)
                        : (DateTime?)null));
        }
    }
}
