using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("{id}")]
        /*
        public Setor SelecionarPorId(int id)
        {
            return _repository.SelecionarPorId(id);
        }
         */
       
        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar([FromBody] Setor setor)
        {
            try
            {
             //   _repository.Incluir(setor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult Alterar([FromBody] Setor setor)
        {
            try
            {
                _repository.Alterar(setor);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Excluir(int id)
        {
            try
            {
                _repository.Excluir(id);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
