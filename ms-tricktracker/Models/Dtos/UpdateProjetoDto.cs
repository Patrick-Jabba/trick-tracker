using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ms_tracker.Models.Dtos
{
    public class UpdateProjetoDto
    {
        [Required(ErrorMessage = "O título do projeto é obrigatório.")]
        public string Nome { get; set; }
    }
}