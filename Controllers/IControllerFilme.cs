using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Locadora.Model;
namespace Locadora.Models
{
    // interface para ajudar a mapear os requisitos 
    /*
        Requisitos de negócio:
            Listar os filmes cadastrados
            Cadastrar um novo filme
            Editar um filme
            Remover um filme individualmente
            Remover vários filmes de uma só vez
    */
    public interface IControllerFilme 
    {
        ActionResult <IEnumerable<Filme>> GetAllFilmes();
        ActionResult <Filme> GetFilmeById(int id);
        ActionResult <Filme> CreateFilme(Filme filme);
        ActionResult UpdateFilme(int id, Filme filme);
        ActionResult DeleteFilme(int id);
        ActionResult DeleteFilmes(List<Filme> filmes);
    }
}