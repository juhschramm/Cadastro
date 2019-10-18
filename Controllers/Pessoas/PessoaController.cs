using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos.Requests;
using WebApplication1.Dtos.Responses;
using WebApplication1.Entidades;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private IPessoaService _pessoaService;
        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpPost("create")]
        public ActionResult<PessoaResponse> Create([FromBody] PessoaRequest pessoaRequest)
        {
            var pessoa = _pessoaService.Create(pessoaRequest as Pessoa);
            return new PessoaResponse
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Rg = pessoa.Rg,
                Idade = pessoa.Idade,
            };
        }

        [HttpPost("update")]
        public ActionResult<PessoaResponse> Update([FromBody] PessoaRequest pessoaRequest)
        {
            var pessoa = _pessoaService.Update(pessoaRequest as Pessoa);
            return new PessoaResponse
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Rg = pessoa.Rg,
                Idade = pessoa.Idade,
            };
        }

        [HttpPost("updatelist")]
        public ActionResult<IEnumerable<PessoaResponse>> UpdateList([FromBody] IEnumerable<PessoaRequest> pessoasRequest)
        {
            foreach(var pessoaRequest in pessoasRequest)
                 _pessoaService.Update(pessoaRequest as Pessoa);

            return pessoasRequest.Select(pessoa => new PessoaResponse
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome,
                Sobrenome = pessoa.Sobrenome,
                Rg = pessoa.Rg,
                Idade = pessoa.Idade,
            }).ToList();
        }

        [HttpGet("list")]
        public ActionResult<IEnumerable<PessoaResponse>> List(Guid id, string nome, string sobreNome, string rg)
        {
            return _pessoaService.List(id, nome, sobreNome, rg)
                .Select(pessoa => new PessoaResponse
                {
                    Id = pessoa.Id,
                    Nome = pessoa.Nome,
                    Sobrenome = pessoa.Sobrenome,
                    Rg = pessoa.Rg,
                    Idade = pessoa.Idade,
                }).ToList();
        }

        [HttpDelete("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            _pessoaService.Delete(id);
            return Ok();
        }

    }
}
