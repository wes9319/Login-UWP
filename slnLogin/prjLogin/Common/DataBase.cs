using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjLogin.Common
{
    public class DataBase
    {
        string path;

        SQLiteConnection conn;

        public void Database(){
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path,
                "MyDatabase.sqlite");
            conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<User>();

        }

        public int Register(User user) {
            int code = -1;
            try
            {
                conn.Insert(new User()
                {
                    UserName = user.UserName,
                    Password = user.Password,
                    Email = user.Email
                });
            }
            catch (SQLiteException ex)
            {
                code = -1;
            }
            return code;
            
        }

        public bool Login(string user, string password) {
            var query = conn.Table<User>().
                Where(t => t.UserName == user && t.Password == password);
            if (query.Count() > 0)
                return true;
            else
                return false;
        }
    }
}
