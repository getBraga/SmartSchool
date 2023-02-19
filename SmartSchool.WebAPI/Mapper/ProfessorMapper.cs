using AutoMapper;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;

using AutoMapper;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Mapper
{
    public class ProfessorMapper : Profile
    {
        public ProfessorMapper()
        {
            CreateMap<Professor, ProfessorDto>()
           .ForMember(
               dest => dest.Nome,
               opt => opt.MapFrom(nomeSobrenome => $"{nomeSobrenome.Nome} {nomeSobrenome.Sobrenome}")
           )
           .ForMember(
                dest => dest.Idade,
                opt => opt.MapFrom(idade => idade.DataNascimento.GetCurrentAge())
                );


            CreateMap<ProfessorDto, Professor>();
            CreateMap<Professor, ProfessorRegistrarDto>().ReverseMap();
        }
    }
}
