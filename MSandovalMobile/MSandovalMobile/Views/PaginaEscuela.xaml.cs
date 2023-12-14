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
    public partial class PaginaEscuela : ContentPage
    {
        ServicioBaseDatos<Escuela> bd;
        public PaginaEscuela(Escuela escuela)
        {
            InitializeComponent();
            this.BindingContext = escuela;
            bd = new ServicioBaseDatos<Escuela>();
            if (escuela.Id==0)
            {
                this.ToolbarItems.RemoveAt(2);
                this.ToolbarItems.RemoveAt(1);
            }

        }
        void Loading(bool mostrar)
        {
            indicator.IsEnabled = mostrar;
            indicator.IsRunning = mostrar;
        }
        async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Loading(true);
            var escuela = (Escuela)this.BindingContext;
            if (escuela.Id > 0)
            {
                await bd.Update(escuela);
            }
            else
                await bd.Add(escuela);
            Loading(false);
            await DisplayAlert("Correcto", "Registro realizado correctamente", "OK");
            await Navigation.PopAsync();
        }
        async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Advertencia", "Estas seguro de eliminar este registro?", "Si", "No"))
            {
                Loading(true);
                await bd.Delete(((Escuela)this.BindingContext).Id);
                Loading(false);
                await DisplayAlert("Correcto", "Registro eliminado correctamente", "OK");
                await Navigation.PopAsync();
            }
        }
        
        async void btnAlumnos_Clicked(object sender, EventArgs e)
        {
            var escuela = (Escuela)this.BindingContext;
            await Navigation.PushAsync(new PaginaListaAlumnos(escuela));
        }
    }
}