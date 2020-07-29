using CodenationCadastroLogErro.Dominio.Repository;
using CodenationCadastroLogErro.Recursos;
using System.Collections.Generic;
using System.Linq;

namespace CodenationCadastroLogErro.Dados.Repository
{
    public class RepositorioBase<T> : IRepositorioBase<T> where T : class, IEntity
    {
        protected readonly CodenationContext _contexto;
        public RepositorioBase(CodenationContext contexto)
        {
            _contexto = contexto;
           
        }

        public virtual string Cadastrar(T entity)
        {
            _contexto.Set<T>().Add(entity);
            _contexto.SaveChanges();
            return MensagensErro.Ok;
        }
        public string Alterar(T entity)
        {
            _contexto.Set<T>().Update(entity);
            _contexto.SaveChanges();
            return MensagensErro.Alterar;
        }
        public T SelecionarPorId(int id)
        {
            return _contexto.Set<T>().FirstOrDefault(x => x.Id == id);
        }
        public string Excluir(int id)
        {
            var entity = SelecionarPorId(id);
            _contexto.Set<T>().Remove(entity);
            _contexto.SaveChanges();
            return MensagensErro.Excluido;

        }
        public List<T> SelicionarTodos()
        {
            return _contexto.Set<T>().ToList();
        }
        public void Dispose()
        {
            _contexto.Dispose();
        }
    }

}