using System;
using System.ComponentModel;
using System.Diagnostics;
using OCranes.ViewModels;
using Xamarin.Forms;

namespace OCranes.Views.Cranes
{
    [DesignTimeVisible(false)]
    public partial class CranesPage : ContentPage
    {
        private readonly CranesViewModel viewModel;

        public CranesPage()
        {
            InitializeComponent();
            this.BindingContext = viewModel = new CranesViewModel();
        }

        async void OnItemSelected(object sender, EventArgs args)
        {
            /*
             * var layout = (BindableObject)sender;
             * var item = (Item)layout.BindingContext;
             * await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
             */
            await Device.InvokeOnMainThreadAsync(() =>
            {
                Application.Current.MainPage.DisplayAlert("Alert", "Alert msg", "Ok");
            });
            Debug.WriteLine("Item pressed.");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Cranes.Count == 0)
                viewModel.IsBusy = true;
        }
    }
}
