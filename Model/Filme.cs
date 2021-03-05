using System;
using System.Collections.Generic;

#nullable disable

namespace Locadora.Model
{
    public partial class Filme
    {
        public Filme()
        {
            LocacaoFilmes = new HashSet<LocacaoFilme>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Dtcriacao { get; set; }
        public int Ativo { get; set; }
        public int Idgenero { get; set; }

        public virtual Genero IdgeneroNavigation { get; set; }
        public virtual ICollection<LocacaoFilme> LocacaoFilmes { get; set; }
    }
}
