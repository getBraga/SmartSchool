using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;
using System.Xml.Linq;

namespace SmartSchool.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        public ProfessorController(IRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAllProfessores(true));
        }
        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("O Professor não foi encontrado!");
            return Ok(professor);
        }

        [HttpPost]
        public IActionResult PostProfessor(Professor professor)
        {
            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não cadastrado!");
        }

        [HttpPut("{id}")]
        public IActionResult PutProfessor(int id, Professor professor)
        {
            var findProfessor = _repo.GetProfessorById(id, false);
            if (findProfessor == null) return BadRequest("O Professor não foi encontrado!");
            _repo.Update(professor);
            _repo.SaveChanges();
            return Ok(professor);
        }
        [HttpPatch("{id}")]
        public IActionResult PatchProfessor(int id, Professor professor)
        {
            var findProfessor = _repo.GetProfessorById(id, false);
            if (findProfessor == null) return BadRequest("O Professor não foi encontrado!");
            _repo.Update(professor);
            _repo.SaveChanges();
            return Ok(professor);
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
