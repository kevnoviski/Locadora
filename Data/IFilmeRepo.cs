using System.Collections.Generic;
using Locadora.Model;

namespace Locadora.Data
{
    public interface IFilmeRepo
    {
        bool SaveChanges();
        IEnumerable<Filme> GetAllIFilmes();
        Filme GetFilmeById(int id);
        void CreateFilme(Filme filme);
        void DeleteFilme(Filme filme);
    }
}