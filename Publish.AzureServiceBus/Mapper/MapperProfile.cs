using AutoMapper;
using Publish.AzureServiceBus.DTOs;
using Publish.AzureServiceBus.Models;

namespace Publish.AzureServiceBus.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SalesOrderHeader, InvoiceHeaderRequest>();
            CreateMap<SalesOrderDetail, InvoiceDetailRequest>()
                .ForMember(dest => dest.BaseLine, opt => opt.MapFrom(src => src.LineNum));      
                
            
        }
    }
}
