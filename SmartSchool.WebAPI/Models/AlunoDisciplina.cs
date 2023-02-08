namespace SmartSchool.WebAPI.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() { }

        public AlunoDisciplina(int alunoID, int disciplinaId)
        {
            AlunoID = alunoID;
            DisciplinaId = disciplinaId;
        }

        public int AlunoID { get; set; }
        public Aluno Aluno { get; set; }
        public Disciplina Disciplina { get; set; }
        public int DisciplinaId { get; set; }
    }
}
