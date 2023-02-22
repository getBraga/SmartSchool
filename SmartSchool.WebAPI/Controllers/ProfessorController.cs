using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;
using System.Xml.Linq;

namespace SmartSchool.WebAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public ProfessorController(IRepository repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }
        /// <summary>
        /// Metodo responsável para retornar todos os professores
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams pageParams)
        {
            var professores = await _repo.GetAllProfessoresAsync(pageParams, true);
            var professorDto = _mapper.Map<IEnumerable<ProfessorDto>>(professores);
            Response.AddPagination(professores.CurrentPage, professores.PageSize, professores.TotalCount, professores.TotalPages);
            return Ok(professorDto);
        }
        /// <summary>
        /// Metodo responsável para retornar um unico professor pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            var professorDto = _mapper.Map<IEnumerable<ProfessorDto>>(professor);
            if (professorDto == null) return BadRequest("O Professor não foi encontrado!");
            return Ok(professorDto);
        }
        /// <summary>
        /// Metodo responsável por registar o professor
        /// </summary>
        /// <param name="professorRegistrarDto"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult PostProfessor(ProfessorRegistrarDto professorRegistrarDto)
        {
            var aluno = _mapper.Map<Professor>(professorRegistrarDto);
            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/${aluno.Id}", _mapper.Map<ProfessorDto>(aluno));
            }
            return BadRequest("Aluno não cadastrado!");
        }
        /// <summary>
        /// Metodo responsável por atualizar o professor Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutProfessor(int id, ProfessorAtualizarDto model)
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
        /// <summary>
        /// /// Metodo responsável por atualizar o professor pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult PatchProfessor(int id, ProfessorAtualizarDto model)
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
        /// <summary>
        /// Metodo responsável por remover o professor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteProfessor(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("O Professor não foi encontrado!");
            _repo.Delete(professor);
            _repo.SaveChanges();
            return Ok("Professor deletado com sucesso!");
        }
    }
}
