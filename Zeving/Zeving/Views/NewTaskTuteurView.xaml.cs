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
    public partial class NewTaskTuteurView : ContentPage
    {
        readonly NewTaskTuteurViewModel viewModel;
        public NewTaskTuteurView()
        {
            InitializeComponent();
            BindingContext =viewModel = new NewTaskTuteurViewModel();
        }

        private void PickerSiteGetSelectedItem(object sender, EventArgs e)
        {
            int value = pickerSite.SelectedIndex;
            viewModel.UpdateNameSite(ref value);
        }

        private void PickerLineGetSelectedItem(object sender, EventArgs e)
        {
            int value = pickerLine.SelectedIndex;
            viewModel.UpdateLineLocation(ref value);
        }

        private void PickerColumnGetSelectedItem(object sender, EventArgs e)
        {
            int value = pickerColumn.SelectedIndex;
            viewModel.UpdateColumnLocation(ref value);
        }
    }
}