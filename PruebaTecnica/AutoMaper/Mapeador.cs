using AutoMapper;

namespace PruebaTecnica.AutoMaper
{
    public class Mapeador
    {
        public T Mapear<T>()
        {
            var config = new MapperConfiguration(m => m.CreateMap(GetType(), typeof(T)));
            var mapper = config.CreateMapper();
            return mapper.Map<T>(this);
        }

        protected void MapearDesdeEntidad<T>(T entidad)
        {
            var config = new MapperConfiguration(m => m.CreateMap(typeof(T), GetType()));
            var mapper = config.CreateMapper();
            mapper.Map(entidad, this);
        }
    }
}

