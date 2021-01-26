using AutoMapper;
using TradgardsproffsenApp.Entities;
using TradgardsproffsenApp.Models;

namespace TradgardsproffsenApp.Profiles
{
    public class AllLeadProfile : Profile
    {
        public AllLeadProfile()
        {
            CreateMap<AllLead, AllLeadDto>();
        }
    }
}
