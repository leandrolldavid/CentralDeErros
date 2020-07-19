using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using CodenationCadastroLogErro.Resursos;
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
        public string Login([FromBody]UserDto login)
        {
              var validarResultado =  _repository.Login(login);
            if (validarResultado is null) return null;
            return validarResultado;
        }
        [HttpGet("{id}")]
        [Authorize]
        public User SelecionarPorId(int id)
        {
            return _repository.SelecionarPorId(id);
        }

        [HttpPost("Cadastrar")]
        [AllowAnonymous]
        public IActionResult Cadastrar([FromBody] User user)
        {
            try
            {
                var validarResultado = _validador.Validate(user);
                if (!validarResultado.IsValid.Equals(true)) return BadRequest(validarResultado.Errors);
                     user.Role = "user";
                   _repository.Incluir(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
        [HttpPut]
        [Authorize]
        [Route("alterar")]
        public IActionResult Alterar([FromBody] User user)
        {
            try
            {
                var validarResultado = _validador.Validate(user);
                if (!validarResultado.IsValid.Equals(true)) return BadRequest(validarResultado.Errors);
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
        [Authorize("Admin")]
        [Route("inserir")]
        public IActionResult InserirRole([FromBody] User user)
        {
            try
            {
                _repository.inserirRole(user);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}
