using System.ComponentModel.DataAnnotations;

namespace ms_tracker.Models.Dtos.Tarefa
{
    public class UpdateTarefaDto
    {
        [Required]
        public string Descricao {get; set;}

        public int ProjetoId { get; set; }
    }
}