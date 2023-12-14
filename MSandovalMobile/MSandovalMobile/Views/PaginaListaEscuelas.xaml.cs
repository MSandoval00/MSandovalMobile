using MSandovalMobile.Models;
using MSandovalMobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSandovalMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaListaEscuelas : ContentPage
    {
        public PaginaListaEscuelas()
        {
            InitializeComponent();
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            Loading(true);
            var bd = new ServicioBaseDatos<Escuela>();
            lsvEscuelas.ItemsSource = await bd.GetAll();
            Loading(false);
        }
        void Loading(bool mostrar)
        {
            indicator.IsEnabled = mostrar;
            indicator.IsRunning = mostrar;
        }
        private async void lsvEscuelas_ItemSelected(object sender,SelectedItemChangedEventArgs e)
        {
            try
            {
                var dato = (Escuela)e.SelectedItem;
                await Navigation.PushAsync(new PaginaEscuela(dato));
                lsvEscuelas.SelectedItem = null;
            }
            catch (Exception ex)
            {

            }
        }
        public async void btnAgregar_Clicked(object sender,EventArgs e)
        {
            await Navigation.PushAsync(new PaginaEscuela(new Escuela()));
        }
    }
}