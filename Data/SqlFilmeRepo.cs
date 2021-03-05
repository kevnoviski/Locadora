using System;
using System.Collections.Generic;
using System.Linq;
using Locadora.Model;

namespace Locadora.Data
{
    public class SqlFilmeRepo : IFilmeRepo
    {
        private readonly LocadoraContext _context;

        public SqlFilmeRepo(LocadoraContext context)
        {
            _context = context;
        }
        public void CreateFilme(Filme filme)
        {
            if(filme == null)
            {
                throw new ArgumentNullException(nameof(filme));
            }
            _context.Filmes.Add(filme);
        }

        public void DeleteFilme(Filme filme)
        {
            if(filme == null)
            {
                throw new ArgumentNullException(nameof(filme));
            }
            _context.Filmes.Remove(filme);
        }

        public IEnumerable<Filme> GetAllIFilmes()
        {
            return _context.Filmes.ToList();
        }

        public Filme GetFilmeById(int id)
        {
            return _context.Filmes.FirstOrDefault(x => x.Id == id);
        }

        public bool SaveChanges()
        {
            return(_context.SaveChanges() >= 0);
        }

    }
}