using System;

namespace Locadora.Dtos
{
    /*
        Dto -  Data Transfer objects
        usado para filtrar o que vai ser lido do banco, neste caso quero que apenas estes campos sejam enviados via GET.
    */
    public class FilmeReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Dtcriacao { get; set; }
        public int Ativo { get; set; }
        public int Idgenero { get; set; }
    }
}