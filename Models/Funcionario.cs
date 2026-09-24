using System.ComponentModel.DataAnnotations;

namespace GerenciadorProjetos.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Cargo { get; set; } = string.Empty;

        [Required]
        public string Departamento { get; set; } = string.Empty;

        [Display(Name = "Data de Admissão")]
        public DateTime DataAdmissao { get; set; }
    }
}