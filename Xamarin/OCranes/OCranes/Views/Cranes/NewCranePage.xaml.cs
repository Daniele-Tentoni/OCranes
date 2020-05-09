using System.ComponentModel;
using OCranes.ViewModels;
using Xamarin.Forms;

namespace OCranes.Views.Cranes
{
    [DesignTimeVisible(false)]
    public partial class NewCranePage : ContentPage
    {
        NewCraneViewModel viewModel;

        public NewCranePage()
        {
            InitializeComponent();

            this.BindingContext = viewModel = new NewCraneViewModel();
        }
    }
}
