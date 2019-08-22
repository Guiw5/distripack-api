using AutoMapper;
using DistripackAPI.Controllers.ApiModels;
using System.Linq;
using Client = DistripackAPI.Models.Client;
using Item = DistripackAPI.Models.Item;
using Order = DistripackAPI.Models.Order;
using Payment = DistripackAPI.Models.Payment;
using Product = DistripackAPI.Models.Product;
using Receipt = DistripackAPI.Models.Receipt;
using Transaction = DistripackAPI.Models.Transaction;

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
            CreateMap<CreateThinClient, Client>();
            CreateMap<CreateWebClient, Client>();
            CreateMap<UpdateClient, Client>();

            CreateMap<Transaction, ApiModels.Transaction>()
                .Include<Payment, ApiModels.Payment>()
                .Include<Receipt, ApiModels.Receipt>()
                .ForMember(d => d.AccountId, opt => opt.MapFrom(s => s.CheckingAccountId))
                .ForMember(d => d.ClientId, opt => opt.MapFrom(s => s.CheckingAccount.ClientId))
                .ForMember(d => d.CurrentBalance, opt => opt.MapFrom(s => s.CheckingAccount.CurrentBalance));

            CreateMap<Payment, ApiModels.Payment>()
                .ForMember(d => d.Method, opt => opt.MapFrom(s => s.Method.ToString()));

            CreateMap<Receipt, ApiModels.Receipt>();

        }
    }
}

