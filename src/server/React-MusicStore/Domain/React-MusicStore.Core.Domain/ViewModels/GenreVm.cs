using ReactMusicStore.Core.Domain.ViewModels.Foundation;

namespace ReactMusicStore.Core.Domain.ViewModels
{
    public class GenreVm :BaseViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}