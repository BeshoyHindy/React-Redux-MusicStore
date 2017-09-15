using System.Data.Entity.ModelConfiguration;
using ReactMusicStore.Core.Domain.Entities;

namespace ReactMusicStore.Core.Data.Context.Mapping
{
    public class CartMap : EntityTypeConfiguration<Cart>
    {
        public CartMap()
        {
            // Primary Key
            HasKey(t => t.RecordId);

            // Properties
            Property(t => t.Id)
                .IsRequired();

            Property(t => t.AlbumId)
                .IsRequired();

            Property(t => t.Count)
                .IsRequired();

            Property(t => t.DateCreated)
                .IsRequired();

            Ignore(t => t.ValidationResult);
        }
    }
}