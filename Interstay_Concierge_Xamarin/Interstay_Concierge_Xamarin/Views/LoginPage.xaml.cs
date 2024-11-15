using Interstay_Concierge_Xamarin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Interstay_Concierge_Xamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();

            hybridWebView.Source = "https://concierge-admin.inter-stay.com/Mobile/test.html";

            hybridWebView.RegisterAction(data => DisplayAlert("Alert", "Hello " + data, "OK"));
        }
    }
}