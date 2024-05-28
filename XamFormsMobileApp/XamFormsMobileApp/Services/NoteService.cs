using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XamFormsMobileApp.ISQlite;
using XamFormsMobileApp.Model;

namespace XamFormsMobileApp.Services
{
    public class NoteService
    {
        SQLiteConnection Connection;

        public NoteService()
        {
            Connection = DependencyService.Get<Isqlite>().GetConnection();
            Connection.CreateTable<NotesModel>();
        }

        public bool Add(NotesModel notes)
        {
            int result = Connection.Insert(notes);
            if (result == 1) return true;

            return false;
        }

        public bool Delete(int id)
        {
            int result = Connection.Delete<NotesModel>(id);
            if (result == 1) return true;

            return false;
        }

        public List<NotesModel> GetNotes()
        {
            return Connection.Table<NotesModel>().ToList();
        }
    }
}
