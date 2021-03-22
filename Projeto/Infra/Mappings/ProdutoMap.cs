using Domain.Entitys;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Mappings
{
    [DbContext(typeof(TestContext))]
    public class ProdutoMap
    {
        public ProdutoMap(EntityTypeBuilder<ProdutoEntity> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Nome)
                   .HasColumnName("Nome")
                    .HasColumnType("varchar(100)")
                    .IsRequired();

            builder.Property(t => t.Valor)
                    .HasColumnName("Valor")
                    .IsRequired();

            builder.Property(t => t.Imagem)
                   .HasColumnName("Imagem")
                   .HasColumnType("varchar(MAX)")
                   .IsRequired();
        }
    }
}

