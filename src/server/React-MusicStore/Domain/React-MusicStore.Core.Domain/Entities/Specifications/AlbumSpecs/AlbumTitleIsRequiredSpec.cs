using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.AlbumSpecs
{
    public class AlbumTitleIsRequiredSpec : ISpecification<Album>
    {
        public bool IsSatisfiedBy(Album album)
        {
            return album.Title.Trim().Length > 0;
        }
    }
}
