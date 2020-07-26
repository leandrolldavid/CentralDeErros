﻿using CodenationCadastroLogErro.Dominio.Repository;
using CodenationCadastroLogErro.Servico.Validador;
using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Recursos;
using System;

namespace CodenationCadastroLogErro.Dados.Repository
{
    public class TipoLogRepository : RepositorioBase<TipoLog>, ITipoLogRepository
    {
        private readonly ValidadorTipoLogs _validador;
        public TipoLogRepository(CodenationContext contexto)
            : base(contexto)
        {
            _validador = new ValidadorTipoLogs();
        }
        public string Cadastrar(TipoLog tipoLog)
        {
            var validarResultado = _validador.Validate(tipoLog);
            if (!validarResultado.IsValid.Equals(true)) throw new Exception(validarResultado.ToString());
            _contexto.TipoLogs.Add(tipoLog);
            _contexto.SaveChanges();
            return string.Format("O '{0} foi {1}'", tipoLog.Level, MensagensErro.Ok);
        }
    }
}
