using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PawConnect.Domain;
using PawConnect.Domain.VolunteerModel;

namespace PawConnect.Infrastructure.ModelsConfigurations;

public class VolunteerConfiguration : IEntityTypeConfiguration<Volunteer>
{
    public void Configure(EntityTypeBuilder<Volunteer> builder)
    {
        builder.ToTable("volunteers");

        builder.HasKey(v => v.Id);

        builder.Property(v => v.FirstName)
            .HasMaxLength(DbConstants.TextLengthShort)
            .IsRequired();

        builder.Property(v => v.LastName)
            .HasMaxLength(DbConstants.TextLengthShort)
            .IsRequired();

        builder.Property(v => v.MiddleName)
            .HasMaxLength(DbConstants.TextLengthShort);

        builder.ComplexProperty(v => v.PhoneNumber, pb =>
        {
            pb.Property(ph => ph.Phone)
                .HasMaxLength(DbConstants.TextLengthShort)
                .IsRequired();
        });

        builder.ComplexProperty(v => v.Email, eb =>
        {
            eb.Property(e => e.Value)
                .HasMaxLength(DbConstants.TextLengthShort)
                .HasColumnName("email")
                .IsRequired();
        });

        builder.HasMany(p => p.Pets)
            .WithOne()
            .OnDelete(DeleteBehavior.NoAction);

        builder.OwnsOne(v => v.Donation, b =>
        {
            b.ToJson("donation");
            b.OwnsMany(d => d.DonationDetails, db =>
            {
                db.ToJson();

                // Explicitly tell EF Core which JSON column to use for this owned collection.
                // Without this, EF throws ArgumentNullException ("key" null) because it cannot
                // resolve the container column for the JSON array (Details inside SocialNetworks).
                db.OwnedEntityType.SetContainerColumnName("donation");

                db.Property(d => d.Title)
                    .HasMaxLength(DbConstants.TextLengthShort)
                    .IsRequired();

                db.Property(d => d.Description)
                    .HasMaxLength(DbConstants.TextLengthMedium)
                    .IsRequired();
            });
        });

        builder.OwnsOne(v => v.SocialNetworks, b =>
        {
            b.ToJson("social_networks");
            b.OwnsMany(d => d.Details, db =>
            {
                db.ToJson();

                // Explicitly tell EF Core which JSON column to use for this owned collection.
                // Without this, EF throws ArgumentNullException ("key" null) because it cannot
                // resolve the container column for the JSON array (Details inside SocialNetworks).
                db.OwnedEntityType.SetContainerColumnName("social_networks");

                db.Property(d => d.Title)
                    .HasMaxLength(DbConstants.TextLengthShort)
                    .IsRequired();

                db.Property(d => d.Url)
                    .HasMaxLength(DbConstants.TextLengthLong)
                    .IsRequired();
            });
        });
    }
}