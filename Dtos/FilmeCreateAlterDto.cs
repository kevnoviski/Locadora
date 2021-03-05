using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Dtos
{
    public class FilmeCreateAlterDto
    {
        [Required]
        [MaxLength(200)]
        public string Nome { get; set; }
        public DateTime Dtcriacao { get; set; }
        public int Ativo { get; set; }

        [Required]
        public int Idgenero { get; set; }
    }
}