using CodenationCadastroLogErro.Dominio.Dtos;
using CodenationCadastroLogErro.Dominio.Moldels;
using CodenationCadastroLogErro.Dominio.Repository;
using CodenationCadastroLogErro.Recursos;
using System.Collections.Generic;
using System.Linq;

namespace CodenationCadastroLogErro.Dados.Repository
{
    public class LogsRepository : RepositorioBase<Logs>, ILogsRepository
    {
        public LogsRepository(CodenationContext contexto)
            : base(contexto)
        {
        }

        public string Arquivar(LogDto log)
        {
            var entity = _contexto.Logs.FirstOrDefault(x => x.Id == log.Id);
            entity.Arquivar = true;
            _contexto.Logs.Update(entity);
            _contexto.SaveChanges();
            return MensagensErro.Arquivar;
        }
        public List<LogQuery> SelecionarLog(int id)
        {
            var data = (from log in _contexto.Logs
                        join user in _contexto.Users on log.UserId equals user.Id
                        join setor in _contexto.Setors on user.SetorId equals setor.Id
                        join tipolog in _contexto.TipoLogs on log.TipoLogId equals tipolog.Id
                        let count = _contexto.Logs.Where(x => x.Origim.Equals(log.Origim)).Count()
                        where log.Id == id
                        select new LogQuery
                        {
                            Titulo = log.Titulo,
                            Evento = count,
                            Level = tipolog.Level,
                            Origim = log.Origim,
                            CreatedAt = log.CreatedAt,
                            Usuario = user.Username,
                            Setor = setor.Nome,
                        });
            return data.ToList();
        }
        public List<LogQuery> Listar()
        {
            var data = (from log in _contexto.Logs
                        join tipolog in _contexto.TipoLogs on log.TipoLogId equals tipolog.Id
                        let count = _contexto.Logs.Where(x => x.Origim.Equals(log.Origim)).Count()
                        where log.Arquivar == false
                        select new LogQuery
                        {
                            Id = log.Id,
                            Origim = log.Origim,
                            CreatedAt = log.CreatedAt,
                            Level = tipolog.Level,
                            Evento = count,
                            Descricao = log.Descricao,
                        });
            return data.ToList();
        }
        public List<LogQuery> OrdernaPorLevel()
        {
            var data = (from log in _contexto.Logs
                        join tipolog in _contexto.TipoLogs on log.TipoLogId equals tipolog.Id
                        let count = _contexto.Logs.Where(x => x.Origim.Equals(log.Origim)).Count()
                        where log.Arquivar == false
                        select new LogQuery
                        {
                            Id = log.Id,
                            Origim = log.Origim,
                            CreatedAt = log.CreatedAt,
                            Level = tipolog.Level,
                            Evento = count,//log.Evento,
                            Descricao = log.Descricao,
                        });
            return data.OrderBy(x => x.Level).ToList();
        }
        public List<LogQuery> OrdernaPorFrequencia()
        {
            var data = (from log in _contexto.Logs
                        join tipolog in _contexto.TipoLogs on log.TipoLogId equals tipolog.Id
                        let count = _contexto.Logs.Where(x => x.Origim.Equals(log.Origim)).Count()
                        where log.Arquivar == false
                        select new LogQuery
                        {
                            Id = log.Id,
                            Origim = log.Origim,
                            CreatedAt = log.CreatedAt,
                            Level = tipolog.Level,
                            Evento = count,
                            Descricao = log.Descricao,
                        });
            return data.OrderBy(x => x.Origim).ToList();
        }
        public List<LogQuery> SelecionarPorSetor(int id)
        {
            var data = (from log in _contexto.Logs
                        join use in _contexto.Users on log.UserId equals use.Id
                        join setor in _contexto.Setors on use.SetorId equals setor.Id
                        join tipolog in _contexto.TipoLogs on log.TipoLogId equals tipolog.Id
                        let count = _contexto.Logs.Where(x => x.Origim.Equals(log.Origim)).Count()
                        where log.Arquivar == false && setor.Id == id
                        select new LogQuery
                        {
                            Id = log.Id,
                            Origim = log.Origim,
                            CreatedAt = log.CreatedAt,
                            Level = tipolog.Level,
                            Evento = count,
                            Descricao = log.Descricao,
                            Setor = setor.Nome,
                        });
            return data.ToList();
        }
    }
}
/*
 Select
                              Origim,
                              created_at,
                              t.level,
                              u.name,
                               (Select count(origim)
                              from logs 
                              where origim = log.origim) Evento,
                              descricao
                       from logs log
                       join Tipolog t on log.TipoLogId = t.Id
                       join Usuario u on log.userId = u.id
                       where log.Arquivar = 0
                       order by log.origim

    */
