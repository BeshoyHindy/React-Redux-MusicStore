using ReactMusicStore.Core.Domain.ViewModels.Foundation;

namespace ReactMusicStore.Core.Domain.ViewModels
{
    public class ArtistVm :BaseViewModel
    {
        public int ArtistId { get; set; }
        public string Name { get; set; }
    }
}