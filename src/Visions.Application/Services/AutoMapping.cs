using AutoMapper;
using Visions.Application.DTOs.Aluno.Requests;
using Visions.Application.DTOs.Emprestimo.Requests;
using Visions.Application.DTOs.Emprestimo.Respondes;
using Visions.Application.DTOs.Livro.Requests;
using Visions.Application.DTOs.Livro.Responses;
using Visions.Domain.Enum;
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
            CreateMap<EmprestimoRegisterDTO, Emprestimo>(); 
        }

        private void ResponseMapping()
        {
            CreateMap<Livro, LivroListDTO>();

            CreateMap<Emprestimo, EmprestimoListDTO>()
            .ForMember(dest => dest.NomeAluno, opt => opt.MapFrom(src => src.Aluno.Nome))
            .ForMember(dest => dest.TituloLivro, opt => opt.MapFrom(src => src.Livro.Titulo))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => ((EmprestimoStatus)src.Status).ToString()));

        }
    }
}
