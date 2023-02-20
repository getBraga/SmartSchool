namespace SmartSchool.WebAPI.Dtos
{
    public class AlunoAtualizarDtro
    {
        /// <summary>
        /// Identificador Unico no banco de dados
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Matricula do aluno
        /// </summary>
        public int Matricula { get; set; }
        /// <summary>
        /// Nome completo do aluno
        /// </summary>
        public string? NomeCompleto { get; set; }
        /// <summary>
        /// Nome completo do aluno
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// sobrenome do aluno
        /// </summary>
        public string Sobrenome { get; set; }
        public string? Telefone { get; set; }
        /// <summary>
        /// Data de nascimento do aluno
        /// </summary>
        public DateTime DataNascimento { get; set; }
        /// <summary>
        /// Data de entrada na SmartSchool
        /// </summary>
        public DateTime DataInicio { get; set; } = DateTime.Now;
        /// <summary>
        /// Data fim  na SmartSchool
        /// </summary>
        public DateTime? DataFim { get; set; } = null;
        /// <summary>
        /// Verifica se o aluno está ativo
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}
