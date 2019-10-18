using System;

namespace WebApplication1.Entidades
{
    public class Pessoa
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Rg { get; set; }
        public int Idade { get; set; }
    }
}
