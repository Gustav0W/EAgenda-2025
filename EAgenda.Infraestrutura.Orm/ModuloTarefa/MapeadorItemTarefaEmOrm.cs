﻿using EAgenda.Dominio.ModuloTarefa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.Infraestrutura.Orm.ModuloTarefa;
public class MapeadorItemTarefaEmOrm : IEntityTypeConfiguration<ItemTarefa>
{
    public void Configure(EntityTypeBuilder<ItemTarefa> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Titulo)
            .IsRequired();

        builder.Property(x => x.Concluido)
            .IsRequired();

        builder.HasOne(x => x.Tarefa)
            .WithMany(t => t.Itens);
    }
}
