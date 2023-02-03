using AutoMapper;
using Grand.Infrastructure.Mapper;
using Misc.CzechInvoiceGenerator.Domain;
using Misc.CzechInvoiceGenerator.Models;

namespace Misc.CzechInvoiceGenerator.Infrastructure.Mapper
{
    public class CzechInvoiceMapperConfiguration : Profile, IAutoMapperProfile
    {
        public CzechInvoiceMapperConfiguration()
        {
            CreateMap<OrderInvoiceSerie, InvoiceSeriesModel>();

            CreateMap<InvoiceSeriesModel, OrderInvoiceSerie>()
                .ForMember(dest => dest.LimitedToStores, mo => mo.Ignore());
        }

        public int Order => 0;
    }
}
