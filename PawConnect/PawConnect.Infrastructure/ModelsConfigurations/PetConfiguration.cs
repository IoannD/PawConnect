using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawConnect.Domain;
using PawConnect.Domain.PetModel;

namespace PawConnect.Infrastructure.ModelsConfigurations;

public class PetConfiguration : IEntityTypeConfiguration<Pet>
{
    public void Configure(EntityTypeBuilder<Pet> builder)
    {
        builder.ToTable("pets");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Name)
            .HasMaxLength(DbConstants.TextLengthShort)
            .IsRequired();

        builder.Property(p => p.Description)
            .HasMaxLength(DbConstants.TextLengthMedium)
            .IsRequired();

        builder.ComplexProperty(p => p.Species, sb =>
        {
            sb.Property(s => s.SpeciesId).IsRequired();
        });

        builder.ComplexProperty(p => p.Breed, bb =>
        {
            bb.Property(b => b.BreedId).IsRequired();
        });

        builder.Property(p => p.Color)
            .HasMaxLength(DbConstants.TextLengthShort);

        builder.ComplexProperty(p => p.Location, lb =>
        {
            lb.Property(l => l.PostalCode)
                .HasMaxLength(DbConstants.TextLengthShort)
                .IsRequired();

            lb.Property(l => l.Country)
                .HasMaxLength(DbConstants.TextLengthShort)
                .IsRequired();

            lb.Property(l => l.City)
                .HasMaxLength(DbConstants.TextLengthShort);

            lb.Property(l => l.Street)
                .HasMaxLength(DbConstants.TextLengthShort)
                .IsRequired();

            lb.Property(l => l.BuildingNumber)
                .HasMaxLength(DbConstants.TextLengthShort);
        });

        builder.Property(p => p.HealthInfo)
            .HasMaxLength(DbConstants.TextLengthMedium);

        builder.ComplexProperty(p => p.ContactNumber, pb =>
        {
            pb.Property(ph => ph.Phone)
                .HasMaxLength(DbConstants.TextLengthShort)
                .IsRequired();
        });

        builder.OwnsOne(p => p.Donation, b =>
        {
            b.ToJson("donation");
            b.OwnsMany(d => d.DonationDetails, db =>
            {
                db.ToJson();

                db.Property(d => d.Title)
                    .HasMaxLength(DbConstants.TextLengthShort)
                    .IsRequired();

                db.Property(d => d.Description)
                    .HasMaxLength(DbConstants.TextLengthMedium)
                    .IsRequired();
            });
        });
    }
}