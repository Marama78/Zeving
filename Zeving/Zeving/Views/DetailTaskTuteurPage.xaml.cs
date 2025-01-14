using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zeving.Models;
using Zeving.ViewModels;

namespace Zeving.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailTaskTuteurPage : ContentPage
    {
        public DetailTaskTuteurPage()
        {
            InitializeComponent();
            BindingContext =  new DetailTaskTuteurViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            IsBusy = true;
        }
    }
}