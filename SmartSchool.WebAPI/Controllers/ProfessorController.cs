using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;
using System.Xml.Linq;

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.GetAllProfessores(true);
            var professorDto = _mapper.Map<IEnumerable<ProfessorDto>>(professores);
            return Ok(professorDto);
        }
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            var professorDto = _mapper.Map<IEnumerable<ProfessorDto>>(professor);
            if (professorDto == null) return BadRequest("O Professor não foi encontrado!");
            return Ok(professorDto);
        }

        [HttpPost]
        public IActionResult PostProfessor(ProfessorRegistrarDto professorRegistrarDto)
        {
            var aluno = _mapper.Map<Professor>(professorRegistrarDto);
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/${professorRegistrarDto.Id}", _mapper.Map<ProfessorDto>(aluno));
            }
            return BadRequest("Aluno não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult PutProfessor(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorById(id, false);
         
            if (professor == null) return BadRequest("O Professor não foi encontrado!");
            _mapper.Map(model, professor);
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/${model.Id}", _mapper.Map<ProfessorDto>(professor));

            }
            return BadRequest("O Professor não foi encontrado!");
        }
        [HttpPatch("{id}")]
        public IActionResult PatchProfessor(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorById(id, false);

            if (professor == null) return BadRequest("O Professor não foi encontrado!");
            _mapper.Map(model, professor);
            _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/${model.Id}", _mapper.Map<ProfessorDto>(professor));

            }
            return BadRequest("O Professor não foi encontrado!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfessor(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("O Professor não foi encontrado!");
            _repo.Delete(professor);
            _repo.SaveChanges();
            return Ok("Professor excluido com sucesso!");
        }
    }
}
