using Microsoft.Extensions.DependencyInjection;
using Visions.Application.Services;
using Visions.Application.UseCases.Aluno;
using Visions.Application.UseCases.Emprestimo;
using Visions.Application.UseCases.Livro;

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
            services.AddScoped<IAlunoUseCase, AlunoUseCase>();
            services.AddScoped<IEmprestimoUseCase, EmprestimoUseCase>();
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
    