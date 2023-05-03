using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using locadoraDeCarros.Models;

namespace locadoraDeCarros.Data.Mappings
{
    public class MarcaMap : IEntityTypeConfiguration<MarcaModel>
    {
        public void Configure(EntityTypeBuilder<MarcaModel> builder)
        {
            builder.ToTable("Marcas");
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

            builder.Property(m => m.Nome)
            .IsRequired() //NOT NULL
            .HasColumnType("VARCHAR").HasMaxLength(80);

            //relação de muitos carros para uma marca
            builder.HasMany(x => x.Carros)
            .WithOne(x => x.Marca)
            .HasConstraintName("fk_marcas_carro")
            .OnDelete(DeleteBehavior.Cascade);
        }
    
    }
}