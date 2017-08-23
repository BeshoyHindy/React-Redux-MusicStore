using System.Collections.Generic;
using ReactMusicStore.Core.Domain.Entities;
using ReactMusicStore.Services.Interfaces.Common;

namespace ReactMusicStore.Services.Interfaces
{
    public interface IAlbumAppService : IAppService<Album>
    {
        IEnumerable<Album> GetTopSellingAlbums(int count);
        
    }
}
