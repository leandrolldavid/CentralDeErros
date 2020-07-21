using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using CodenationCadastroLogErro.Servico.Validador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CodenationCadastroLogErro.Api.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly ValidadorUsuario _validador;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
            _validador = new ValidadorUsuario();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody]UserDto login)
        {
            try
            {
                return Ok(_repository.Login(login));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
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
        [HttpGet]
        [Authorize("admin")]
        [Route("listar")]
        public IActionResult listar()
        {
            try
            {
                return Ok( _repository.SelicionarTodos());
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }

        [HttpPost("Cadastrar")]
        [AllowAnonymous]
        public IActionResult Cadastrar([FromBody] User user)
        {
            try
            {
                return Ok(_repository.Incluir(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        [Authorize]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] User user)
        {
            try
            {
                _repository.Alterar(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpDelete]
        [Authorize("Admin")]
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

        [HttpPut]
        [Authorize("admin")]
        [Route("inserir")]
        public IActionResult InserirRole([FromBody] UserRoleDto user)
        {
            try
            {
                return Ok( _repository.InserirRole(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
