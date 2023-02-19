using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IMapper _mapper;

        private  IRepository _repo { get; set; }
        public AlunoController(IRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);
            var alunoDto =  _mapper.Map<IEnumerable<AlunoDto>>(alunos);
            return Ok(alunoDto);
        }
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {

            var aluno = _repo.GetAlunoById(id, false);
            var alunoDto = _mapper.Map<AlunoDto>(aluno); 
            if (alunoDto == null) return BadRequest("O Aluno não foi encontrado!");
            return Ok(alunoDto);

        }

        [HttpPost]
        public IActionResult PostAluno(AlunoRegistrarDto alunoDto)
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);
            _repo.Add(aluno);
            if(_repo.SaveChanges())
            {
                return Created($"/api/aluno/${alunoDto.Id}", _mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Aluno não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult PutAluno(int id, AlunoRegistrarDto model) 
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");
            _mapper.Map(model, aluno);
            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/${model.Id}", _mapper.Map<AlunoDto>(aluno));

            }
            return BadRequest("O Aluno não foi encontrado!");
          
        }
        [HttpPatch("{id}")]
        public IActionResult PatchAluno(int id, AlunoRegistrarDto model)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");
            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/${model.Id}", _mapper.Map<AlunoDto>(aluno));

            }
            return BadRequest("O Aluno não foi encontrado!");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");

            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Usuário excluido");
            }
            return BadRequest("Usuário não excluido");
           
        }
    }
}
