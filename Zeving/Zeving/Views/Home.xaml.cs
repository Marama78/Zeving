using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zeving.ViewModels;

namespace Zeving.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        HomeViewModel Hvm;
        public Home()
        {
            InitializeComponent();
            //-- Attacher le viewModel du contexte --
            BindingContext = Hvm =new HomeViewModel();


          
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}