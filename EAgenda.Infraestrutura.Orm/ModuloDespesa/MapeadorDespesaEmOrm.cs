using EAgenda.Dominio.ModuloDespesa;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAgenda.Infraestrutura.Orm.ModuloDespesa;

public class MapeadorDespesaEmOrm : IEntityTypeConfiguration<Despesa>
{
    public void Configure(EntityTypeBuilder<Despesa> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Descricao)
            .IsRequired();

        builder.Property(x => x.DataOcorrencia)
            .IsRequired();

        builder.Property(x => x.FormaPagamento)
            .IsRequired();

        builder.HasMany(x => x.Categorias)
            .WithMany(c => c.Despesas);
    }
}

