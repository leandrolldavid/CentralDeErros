using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodenationCadastroLogErro.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Authorize("Admin")]
    public class SetorController : ControllerBase
    {
        private readonly ISetorRepository _repository;
        public SetorController(ISetorRepository repository)
        {
            _repository = repository;
        }      
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] Setor setor)
        {
            try
            {
                return Ok(_repository.Cadastrar(setor)); 
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }
        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<IEnumerable<Setor>> SelecionarPorId(int id)
        {//ok
            try
            {
                return Ok( _repository.SelecionarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("listar")]
        public ActionResult<IEnumerable<Setor>> Listar()
        {
            try
            {
                return Ok(_repository.SelicionarTodos());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpPut]
        public IActionResult Alterar([FromBody] Setor setor)
        {
            try
            {
                return Ok( _repository.Alterar(setor)); 
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                return Ok( _repository.Excluir(id)); 
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }
    }
}
