using System;

using Safaksayar.Models;

namespace Safaksayar.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Bilgiler Item { get; set; }
        public ItemDetailViewModel(Bilgiler item = null)
        {
            Title = item?.Ad;
            Item = item;
        }
    }
}
