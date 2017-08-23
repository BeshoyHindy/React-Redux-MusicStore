using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Core.Domain.Interfaces.Service.Common;

namespace ReactMusicStore.Core.Domain.Interfaces.Service
{
    public interface IGenreService : IService<Genre>
    {
        Genre GetWithAlbums(string genre);
    }
}