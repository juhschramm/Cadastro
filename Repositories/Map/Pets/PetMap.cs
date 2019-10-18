using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Entidades.Pets;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication1.Entidades;

namespace WebApplication1.Repositories.Map
{
    public class PetMap : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.ToTable("Pet")
                .HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Raca)
                .HasMaxLength(50);

            builder.Property(x => x.Tipo)
                .HasMaxLength(50)
                .IsRequired();
                //.HasConvertion();

            builder.Property(x => x.Idade)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}

