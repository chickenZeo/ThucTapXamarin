using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ThucTapXamarin.Presistence
{
    public interface ISQLiteDb
    {
        SQLiteAsyncConnection GetConnection();
    }
}
