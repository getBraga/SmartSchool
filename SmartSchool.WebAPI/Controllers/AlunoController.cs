using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly DataContext _context;

        public AlunoController(DataContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Alunos);
        }
        [HttpGet("byId/{id}")]
        public IActionResult GetId(int id)
        {

            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");
            return Ok(aluno);

        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(
                a => a.Nome == nome && a.Sobrenome == sobrenome
                );
            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");
            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult PostAluno(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult PutAluno(int id, Aluno aluno) 
        {
            return Ok(aluno);
        }
        [HttpPatch("{id}")]
        public IActionResult PatchAluno(int id, Aluno aluno)
        {
            return Ok(aluno);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(int id)
        {
            return Ok("Usuário excluido");
        }
    }
}
