using System.Collections.Generic;
using ReactMusicStore.Core.Domain.Entities;

namespace ReactMusicStore.WebApi.ViewModels
{
    public class ShoppingCartViewModel
    {
        public List<Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}