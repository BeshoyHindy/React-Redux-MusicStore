using System;
using ReactMusicStore.Core.Domain.ViewModels.Foundation;

namespace ReactMusicStore.Core.Domain.ViewModels
{
    public class CartVm :BaseViewModel
    {
        public int RecordId { get; set; }
        public string CartId { get; set; }
        public int AlbumId { get; set; }
        public int Count { get; set; }
        public DateTime DateCreated { get; set; }
    }
}