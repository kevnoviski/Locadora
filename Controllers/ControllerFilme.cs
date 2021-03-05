using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Locadora.Model;
using Locadora.Data;
using AutoMapper;
using Locadora.Dtos;
using System;

namespace Locadora.Models
{
    //configuracao da rota para utilizar a api
    [Route("api/filme")]
    [ApiController]
    public class ControllerFilme : ControllerBase, IControllerFilme
    {
        private readonly IFilmeRepo _repository;
        private readonly IMapper _mapper;

        public ControllerFilme(IFilmeRepo repository, IMapper mapper)
        {
            //mapeamento do repositorio usando dependency injection, definido no startup.cs
            _repository = repository;

            _mapper = mapper;
        }

        //POST api/filme/
        //notações como HttpPost,HttpDelete("{id}").. etc definem qual método devera ser chamado de acordo com a requisição recebida
        [HttpPost]
        public ActionResult<Filme> CreateFilme(FilmeCreateAlterDto filmeDto)
        {
            try
            {
                _repository.BeginTransaction();

                //combina o modelo oficial com o Dto de criacao
                var filmeModel = _mapper.Map<Filme>(filmeDto);

                //adiciona no _repositorio
                _repository.CreateFilme(filmeModel);

                //de fato salva no banco de dados.
                _repository.SaveChanges();

                _repository.Commit();

                //converte o objeto de gravação em um de leitura
                var filmeReadDto = _mapper.Map<FilmeReadDto>(filmeModel);
                //retorna o objeto criado.
                return CreatedAtRoute(/*nome da rota GET*/nameof(GetFilmeById), /*valor para passar no GET*/new {Id = filmeReadDto.Id},/*body*/filmeReadDto);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                _repository.Rollback();
                return BadRequest();
            }
        }
        //DELETE api/filme/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteFilme(int id)
        {
            // filtra do banco de dados o registro que esta sendo atualizado
            var filme = _repository.GetFilmeById(id);
            if(filme != null)
            {
                //deleta
                _repository.DeleteFilme(filme);
                //efetiva o delete no banco de dados.
                _repository.SaveChanges();
                return NoContent();
            }
            return NotFound();
        }
        //DELETE api/filme/   -Para deletar multiplos valores insira no corpo da requisicao delete  = [ 4,6,55 ]
        [HttpDelete]
        public ActionResult DeleteFilmes([FromBody] int[] id)
        {
            foreach(int nr_id in id)
            {
                var filme = _repository.GetFilmeById(nr_id);
                if(filme == null)
                {
                    return NotFound();
                }
                //deleta
                _repository.DeleteFilme(filme);
                
            }
            //efetiva o delete no banco de dados.
            _repository.SaveChanges();
            return Ok();
        }

        //GET api/filme/
        [HttpGet]
        public ActionResult<IEnumerable<Filme>> GetAllFilmes()
        {
            var todosOsfilmes= _repository.GetAllIFilmes();
            if(todosOsfilmes == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<FilmeReadDto>>(todosOsfilmes));
        }

        //GET api/filme/{id}
        [HttpGet("{id:int}",Name="GetFilmeById")]
        public ActionResult<Filme> GetFilmeById(int id)
        {
            var filme = _repository.GetFilmeById(id);
            if(filme != null)
            {
                return Ok(_mapper.Map<FilmeReadDto>(filme));
            }
            return NotFound();
        }
        //PUT api/filme/{id}
        [HttpPut("{id:int}")]
        public ActionResult UpdateFilme(int id, FilmeCreateAlterDto filmeDto)
        {
            
            // filtra do banco de dados o registro que esta sendo atualizado
            var filmeFromRepo = _repository.GetFilmeById(id);
            if(filmeFromRepo == null)
            {
                return NotFound();
            }
            //faz merge substituindo com os valores novos o resgistro filtrado 'filmeFromRepo'
            _mapper.Map(filmeDto,filmeFromRepo);

            
            try{
                _repository.BeginTransaction();
                //salva no banco de dados o registro alterado
                _repository.SaveChanges();
                
                _repository.Commit();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                _repository.Rollback();
                return BadRequest();
            }
            
            return Ok();
        }
    }
}