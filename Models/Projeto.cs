using System.ComponentModel.DataAnnotations;

namespace GerenciadorProjetos.Models
{
    public class Projeto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome do Projeto")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Responsável")]
        public string Responsavel { get; set; } = string.Empty;

        [Display(Name = "Data de Início")]
        public DateTime DataInicio { get; set; }

        [Required]
        public string Status { get; set; } = string.Empty;

        public ICollection<Tarefa> Tarefas { get; set; } = new List<Tarefa>();
    }
}