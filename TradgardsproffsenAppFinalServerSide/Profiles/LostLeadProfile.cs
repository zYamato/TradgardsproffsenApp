using AutoMapper;
using TradgardsproffsenApp.Entities;
using TradgardsproffsenApp.Models;

namespace TradgardsproffsenApp.Profiles
{
    public class LostLeadProfile : Profile
    {
        public LostLeadProfile()
        {
            CreateMap<LostLead, LostLeadDto>();
        }
    }
}
