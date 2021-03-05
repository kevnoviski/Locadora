using System.Collections.Generic;
using Locadora.Model;

namespace Locadora.Data
{
    public interface IFilmeRepo
    {
        void BeginTransaction();
        bool SaveChanges();
        void Commit();
        void Rollback();
        IEnumerable<Filme> GetAllIFilmes();
        Filme GetFilmeById(int id);
        void CreateFilme(Filme filme);
        void DeleteFilme(Filme filme);
    }
}