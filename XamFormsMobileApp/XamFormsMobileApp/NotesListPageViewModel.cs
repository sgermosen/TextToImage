using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamFormsMobileApp.Model;
using XamFormsMobileApp.Services;

namespace XamFormsMobileApp
{
    public class NotesListPageViewModel : BaseViewModel
    {
        private ObservableCollection<NotesModel> _notesList;
        public ObservableCollection<NotesModel> NotesList
        {
            get => _notesList;
            set
            {
                _notesList = value;
                RaisePropertyChanged();
            }
        }

        internal void DeleteNotes(NotesModel notesModel)
        {
            NotesList.Remove(notesModel);
            RaisePropertyChanged();
        }

        public void Initilize()
        {
            try
            {
                var list = new NoteService().GetNotes();



                NotesList = new ObservableCollection<NotesModel>(list);
            }
            catch (Exception ex)
            {
                NotesList = new ObservableCollection<NotesModel>();
            }

        }

        internal void Navigate(NotesModel notesModel)
        {
            App.Current.MainPage.Navigation.PushAsync(new NotesDetailPage(notesModel));
        }
    }
}
