using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using System;
using Microsoft.AspNetCore.Authorization;
using CodenationCadastroLogErro.Dominio.Dtos;

namespace CodenationCadastroLogErro.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class LogsController : ControllerBase
    {
        private readonly ILogsRepository _repository;

        public LogsController(ILogsRepository repository)
        {
            _repository = repository;
        }
        [HttpPut]
        [Authorize()]
        [Route("arquivar")]
        public IActionResult Arquivar([FromBody] LogDto log)
        {
            try
            {
                return Ok(_repository.Arquivar(log));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Authorize]
        [Route("listar")]
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

        [HttpGet]
        [Authorize]
        [Route("{id:int}")]
        public IActionResult SelecionarPorId(int id)
        {
            try
            {
                return Ok(_repository.SelecionarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost("Cadastrar")]
        [Authorize]
        public IActionResult Cadastrar([FromBody] Logs logs)
        {
            try
            {
                return Ok(_repository.Incluir(logs));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] Logs logs)
        {
            try
            {
                return Ok(_repository.Alterar(logs));    
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Authorize]
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