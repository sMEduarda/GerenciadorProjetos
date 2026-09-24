using System.ComponentModel.DataAnnotations;

namespace GerenciadorProjetos.Models
{
    public class Tarefa
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Titulo { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        public string Prioridade { get; set; } = string.Empty;

        [Display(Name = "Data Limite")]
        public DateTime DataLimite { get; set; }

        [Display(Name = "Concluída")]
        public bool Concluida { get; set; }

        [Display(Name = "Projeto")]
        public int ProjetoId { get; set; }

        public Projeto? Projeto { get; set; }
    }
}