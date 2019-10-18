
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WebApplication1.Entidades;

namespace WebApplication1.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly WebApiContext _context;
        public PessoaRepository(WebApiContext context)
        {
            _context = context;
        }

        public void Create(Pessoa pessoa)
        {
            _context.Pessoa.Add(pessoa);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var pessoa = new Pessoa { Id = id };
            _context.Pessoa.Attach(pessoa);
            _context.Pessoa.Remove(pessoa);
            _context.SaveChanges();
        }

        public IEnumerable<Pessoa> List(Guid id, string nome, string sobreNome, string rg)
        {
            var pessoas = _context.Pessoa.AsQueryable();

            if (id != Guid.Empty && id != null)
                pessoas = pessoas.Where(x => x.Id == id);
            if (string.IsNullOrWhiteSpace(nome) == false)
                pessoas = pessoas.Where(x => x.Nome == nome);
            if (string.IsNullOrWhiteSpace(sobreNome) == false)
                pessoas = pessoas.Where(x => x.Sobrenome == sobreNome);
            if (string.IsNullOrWhiteSpace(rg) == false)
                pessoas = pessoas.Where(x => x.Rg == rg);

            return pessoas.ToList();
        }

        public IEnumerable<Pessoa> List(IQueryable<Pessoa> filtro)
        {
            return filtro.ToList();
        }

        public void Update(Pessoa pessoa)
        {
            _context.Update(pessoa);
            _context.SaveChanges();
        }
    }
}