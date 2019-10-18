using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entidades;

namespace WebApplication1.Repositories.Map
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa")
                .HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Sobrenome)
                .HasMaxLength(50);

            builder.Property(x => x.Rg)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Idade)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
