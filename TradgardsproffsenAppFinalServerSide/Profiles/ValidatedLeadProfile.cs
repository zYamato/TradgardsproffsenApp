using AutoMapper;
using TradgardsproffsenApp.Entities;
using TradgardsproffsenApp.Models;
using TradgardsproffsenApp.Profiles.MapperHelper;

namespace TradgardsproffsenApp.Profiles
{
    public class ValidatedLeadProfile : Profile
    {
        public ValidatedLeadProfile()
        {
            CreateMap<CreateValidatedLeadDto, ValidatedLead>();
            CreateMap<ValidatedLead, ValidatedLeadDto>();

        }
    }
}
