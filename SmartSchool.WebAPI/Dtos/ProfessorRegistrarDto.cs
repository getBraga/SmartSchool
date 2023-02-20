using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Dtos
{
    public class ProfessorRegistrarDto
    {

        /// <summary>
        /// Nome do professor
        /// </summary>
        public int Registro { get; set; }
        /// <summary>
        /// Nome do professor
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Sobrenome do professor
        /// </summary>
        public string Sobrenome { get; set; }
        /// <summary>
        /// Telefone do professor
        /// </summary>
        public string? Telefone { get; set; }
        /// <summary>
        /// Data de inicio na smartScool
        /// </summary>
        public DateTime DataInicio { get; set; } = DateTime.Now;
        /// <summary>
        /// Data de nascimento do Professor
        /// </summary>
        public DateTime DataNascimento { get; set; }
        /// <summary>
        /// Data do termino de contrato na SmartSchool
        /// </summary>
        public DateTime? DataFim { get; set; } = null;
        /// <summary>
        /// Verificacao se o professor está ativo
        /// </summary>
        public bool Ativo { get; set; } = true;
    }
}
