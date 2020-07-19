using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using System;
using Microsoft.AspNetCore.Authorization;

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
        [HttpGet("listar")]
        public ICollection<Logs> listarErros() 
        {
            return _repository.SelicionarTodos();
        }

        // GET: api/teste/5
        [HttpGet("{id}")]
        public Logs GetLogs(int id)
        {
            return _repository.SelecionarPorId(id);
        }
        [HttpPost("Cadastro")]
        public IActionResult Cadastrar([FromBody] Logs logs)
        {
            try
            {   
                _repository.Incluir(logs);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar([FromBody] Logs logs)
        {
            try
            {
                _repository.Alterar(logs);
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
        /*
        // PUT: api/teste/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/teste
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: api/teste/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        */

