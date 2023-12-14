using MSandovalMobile.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace MSandovalMobile.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}