using System.Collections.Generic;
using System;

namespace CodenationCadastroLogErro.Dominio.Repository
{
    public interface IRepositorioBase<T> : IDisposable where T : class, IEntity
    {
        string Alterar(T entity);
        string Incluir(T entity);
        T SelecionarPorId(int id);
        string Excluir(int id);
        List<T> SelicionarTodos();
    }
}