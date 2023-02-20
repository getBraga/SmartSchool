using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Dtos
{
    public class ProfessorDto
    {
        /// <summary>
        /// Identificador Unico no banco de dados
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Registo do professor
        /// </summary>
        public int Registro { get; set; }
        /// <summary>
        /// Nome completo do professor
        /// </summary>
        public string? NomeCompleto { get; set; }
        /// <summary>
        /// Nome do professor
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Sobrenome do professor
        /// </summary>
        public string Sobrenome { get; set; }
        /// <summary>
        /// Idade do professor
        /// </summary>
        public int Idade { get; set; }
        /// <summary>
        /// Data de inicio na smartScool
        /// </summary>
        public DateTime DataInicio { get; set; } = DateTime.Now;
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
