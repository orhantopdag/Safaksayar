using Safaksayar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Safaksayar.Views
{
   // [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BilgiGir : ContentPage
    {
        public BilgiGir()
        {
            InitializeComponent();
            BindingContext =new  BilgiGirViewModel();
            (BindingContext as BilgiGirViewModel).nav = this.Navigation;
        }
    }
}