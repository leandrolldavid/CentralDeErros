using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        [HttpPost("Login")]
        [AllowAnonymous]
        public string Login([FromBody]UserDto login)
        {
            var resultado = _repository.Login(login);
            return resultado;
        }
        [HttpGet("{id}")]
        [Authorize("User") ]
        public User GetUser(int id)
        {
            return _repository.SelecionarPorId(id);
        }
        [HttpPost("Cadastro")]
        [AllowAnonymous]
        public IActionResult Incluir([FromBody] User user)
        {
            try
            {
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
        public IActionResult Alterar([FromBody] User user)
        {
            _repository.Alterar(user);
            return Ok();
        }
        [HttpDelete]
        [Authorize("Admin")]
        [Route("{id:int}")]
        public IEnumerable<User> Excluir(int id)
        {
            _repository.Excluir(id);
            return _repository.SelicionarTodos();
        }

    }
}
