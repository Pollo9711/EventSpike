using AutoMapper;
using EventSpikeBack.Context.Entities;
using EventSpikeBack.Domain;

namespace EventSpikeBack.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserEntity, UserDomain>().ReverseMap();
        }
    }
}