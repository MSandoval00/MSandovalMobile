using MSandovalMobile.DL;
using MSandovalMobile.Services;
using MSandovalMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MSandovalMobile.DL;
using MSandovalMobile.Helpers;

namespace MSandovalMobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
            MainPage = new NavigationPage(new Views.PaginaListaEscuelas());
        }
        static Conexion bd;
        public static Conexion BD
        {
            get
            {
                if (bd==null)
                {
                    bd = new Conexion(Constantes.NombreBD);
                }
                return bd;
            }
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
