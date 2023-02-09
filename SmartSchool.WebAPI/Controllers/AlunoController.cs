using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno()
            {
                Id = 1,
                Nome = "Ysmael",
                Sobrenome = "Braga",
                Telefone = "21986142456"
            },
             new Aluno()
            {
                Id = 2,
                Nome = "Sara",
                Sobrenome = "Dias",
                Telefone = "21986799449"
            },
              new Aluno()
            {
                Id = 3,
                Nome = "Braga",
                Sobrenome = "Do Carmo",
                Telefone = "21986142456"
            },
        };
        public AlunoController() { }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }
        [HttpGet("byId/{id}")]
        public IActionResult GetId(int id)
        {

            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");
            return Ok(aluno);

        }

        [HttpGet("ByName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(
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

    }
}
