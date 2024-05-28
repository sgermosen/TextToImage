using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using XamFormsMobileApp.Model;

namespace XamFormsMobileApp
{
    public class NotesDetailPageViewModel : BaseViewModel
    {
        public RelayCommand NavigateCommand => new RelayCommand(NavigateClick);

        private void NavigateClick()
        {
            App.Current.MainPage.Navigation.PushAsync(new TextToImagePage(new NotesModel() { Notes=Notes,TextColor=SelectedTextColor}));
        }

        public void Initilize(NotesModel model)
        {
            Notes = model.Notes;
            SelectedTextColor = model.TextColor;

            //ColorNames.Clear();

            //foreach (var field in typeof(Xamarin.Forms.Color).GetFields(BindingFlags.Static | BindingFlags.Public))
            //{
            //    if (field != null && !String.IsNullOrEmpty(field.Name))
            //        ColorNames.Add(field.Name);
            //}

            //SelectedTextColor = "Black";
        }
    }
}
