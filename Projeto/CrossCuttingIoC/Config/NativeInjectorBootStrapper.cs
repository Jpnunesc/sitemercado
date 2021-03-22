
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.Services;
using Infra.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CrossCutting.IoC.Config
{
    public class NativeInjectorBootStrapper
    {
        public static IServiceCollection Registered { get; private set; }
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProdutoService, ProdutoService>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

        }
    }
}


