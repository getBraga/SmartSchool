namespace SmartSchool.WebAPI.Models
{
    public class Professor
    {
        public Professor() { }

        public Professor(int id, 
                         int registro, 
                         string nome, 
                         string sobrenome, 
                         DateTime dataNascimento)
        {
            Id = id;
            Registro = registro;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento; 
        }

        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataInicio { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; } = true;
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}
