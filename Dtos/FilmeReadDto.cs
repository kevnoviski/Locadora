using System;

namespace Locadora.Dtos
{
    public class FilmeReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Dtcriacao { get; set; }
        public int Ativo { get; set; }
        public int Idgenero { get; set; }
    }
}