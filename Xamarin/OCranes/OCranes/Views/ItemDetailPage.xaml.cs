using System.ComponentModel;
using Xamarin.Forms;
using OCranes.ViewModels;

namespace OCranes.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemDetailPage : ContentPage
    {
        readonly CranesViewModel viewModel;

        public ItemDetailPage(CranesViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            viewModel = new CranesViewModel();
            BindingContext = viewModel;
        }
    }
}