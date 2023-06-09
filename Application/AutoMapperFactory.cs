using AutoMapper;
using System.Reflection;

namespace Application;
public static class AutoMapperFactory
{
    public static IConfigurationProvider CreateMapperConfiguration()
    {
        var config = new MapperConfiguration(cfg =>
        {
            var assembly = Assembly.GetAssembly(typeof(AutoMapperFactory));

            cfg.AddMaps(assembly);
        });

        return config;
    }
}
