using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MSandovalMobile.Models;
using MSandovalMobile.Services;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSandovalMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaAlumno : ContentPage
    {
        ServicioBaseDatos<Alumno> bd;

        public PaginaAlumno(Alumno alumno)
        {
            InitializeComponent();
            this.BindingContext = alumno;
            bd = new ServicioBaseDatos<Alumno>();
            if (alumno.Id == 0)
                this.ToolbarItems.RemoveAt(1);
        }
        void Loading(bool mostrar)
        {
            indicator.IsEnabled = mostrar;
            indicator.IsRunning = mostrar;
        }
        async void btnRegistrar_Clicked(object sender,EventArgs e)
        {
            Loading(true);
            var alumno=(Alumno)this.BindingContext;
            if (alumno.Id > 0)
                await bd.Update(alumno);
            else
                await bd.Add(alumno);
            Loading(false);
            await DisplayAlert("Correcto", "Registro realizado correctamente", "OK");
            await Navigation.PopAsync();
        }
        async void btnEliminar_Clicked(object sender,EventArgs e)
        {
            Loading(true);
            await bd.Delete(((Alumno)this.BindingContext).Id);
            Loading(false);
            await DisplayAlert("Correcto", "Registro eliminado correctamente", "OK");
            await Navigation.PopAsync();
        }
    }
}