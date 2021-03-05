using System;
using System.Collections.Generic;

#nullable disable

namespace Locadora.Model
{
    public partial class LocacaoFilme
    {
        public int Id { get; set; }
        public int IdLocacao { get; set; }
        public int IdFilme { get; set; }

        public virtual Filme IdFilmeNavigation { get; set; }
        public virtual Locacao IdLocacaoNavigation { get; set; }
    }
}
