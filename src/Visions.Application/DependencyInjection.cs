using Microsoft.Extensions.DependencyInjection;
using Visions.Application.Services;
using Visions.Application.UseCase.Livro.Cadastrar;
using Visions.Application.UseCases.Aluno.Register;
using Visions.Application.UseCases.Livro.Listing;
using Visions.Application.UseCases.Livro.Register;

namespace Visions.Application
{
    public static class DependencyInjection
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddUseCase(services);
            AddMapper(services);
        }
        private static void AddUseCase(IServiceCollection services)
        {
            services.AddScoped<ILivroUseCase, LivroUseCase>();
            services.AddScoped<ILivroListingUseCase, LivroListingUseCase>();
            services.AddScoped<IAlunoUseCase, AlunoUseCase>();

        }

        private static void AddMapper(IServiceCollection services)
        {
           services.AddScoped(opt => new AutoMapper.MapperConfiguration(opt =>
            {
                opt.AddProfile(new AutoMapping());
            }).CreateMapper()); 
        }   
    }
}
    