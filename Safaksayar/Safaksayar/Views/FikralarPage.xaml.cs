using Safaksayar.ViewModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safaksayar.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FikralarPage : ContentPage
    {
        FikralarViewModel _viewModel;
    

        public FikralarPage()
        {
            BindingContext = _viewModel = new FikralarViewModel();

            InitializeComponent();

       

   
        }

        //async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        //{
        //    if (e.Item == null)
        //        return;

        //    await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

        //    //Deselect Item
        //    ((ListView)sender).SelectedItem = null;
        //}
    }
}
