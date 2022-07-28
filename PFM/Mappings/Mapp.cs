using AutoMapper;
using PFM.Commands;
using PFM.Database.Entities;
using PFM.Models;

namespace Product.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TransactionEntity, PFM.Models.Transaction>()
                 .ForMember(d => d.id, opts => opts.MapFrom(s => s.id));
            CreateMap<CreateTransactionCommand, TransactionEntity>()
                .ForMember(d => d.id, opts => opts.MapFrom(s => s.id));

            CreateMap<PagedSortedList<TransactionEntity>, PagedSortedList<PFM.Models.Transaction>>();

            CreateMap<CreateCategoryCommand, CategoryEntity>()
                .ForMember(d => d.code, opts => opts.MapFrom(s => s.code));
            CreateMap<CategoryEntity, PFM.Models.Category>();
            CreateMap<CreateCategoryCommand, SubCategoryEntity>()
                .ForMember(d => d.code, opts => opts.MapFrom(s => s.code));
            CreateMap<SubCategoryEntity, PFM.Models.SubCategory>();
            CreateMap<Analysis<AnalyticsEntity>, Analysis<PFM.Models.Analytics>>();

        }
    }
}