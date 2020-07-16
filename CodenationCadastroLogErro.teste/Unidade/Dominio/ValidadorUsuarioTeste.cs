using CodenationCadastroLogErro.Servico.Validador;
using FluentAssertions;
using Xunit; 
using System;
using CodenationCadastroLogErro.Teste.Builders;

namespace CodenationCadastroLogErro.Teste.Unidade.Dominio
{
    public class ValidadorUsuarioTeste
    {
        private readonly ValidadorUsuario _validador;

        public ValidadorUsuarioTeste()
        {
            _validador = new ValidadorUsuario();
        }
        
        [Fact]
        public void Validete_deve_retornar_invalido_quando_usuario_nao_tiver_nome()
        {
            var usuarioInvalido = new UsuarioBuilder().SemNome(string.Empty).ConstruirUser();
            //act
             var resultado = _validador.Validate(usuarioInvalido);
            // assert
            resultado.IsValid.Should().BeFalse();
        }

        [Fact]
        public void Validete_deve_retornar_invalido_quando_usuario_nao_tiver_senha()
        {
            //arrange
            var usuarioInvalido = new UsuarioBuilder().SemSenha(string.Empty).ConstruirUser();
            // act
            var resultado = _validador.Validate(usuarioInvalido);
            //asset
            resultado.IsValid.Should().BeFalse();

        }
     
        [Fact]
        public void Validete_deve_retornar_invalido_quando_usuario_nao_tiver_email()
        {
            //arrange
            var usuarioInvalido = new UsuarioBuilder().SemEmail(string.Empty).ConstruirUser();
            // act
            var resultado = _validador.Validate(usuarioInvalido);
            //asset
            resultado.IsValid.Should().BeFalse();

        }
     
        [Fact]
        public void Validete_deve_retornar_invalido_quando_a_senha_nao_tiver_seis_caracteres()
        {
            //arrange
            var usuarioInvalido = new UsuarioBuilder().SemSenha("Li1").ConstruirUser();
            // act
            var resultado = _validador.Validate(usuarioInvalido);
            //asset
            resultado.IsValid.Should().BeFalse();

        }
        [Fact]
        public void Validete_deve_retornar_invalido_quando_a_senha_nao_tiver_leatra_maiuscula()
        {
            //arrange
            var usuarioInvalido = new UsuarioBuilder().SemSenha(string.Empty).ConstruirUser();
            // act
            var resultado = _validador.Validate(usuarioInvalido);
            //asset
            resultado.IsValid.Should().BeFalse();

        }
        [Fact]
        public void Validete_deve_retornar_invalido_quando_a_senha_nao_tiver_leatra_minuscula()
        {
            //arrange
            var usuarioInvalido = new UsuarioBuilder().SemSenha(string.Empty).ConstruirUser();
            // act
            var resultado = _validador.Validate(usuarioInvalido);
            //asset
            resultado.IsValid.Should().BeFalse();

        }
    }
}
