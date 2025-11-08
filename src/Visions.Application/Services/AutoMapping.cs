using AutoMapper;
using Visions.Application.DTOs.Aluno.Requests;
using Visions.Application.DTOs.Livro.Requests;
using Visions.Application.DTOs.Livro.Responses;
using Visions.Domain.Models;

namespace Visions.Application.Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            ResponseMapping();
            RequestMapping();  
        }
        private void RequestMapping()
        {
            CreateMap<LivroRegisterDTO, Livro>();
            CreateMap<AlunoRegisterDTO, Aluno>();

        }

        private void ResponseMapping()
        {
            CreateMap<Livro, LivroListDTO>();
        }
    }
}
