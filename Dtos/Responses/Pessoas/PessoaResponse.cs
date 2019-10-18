using WebApplication1.Entidades;

namespace WebApplication1.Dtos.Responses
{
    public class PessoaResponse : Pessoa
    {
        public string NomeESobrenome => $"{Nome} {Sobrenome}";
    }
}
