using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamFormsMobileApp.Interface;
using XamFormsMobileApp.Model;

namespace XamFormsMobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotesListPage : ContentPage
    {
        public static bool ShouldShowAdd = true;

             
        NotesListPageViewModel viewModel;
        public NotesListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new NotesListPageViewModel();
            viewModel.Initilize();
            ShouldShowAdd = true;



            //   BannerView.AdUnitId = Ads.AdConstant.UnitId;
        }

        protected async  override void OnAppearing()
        {
            base.OnAppearing();
            while (true)
            {
                if (ShouldShowAdd)
                {
                    DependencyService.Get<IAdInterstitial>().ShowAd();
                    await Task.Delay(100);

                }
                else
                {
                    break;
                }

            };
        }


        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (sender is Label label)
            {
                if (label.BindingContext is NotesModel notesModel)
                {
                    // viewModel.DeleteNotes(notesModel);
                    viewModel.Navigate(notesModel);

                }
            }

            if (sender is StackLayout stackLayout)
            {
                if (stackLayout.BindingContext is NotesModel notesModel)
                {
                    // viewModel.DeleteNotes(notesModel);
                    viewModel.Navigate(notesModel);

                }
            }
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var listView = (ListView)sender;
            if (listView.SelectedItem == null) return;

            if (listView.SelectedItem is NotesModel notesModel)
            {
                // viewModel.DeleteNotes(notesModel);
                viewModel.Navigate(notesModel);

            }

            listView.SelectedItem = null;
        }
    }
}