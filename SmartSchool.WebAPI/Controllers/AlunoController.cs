using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// 
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IMapper _mapper;

        private  IRepository _repo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public AlunoController(IRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        /// <summary>
        /// Metodo responsável por retornar todos os alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {
            var alunos = await _repo.GetAllAlunosAsync(pageParams , true);
            var alunoDto =  _mapper.Map<IEnumerable<AlunoDto>>(alunos);
            return Ok(alunoDto);
        }
        /// <summary>
        /// Metodo responsável por retornar um unico aluno por ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {

            var aluno = _repo.GetAlunoById(id, false);
            var alunoDto = _mapper.Map<AlunoDto>(aluno); 
            if (alunoDto == null) return BadRequest("O Aluno não foi encontrado!");
            return Ok(alunoDto);

        }
        /// <summary>
        /// Metodo responsável por registrar um aluno na base de dados
        /// </summary>
        /// <param name="alunoDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostAluno(AlunoRegistrarDto alunoDto)
        {
            var aluno = _mapper.Map<Aluno>(alunoDto);
            _repo.Add(aluno);
            if(_repo.SaveChanges())
            {
                return Created($"/api/aluno/${aluno.Id}", _mapper.Map<AlunoDto>(aluno));
            }
            return BadRequest("Aluno não cadastrado!");
        }

        /// <summary>
        /// Metodo responsável por atualizar o aluno na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutAluno(int id, AlunoAtualizarDtro model) 
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");
            _mapper.Map(model, aluno);
            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/${model.Id}", _mapper.Map<AlunoAtualizarDtro>(aluno));

            }
            return BadRequest("O Aluno não foi encontrado!");
          
        }
        /// <summary>
        ///  Metodo responsável por atualizar o aluno na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult PatchAluno(int id, AlunoAtualizarDtro model)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");
            _mapper.Map(model, aluno);

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/${model.Id}", _mapper.Map<AlunoAtualizarDtro>(aluno));

            }
            return BadRequest("O Aluno não foi encontrado!");
        }
        /// <summary>
        ///  Metodo responsável por remover o aluno na base de dados
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");

            _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Usuário deletado com sucesso!");
            }
            return BadRequest("Usuário não deletado");
           
        }
    }
}
