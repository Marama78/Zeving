using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Xamarin.Forms;
using Zeving.Views;
using static System.Net.WebRequestMethods;

namespace Zeving.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
       

        public HomeViewModel()
        {
            Title = "Vanille de Tahiti";
            ImageUrl = "https://drive.google.com/uc?export=download&id=1Zv6bnrpsC0cXVOgEbBUgNITkhJ74Ok4v";
        }

        private string imageUrl;
        public string ImageUrl
        {
            get { return imageUrl; }
            set { SetProperty(ref imageUrl, value); }
        }
    }
}
