using REPOSITORY.Interface;
using REPOSITORY.Repositories;
using SERVICES.Interface;
using SERVICES.Services;
using System.Data;


namespace API.Configuration
{
    public static class Dependencias
    {
        public static IServiceCollection DependenciasProjeto(this IServiceCollection services)
        {
            services.AddScoped<IUsuarioServices, UsuarioServices>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            
            return services;
        }
    }
}
