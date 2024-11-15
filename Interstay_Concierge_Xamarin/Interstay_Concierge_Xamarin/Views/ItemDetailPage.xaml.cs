using Interstay_Concierge_Xamarin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Interstay_Concierge_Xamarin.Views
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