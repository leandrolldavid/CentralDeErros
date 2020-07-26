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
    public class TipoLogController : ControllerBase
    {
         private readonly ITipoLogRepository _repository;
        public TipoLogController(ITipoLogRepository repository)
        {
            _repository = repository;
        }
        [HttpPost("cadastrar")]
        public IActionResult Cadastrar([FromBody] TipoLog tipoLog)
        {
            try
            {
                return Ok( _repository.Cadastrar(tipoLog));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
           
        }
        [HttpGet]
        [Route("selecionar/{id:int}")]
        public ActionResult<IEnumerable<TipoLog>> SelecionarPorId(int id)
        {
            try
            {
            return Ok(_repository.SelecionarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("listar")]
        public IActionResult Listar()
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
        public IActionResult Alterar([FromBody] TipoLog tipoLog)
        {
            try
            {
                return Ok(_repository.Alterar(tipoLog));
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
                return Ok(_repository.Excluir(id));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }
    }
}
