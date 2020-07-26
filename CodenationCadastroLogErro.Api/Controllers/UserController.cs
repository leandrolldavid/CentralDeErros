using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        [Route("selecionar/{id:int}")]
        public ActionResult<IEnumerable<User>> SelecionarPorId(int id)
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
        [HttpGet("listar")]
        [Authorize("admin")]
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
        [HttpPost("cadastrar")]
        [AllowAnonymous]
        public IActionResult Cadastrar([FromBody] User user)
        {
            try
            {
                return Ok(_repository.Cadastrar(user));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Authorize]
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
        [HttpPut("permissao")]
        [Authorize("admin")]
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
