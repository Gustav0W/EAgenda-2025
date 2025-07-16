using EAgenda.Dominio.ModuloCompromisso;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EAgenda.Infraestrutura.Orm.ModuloCompromisso;

public class MapeadorCompromissoEmOrm : IEntityTypeConfiguration<Compromisso>
{
    public void Configure(EntityTypeBuilder<Compromisso> builder)
    {
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Assunto)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.DataDeOcorrencia)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.HoraDeInicio)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.HoraDeTermino)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.TipoCompromisso)
            .ValueGeneratedNever()
            .IsRequired();

        builder.Property(x => x.Local)
            .IsRequired(false);

        builder.Property(x => x.Link)
            .IsRequired(false);

        builder.HasOne(x => x.Contato)
            .WithMany();
    }
}

