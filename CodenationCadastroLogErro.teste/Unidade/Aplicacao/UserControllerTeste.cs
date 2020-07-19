using CodenationCadastroLogErro.Api.Controllers;
using CodenationCadastroLogErro.Dominio.Repository;
using CodenationCadastroLogErro.Resursos;
using CodenationCadastroLogErro.Teste.Builders;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using System;
using Xunit;

namespace CodenationCadastroLogErro.teste.Unidade.Aplicacao
{
    public class UserControllerTeste
    {
        private readonly UserController _controller;
        private readonly IUserRepository _repository;
        public UserControllerTeste()
        {
            _repository = Substitute.For<IUserRepository>();
            _controller = new UserController(_repository);
        }
        [Fact]
        public void Adicionar_deve_salvar_usuario()
        {
            //arrange
            var CriarUsuario = new UsuarioBuilder().ConstruirUser();
            //act
            var retorno = _controller.Cadastrar(CriarUsuario);
            //assert
            _repository.Received(1).Incluir(CriarUsuario);
            retorno.Should().BeOfType<OkResult>();
        }

        [Fact]
        public void Adicionar_deve_retornar_Bad_request_quando_usuario_for_invalido()
        {
            //arrange
            var CriarUsuario = new UsuarioBuilder()
                .SemEmail(string.Empty)
                .ConstruirUser();

            _repository.When(x => x.Incluir(CriarUsuario))
                .Do(x =>
                {
                    throw new Exception(MensagensErro.EmailObrigatorio);
                });

            //act
            var retorno = _controller.Cadastrar(CriarUsuario);
            //assert
            retorno.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
