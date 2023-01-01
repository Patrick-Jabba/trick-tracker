using ms_tracker.Models;

namespace ms_tracker.Models.Dtos.Tarefa
{
    public class ReadTarefaDto
    {
        public int Id {get; set;}
        public int DuracaoEmSegundos { get; set; }
        
        public string Descricao {get; set;}
        
        public int ProjetoId {get; set;}
        public virtual Models.Projeto Projeto {get; set;}
    }
}