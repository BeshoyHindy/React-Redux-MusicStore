using ReactMusicStore.Core.Domain.ViewModels.Foundation;

namespace ReactMusicStore.Core.Domain.ViewModels
{
    public class AlbumVm : BaseViewModel
    {
        public int AlbumId { get; set; }
        public int GenreId { get; set; }
        public int ArtistId { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string AlbumArtUrl { get; set; }
    }
}