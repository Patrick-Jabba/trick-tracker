
using System.ComponentModel.DataAnnotations;

namespace ms_tracker.Models
{
    public class Tarefa
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public int DuracaoEmSegundos { get; set; }
        [Required]
        public string Descricao {get; set;}

        [Required]
        public int ProjetoId {get; set;}

        public virtual Projeto Projeto {get; set;}
        
    }
}