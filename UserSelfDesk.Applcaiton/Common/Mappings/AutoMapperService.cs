using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace UserSelfDesk.Applcaiton.Common.Mappings
{
    public static class AutoMapperService
    {
        public static TDestination MapTo<TSource, TDestination>(this TSource tSource)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            IMapper mapper = config.CreateMapper();
            var mappeddata = mapper.Map<TSource, TDestination>(tSource);
            return mappeddata;
        }
        public static TDestination MapTo<TSource, TDestination>(this TSource tSource, Action<IMappingOperationOptions<TSource, TDestination>> option)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            IMapper mapper = config.CreateMapper();
            var mappeddata = mapper.Map<TSource, TDestination>(tSource, option);
            return mappeddata;
        }
        public static IEnumerable<TDestination> MapTo<TSource, TDestination>(this IEnumerable<TSource> tSource)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();

            });
            IMapper mapper = config.CreateMapper();
            var mappeddata = mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(tSource);
            return mappeddata;
        }
        public static List<TDestination> MapTo<TSource, TDestination>(this List<TSource> tSource)
        {

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();

            });
            IMapper mapper = config.CreateMapper();
            var mappeddata = mapper.Map<List<TSource>, List<TDestination>>(tSource);
            return mappeddata;
        }
        public static IEnumerable<TDestination> MapTo<TSource, TDestination>(this IEnumerable<TSource> tSource,

            Dictionary<Expression<Func<TDestination, object>>, Action<IMemberConfigurationExpression<TSource, TDestination, object>>> option)
        {

            var config = new MapperConfiguration(cfg =>
            {
                var map = cfg.CreateMap<TSource, TDestination>();
                foreach (var item in option)
                {
                    map.ForMember(item.Key, item.Value);
                }
            });
            IMapper mapper = config.CreateMapper();
            var mappeddata = mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(tSource);
            return mappeddata;
        }

        public static IEnumerable<TDestination> MapTo<TDestination>(this IEnumerable<object> tSource)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<object, TDestination>();

            });
            IMapper mapper = config.CreateMapper();

            var mappeddata = mapper.Map<IEnumerable<TDestination>>(tSource);
            return mappeddata;
        }
        public static TDestination MapTo<TDestination>(this object sourceObject)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<object, TDestination>();
            });
            IMapper mapper = config.CreateMapper();

            var data = mapper.Map<TDestination>(sourceObject);
            return data;
        }
    }
}
