using System;
using System.Collections.Generic;

#nullable disable

namespace Locadora.Model
{
    public partial class Locacao
    {
        public Locacao()
        {
            LocacaoFilmes = new HashSet<LocacaoFilme>();
        }

        public int Id { get; set; }
        public string Cpf { get; set; }
        public DateTime? Dtlocacao { get; set; }

        public virtual ICollection<LocacaoFilme> LocacaoFilmes { get; set; }
    }
}
