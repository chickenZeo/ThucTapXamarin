using SQLite;
using System;
using System.IO;
using ThucTapXamarin.Droid;
using ThucTapXamarin.Presistence;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDb))]

namespace ThucTapXamarin.Droid
{
    public class SQLiteDb : ISQLiteDb
    {
        public SQLiteAsyncConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "MySQLite1.db3");

            return new SQLiteAsyncConnection(path);

        }
    }
}