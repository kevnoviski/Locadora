using System;
using System.Collections.Generic;

#nullable disable

namespace Locadora.Model
{
    public partial class Genero
    {
        public Genero()
        {
            Filmes = new HashSet<Filme>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DtCriacao { get; set; }
        public int? Ativo { get; set; }

        public virtual ICollection<Filme> Filmes { get; set; }
    }
}
