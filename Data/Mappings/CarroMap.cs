using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using locadoraDeCarros.Models;

namespace locadoraDeCarros.Data.Mappings
{
    public class CarroMap : IEntityTypeConfiguration<CarroModel>
    {
        public void Configure(EntityTypeBuilder<CarroModel> builder)
        {
            builder.ToTable("Carros");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
            .ValueGeneratedOnAdd()
            .UseIdentityColumn();

            builder.Property(c => c.Nome)
            .IsRequired() //NOT NULL
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

            builder.Property(e => e.DataLocacao)
            .HasColumnType("DATETIME");

            //relação de uma marca para muitos carros
            builder.HasOne(m => m.Marca)
            .WithMany(x => x.Carros)
            .HasForeignKey(x => x.MarcaId)
            .HasConstraintName("fk_carro_marcas")
            .OnDelete(DeleteBehavior.NoAction);
        }
    
    }
}