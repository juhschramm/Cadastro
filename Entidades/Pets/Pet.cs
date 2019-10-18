using System;

namespace WebApplication1.Entidades.Pets
{
    public class Pet
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public TipoPet Tipo { get; set; }
        public string Raca { get; set; }
        public int Idade { get; set; }
        public Guid PessoaId { get; set; }
    }
}
