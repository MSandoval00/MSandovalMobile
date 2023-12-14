using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;
using Xamarin.Forms;
using MSandovalMobile.DL;
using MSandovalMobile.Droid.DL;
using MSandovalMobile.Helpers;


[assembly:Dependency(typeof(BaseDatosAndroid))]
namespace MSandovalMobile.Droid.DL
{
    public class BaseDatosAndroid : IConexion
    {
        public string GetDatabasePath()
        {
            return Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), Constantes.NombreBD);
        }
    }
}