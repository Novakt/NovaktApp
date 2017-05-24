using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace NovaktApp.Interface
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
