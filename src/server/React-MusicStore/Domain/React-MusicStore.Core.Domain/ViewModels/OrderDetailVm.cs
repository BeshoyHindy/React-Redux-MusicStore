using ReactMusicStore.Core.Domain.ViewModels.Foundation;

namespace ReactMusicStore.Core.Domain.ViewModels
{
    public class OrderDetailVm :BaseViewModel
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int AlbumId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}