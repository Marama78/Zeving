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
        DetailTaskTuteurViewModel viewModel;
        public DetailTaskTuteurPage()
        {
            InitializeComponent();
            BindingContext =  viewModel =new DetailTaskTuteurViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            IsBusy = true;
        }

        private void Switch_Toggled(object sender, ToggledEventArgs e)
        {
            viewModel.SetVisibilityCheckBoxes();
        }

    }
}