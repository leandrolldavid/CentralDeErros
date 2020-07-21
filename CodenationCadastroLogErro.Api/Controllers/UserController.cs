using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
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

        public UserController(IUserRepository repository)
        {
            _repository = repository;
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
        public IActionResult Listar()
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
                return Ok( _repository.Alterar(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Authorize("admin")]
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
