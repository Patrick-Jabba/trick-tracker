using System.ComponentModel.DataAnnotations;

namespace ms_tracker.Models.Dtos.Tarefa
{
    public class AddTarefaDto
    {
        public int DuracaoEmSegundos { get; set; }
        [Required]
        public string Descricao {get; set;}

        public int ProjetoId {get; set;}
        
    }
}