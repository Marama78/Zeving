using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zeving.ViewModels;

namespace Zeving.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SerrePlanificatorPage : ContentPage
	{

		SerrePlanificatorViewModel viewModel;
		public SerrePlanificatorPage ()
		{
			InitializeComponent ();
			BindingContext = viewModel = new SerrePlanificatorViewModel();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();
			viewModel.OnAppearing();
        }
    }
}