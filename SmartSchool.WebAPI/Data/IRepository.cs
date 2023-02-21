using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T: class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        Task<PageList<Aluno>> GetAllAlunosAsync(PageParams pageParams, bool includeProfessor);
        Aluno[] GetAllAlunos(bool includeProfessor);
        Aluno[] GetAllAlunosByDisciplina(int disciplinaId, bool includeProfessor);
        Aluno GetAlunoById(int alunoId, bool includeProfessor = false);

        Professor[] GetAllProfessores(bool includeAlunos);
        Professor[] GetAllProfessoresByDisciplina(int professorId, bool includeAlunos);
        Professor GetProfessorById(int professorId, bool includeAlunos);

    }

}
