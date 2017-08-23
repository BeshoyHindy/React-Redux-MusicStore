using System.Data.Entity.ModelConfiguration;
using ReactMusicStore.Core.Domain.Entities;

namespace ReactMusicStore.Core.Data.Context.Mapping
{
    public class ArtistMap : EntityTypeConfiguration<Artist>
    {
        public ArtistMap()
        {
            // Primary Key
            HasKey(t => t.ArtistId);

            // Properties
            Property(t => t.Name)
                .HasMaxLength(50)
                .IsRequired();

            Ignore(t => t.ValidationResult);
        }
    }
}