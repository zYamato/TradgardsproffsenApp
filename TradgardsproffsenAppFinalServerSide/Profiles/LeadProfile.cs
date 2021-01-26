using AutoMapper;
using TradgardsproffsenApp.Entities;
using TradgardsproffsenApp.Models;

namespace TradgardsproffsenApp.Profiles
{
    public class LeadProfile : Profile
    {
        public LeadProfile()
        {
            CreateMap<Lead, LeadDto>();
        }
    }
}
