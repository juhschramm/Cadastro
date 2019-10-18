using System;
using System.Collections.Generic;
using WebApplication1.Entidades;

namespace WebApplication1.Repositories
{
    public interface IPessoaRepository
    {
        void Create(Pessoa pessoa);
        void Delete(Guid id);
        IEnumerable<Pessoa> List(Guid id, string nome, string sobreNome, string rg);
        void Update(Pessoa pessoa);
    }
}
