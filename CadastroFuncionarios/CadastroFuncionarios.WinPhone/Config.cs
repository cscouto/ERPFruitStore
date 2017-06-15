using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppLoja.WinPhone.Config))]

namespace AppLoja.WinPhone
{
    class Config : IDataBase
    {
        private string diretorioDB;
        private ISQLitePlatform plataforma;

        public string DiretorioDB
        {
            get
            {
                if (string.IsNullOrEmpty(diretorioDB))
                {
                    diretorioDB = Windows.Storage.ApplicationData.Current.LocalFolder.Path;
                }
                return diretorioDB;
            }

        }

        public ISQLitePlatform Plataforma
        {
            get
            {
                if (plataforma == null)
                {
                    plataforma = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
                }
                return plataforma;
            }
        }
    }
}
