using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamFormsMobileApp.ISQlite
{
    public interface Isqlite { 
        SQLiteConnection GetConnection();
    }
}
