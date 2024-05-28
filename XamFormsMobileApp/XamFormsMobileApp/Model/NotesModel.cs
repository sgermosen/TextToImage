using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamFormsMobileApp.Model
{
   public class NotesModel
    {
        [AutoIncrement,PrimaryKey]
        public int Id { get; set; }
        public string Notes { get; set; }

        public string TextColor { get; set; }

    }
}
