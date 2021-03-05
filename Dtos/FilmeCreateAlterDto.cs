using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Dtos
{
    /*
        Dto -  Data Transfer objects
        Usado para validação do conteúdo antes persistir no banco
    */
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