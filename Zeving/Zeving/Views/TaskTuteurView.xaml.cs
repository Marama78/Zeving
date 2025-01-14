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
    public partial class TaskTuteurView : ContentPage
    {
        TaskTuteurViewModel ttvm;
        public TaskTuteurView()
        {
            InitializeComponent();

            BindingContext = ttvm = new TaskTuteurViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ttvm.OnAppearing();

        }
    }
}