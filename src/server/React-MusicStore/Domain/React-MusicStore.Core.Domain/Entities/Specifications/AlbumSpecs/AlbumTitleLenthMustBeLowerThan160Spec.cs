using ReactMusicStore.Core.Domain.Interfaces.Specification;

namespace ReactMusicStore.Core.Domain.Entities.Specifications.AlbumSpecs
{
    public class AlbumTitleLenthMustBeLowerThan160Spec : ISpecification<Album>
    {
        public bool IsSatisfiedBy(Album album)
        {
            return album.Title.Trim().Length < 160;
        }
    }
}
