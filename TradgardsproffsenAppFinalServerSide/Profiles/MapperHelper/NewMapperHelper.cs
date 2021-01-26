using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TradgardsproffsenApp.Profiles.MapperHelper
{
    public static class NewMapperHelper
    {
        public static List<TDestination> MapList<TDestination, TSource>
             (List<TSource> entity)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>().ReverseMap();
            });

            var _mapper = config.CreateMapper();
            return _mapper.Map<List<TDestination>>(entity);
        }
    }
}
