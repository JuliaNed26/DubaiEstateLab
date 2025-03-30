using AutoMapper;
using DubaiEstate.BLL.Models;
using DubaiEstate.DAL.Models;

namespace DubaiEstate.BLL.Mapping;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Area, AreaEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AreaId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.AreaNameEn))
            .ReverseMap();
        
        CreateMap<Date, DateEntity>()
            .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.FullDate))
            .ReverseMap();

        CreateMap<Procedure, ProcedureEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProcedureId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.ProcedureNameEn))
            .ReverseMap();

        CreateMap<PropertySubType, PropertySubTypeEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PropertySubTypeId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.PropertySubTypeEn))
            .ReverseMap();

        CreateMap<PropertyType, PropertyTypeEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PropertyTypeId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.PropertyTypeEn))
            .ReverseMap();

        CreateMap<Transaction, TransactionEntity>().ReverseMap();
        CreateMap<TransactionKeys, TransactionKeysEntity>().ReverseMap();

        CreateMap<TransactionsGroup, TransactionsGroupEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TransGroupId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.TransGroupEn))
            .ReverseMap();
    }
}