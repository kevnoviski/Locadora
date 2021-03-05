using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Locadora.Model;
using Microsoft.EntityFrameworkCore.Storage;

namespace Locadora.Data
{
    public class SqlFilmeRepo : IFilmeRepo
    {
        private readonly LocadoraContext _context;
        private IDbContextTransaction transaction;

        public SqlFilmeRepo(LocadoraContext context)
        {
            _context = context;
        }
        public void BeginTransaction(){
            transaction = _context.Database.BeginTransaction();        
        }
        public void Rollback(){
            if(transaction != null)
            {
                transaction.Rollback() ;
                transaction.Dispose();
            }
        }
        public void Commit(){
            if(transaction != null)
            {
                transaction.Commit() ;
                transaction.Dispose();
            }
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
            return(_context.SaveChanges() >=0);
        }

    }
}