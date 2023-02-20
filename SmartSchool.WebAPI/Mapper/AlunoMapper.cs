using AutoMapper;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Helpers
{
    public class AlunoMapper:Profile
    {
        public AlunoMapper()
        {
            CreateMap<Aluno, AlunoDto>()
                .ForMember(
                dest => dest.NomeCompleto,
                opt => opt.MapFrom(nomeSobrenome => $"{nomeSobrenome.Nome} {nomeSobrenome.Sobrenome}")
                )
                .ForMember(
                dest => dest.Idade,
                opt => opt.MapFrom(idade => idade.DataNascimento.GetCurrentAge())
            );
            CreateMap<AlunoDto, Aluno>();
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();
            CreateMap<Aluno, AlunoAtualizarDtro>().ReverseMap();
        }
    }
}
