namespace SmartSchool.WebAPI.Models
{
    public class Professor
    {
        public Professor() { }
        public int Id { get; set; }
        public int Nome { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}
