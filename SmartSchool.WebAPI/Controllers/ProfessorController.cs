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
        private readonly DataContext _context;
        private readonly IRepository _repo;
        public ProfessorController(DataContext context , IRepository repo)
        {
            this._context = context;
            this._repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Professor);
        }
        [HttpGet("byId/{id}")]
        public IActionResult GetId(int id)
        {
            var professor = _context.Professor.FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest("O Professor não foi encontrado!");
            return Ok(professor);
        }

        [HttpGet("ByName")]
        public IActionResult ByName(string name)
        {
            var professor = _context.Professor.FirstOrDefault(p => p.Nome == name);
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
            var findProfessor = _context.Professor.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (findProfessor == null) return BadRequest("O Professor não foi encontrado!");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }
        [HttpPatch("{id}")]
        public IActionResult PatchProfessor(int id, Professor professor)
        {
            var findProfessor = _context.Professor.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (findProfessor == null) return BadRequest("O Professor não foi encontrado!");
            _context.Update(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProfessor(int id)
        {
            var professor = _context.Professor.AsNoTracking().FirstOrDefault(p => p.Id == id);
            if (professor == null) return BadRequest("O Professor não foi encontrado!");
            _context.Remove(professor);
            _context.SaveChanges();
            return Ok("Professor excluido com sucesso!");
        }
    }
}
