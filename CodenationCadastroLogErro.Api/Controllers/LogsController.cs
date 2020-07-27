using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using CodenationCadastroLogErro.Dominio.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [HttpPost("cadastrar")]
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
        [HttpPut("arquivar")]
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
        [HttpGet("listar")]
        public IActionResult Listar()
        {
            try
            {
                return Ok(_repository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("ordernaPorLevel")]
        public IActionResult OrdernaPorLevel()
        {
            try
            {
                return Ok(_repository.OrdernaPorLevel());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet("ordernaPorFrequencia")]
        public IActionResult OrdernaPorFrequencia()
        {
            try
            {
                return Ok(_repository.OrdernaPorFrequencia());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpGet]
        [Route("log/{id:int}")]
        public IActionResult SelecionarLog(int id)
        {
            try
            {
                return Ok(_repository.SelecionarLog(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("setor/{id:int}")]
        public IActionResult SelecionarPorSetor(int id)
        {
            try
            {
                return Ok(_repository.SelecionarPorSetor(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
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

