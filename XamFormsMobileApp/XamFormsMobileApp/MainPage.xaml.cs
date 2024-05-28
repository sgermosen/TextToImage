using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamFormsMobileApp.Interface;

namespace XamFormsMobileApp
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new MainPageViewModel();
            viewModel.Initilize();
            //////
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IAdInterstitial>().ShowAd();

        }
    }
}
