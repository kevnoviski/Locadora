using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Locadora.Model;
using Locadora.Data;

namespace Locadora.Models
{
    //configuracao da rota para utilizar a api
    [Route("locadora/filme")]
    [ApiController]
    public class ControllerFilme : ControllerBase, IControllerFilme
    {
        private readonly IFilmeRepo _repository;

        public ControllerFilme(IFilmeRepo repository)
        {
            //mapeamento do repositorio usando dependency injection, definido no startup.cs
            _repository = repository;
        }

        //POST locadora/filme/
        //notações como HttpPost,HttpDelete("{id}").. etc definem qual método devera ser chamado de acordo com a requisição recebida
        [HttpPost]
        public ActionResult<Filme> CreateFilme(Filme filme)
        {
            throw new System.NotImplementedException();
        }
        //DELETE locadora/filme/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteFilme(int id)
        {
            throw new System.NotImplementedException();
        }

        public ActionResult DeleteFilmes(List<Filme> filmes)
        {
            throw new System.NotImplementedException();
        }

        //GET locadora/filme/
        [HttpGet]
        public ActionResult<IEnumerable<Filme>> GetAllFilmes()
        {
            var todosOsfilmes= _repository.GetAllIFilmes();
            if(todosOsfilmes == null)
            {
                return NotFound();
            }
            return Ok(todosOsfilmes);
        }

        //GET locadora/filme/{id}
        [HttpGet("{id}")]
        public ActionResult<Filme> GetFilmeById(int id)
        {
            throw new System.NotImplementedException();
        }
        //PUT locadora/filme/{id}
        [HttpPut("{id:int}")]
        public ActionResult UpdateFilme(int id, Filme filme)
        {
            throw new System.NotImplementedException();
        }
    }
}