using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net.Interop;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppLoja.iOS.Config))]

namespace AppLoja.iOS
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
                    var caminho = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    diretorioDB = System.IO.Path.Combine(caminho, "..", "Library");
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
                    plataforma = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
                }
                return plataforma;
            }
        }
    }
}
