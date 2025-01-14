using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zeving.Views;

namespace Zeving
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
           Routing.RegisterRoute(nameof(NewTaskTuteurView),typeof(NewTaskTuteurView));
           Routing.RegisterRoute(nameof(DetailTaskTuteurPage),typeof(DetailTaskTuteurPage));
        }

        private async void OnRun()
        {
                await Shell.Current.GoToAsync("Home");
        }
    }
}