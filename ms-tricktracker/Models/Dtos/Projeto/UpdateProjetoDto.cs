using System.ComponentModel.DataAnnotations;

namespace ms_tracker.Models.Dtos.Projeto
{
    public class UpdateProjetoDto
    {
        [Required(ErrorMessage = "O título do projeto é obrigatório.")]
        public string Nome { get; set; }
    }
}