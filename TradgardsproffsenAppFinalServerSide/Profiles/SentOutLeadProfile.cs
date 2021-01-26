using AutoMapper;
using TradgardsproffsenApp.Entities;
using TradgardsproffsenApp.Models;

namespace TradgardsproffsenApp.Profiles
{
    public class SentOutLeadProfile : Profile
    {
        public SentOutLeadProfile()
        {
            CreateMap<SentOutLead, SentOutLeadDto>();
            CreateMap<CreateSentOutLeadDto, SentOutLead>();
        }
    }
}
