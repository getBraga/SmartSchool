namespace SmartSchool.WebAPI.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() { }

        public AlunoDisciplina(int alunoID, int disciplinaId)
        {
            AlunoId = AlunoId;
            DisciplinaId = disciplinaId;
        }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public Disciplina Disciplina { get; set; }
        public int DisciplinaId { get; set; }
    }
}
