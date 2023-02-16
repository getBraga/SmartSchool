using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private  IRepository _repo { get; set; }
        public AlunoController(DataContext context, IRepository repo)
        {
            this._context = context;
            this._repo = repo;
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
            _repo.Add(aluno);
            if(_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult PutAluno(int id, Aluno aluno) 
        {
            var findAluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (findAluno == null) return BadRequest("O Aluno não foi encontrado!");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("O Aluno não foi encontrado!");
          
        }
        [HttpPatch("{id}")]
        public IActionResult PatchAluno(int id, Aluno aluno)
        {
            var findAluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (findAluno == null) return BadRequest("O Aluno não foi encontrado!");

            _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("O Aluno não foi encontrado!");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAluno(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
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
