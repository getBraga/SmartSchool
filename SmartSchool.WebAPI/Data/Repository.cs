using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;
        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() > 0);
        }


        public async Task<PageList<Aluno>> GetAllAlunosAsync(
            PageParams pageParams,
            bool includeProfessor = false
            )
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(p => p.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            //return await query.ToListAsync();
            return await PageList<Aluno>.CreateAsync(query, pageParams.PageNumber, pageParams.PageSize);

        }
        public Aluno[] GetAllAlunos(bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(p => p.Professor);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return query.ToArray();

        }

        public Aluno[] GetAllAlunosByDisciplina(int disciplinaId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(p => p.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id).Where(a => a.AlunosDisciplinas.Any(ad => ad.DisciplinaId == disciplinaId));
            return query.ToArray();

        }

        public Aluno GetAlunoById(int id, bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if (includeProfessor)
            {
                query = query.Include(a => a.AlunosDisciplinas)
                             .ThenInclude(ad => ad.Disciplina)
                             .ThenInclude(p => p.Professor);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id).Where(a => a.Id == id);
            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessores(bool includeAlunos)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAlunos)
            {
                query = query.Include(p => p.Disciplinas)
                    .ThenInclude(a => a.AlunosDisciplinas)
                    .ThenInclude(a => a.Aluno);
            }
            query = query.AsNoTracking().OrderBy(p => p.Id);
            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplina(int disciplinaId, bool includeAluno)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAluno)
            {
                query = query.Include(a => a.Disciplinas)
                             .ThenInclude(ad => ad.AlunosDisciplinas)
                             .ThenInclude(p => p.Aluno);
            }
            query = query.AsNoTracking().OrderBy(a => a.Id).Where(d => d.Disciplinas.Any(
                                      ad => ad.AlunosDisciplinas.Any(
                                      a => a.DisciplinaId == disciplinaId)));
            return query.ToArray();

        }

        public Professor GetProfessorById(int professorId, bool includeAluno)
        {
            IQueryable<Professor> query = _context.Professores;
            if (includeAluno)
            {
                query = query.Include(query => query.Disciplinas)
                             .ThenInclude(query => query.AlunosDisciplinas)
                             .ThenInclude(query => query.Aluno);
            }
            query = query.AsNoTracking().Where(p => p.Id == professorId);
            return query.FirstOrDefault();
        }
    }
}
