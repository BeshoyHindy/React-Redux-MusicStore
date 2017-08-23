using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.AlbumSpecs
{
    public class AlbumPriceIsRequiredSpec : ISpecification<Album>
    {
        public bool IsSatisfiedBy(Album album)
        {
            return album.Price > 0;
        }
    }
}
