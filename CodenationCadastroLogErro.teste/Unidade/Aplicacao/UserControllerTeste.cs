using CodenationCadastroLogErro.Dominio.Repository;
using CodenationCadastroLogErro.Api.Controllers;
using CodenationCadastroLogErro.Teste.Builders;
using CodenationCadastroLogErro.Recursos;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
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
        public void Cadastrar_deve_salvar_usuario()
        {
            //arrange
            var CriarUsuario = new UsuarioBuilder().ConstruirUser();
            //act
            var retorno = _controller.Cadastrar(CriarUsuario);
            //assert
            _repository.Received(1).Cadastrar(CriarUsuario);
            retorno.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void Cadastrar_deve_retornar_Bad_request_quando_Email_for_invalido()
        {
            //arrange
            var CriarUsuario = new UsuarioBuilder()
                .SemEmail(string.Empty)
                .ConstruirUser();

            _repository.When(x => x.Cadastrar(CriarUsuario))
                .Do(x =>
                {
                    throw new Exception(MensagensErro.EmailObrigatorio);
                });
            //act
            var retorno = _controller.Cadastrar(CriarUsuario);
            //assert
            retorno.Should().BeOfType<BadRequestObjectResult>();
        }
        [Fact]
        public void Cadastrar_deve_retornar_Bad_request_quando_Senha_for_invalido()
        {
            //arrange
            var CriarUsuario = new UsuarioBuilder()
                .SemSenha(string.Empty)
                .ConstruirUser();

            _repository.When(x => x.Cadastrar(CriarUsuario))
                .Do(x =>
                {
                    throw new Exception(MensagensErro.senha);
                });
            //act
            var retorno = _controller.Cadastrar(CriarUsuario);
            //assert
            retorno.Should().BeOfType<BadRequestObjectResult>();
        }

        [Fact]
        public void Login_deve_permitir_Acesso_ao_usuario()
        {
            //arrange
            var LoginUsuarioDto = new UsuarioBuilder().ConstruirUserDto();
            //act
            var retorno = _controller.Login(LoginUsuarioDto);
            //assert
            _repository.Received(1).Login(LoginUsuarioDto);
            retorno.Should().BeOfType<OkObjectResult>();

        }
        [Fact]
        public void Login_deve_retornar_Bad_request_quando_Senha_for_invalido()
        {
            //arrange
            var LoginUsuarioDto = new UsuarioBuilder().SemSenha(string.Empty).ConstruirUserDto();
            _repository.When(x => x.Login(LoginUsuarioDto))
                .Do(x =>
                {
                    throw new Exception(MensagensErro.senha);
                });
            //act
            var retorno = _controller.Login(LoginUsuarioDto);
            //assert
            _repository.Received(1).Login(LoginUsuarioDto);
            retorno.Should().BeOfType<BadRequestObjectResult>();

        }
       [Fact]
        public void Login_deve_retornar_Bad_request_quando_email_for_invalido()
        {
            //arrange
            var LoginUsuarioDto = new UsuarioBuilder().SemEmail(string.Empty).ConstruirUserDto();
            _repository.When(x => x.Login(LoginUsuarioDto))
                .Do(x =>
                {
                    throw new Exception(MensagensErro.EmailObrigatorio);
                });
            //act
            var retorno = _controller.Login(LoginUsuarioDto);
            //assert
            _repository.Received(1).Login(LoginUsuarioDto);
            retorno.Should().BeOfType<BadRequestObjectResult>();

        }

    }

}
