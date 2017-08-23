using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Services.Interfaces.Common;

namespace ReactMusicStore.Services.Interfaces
{
    public interface IGenreAppService : IAppService<Genre>
    {
        Genre GetWithAlbums(string genreName);
    }
}
