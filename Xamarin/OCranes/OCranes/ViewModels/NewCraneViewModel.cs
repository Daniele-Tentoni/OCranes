using System;
using System.Threading.Tasks;
using OCranes.Models;
using Xamarin.Forms;

namespace OCranes.ViewModels
{
    public class NewCraneViewModel: BaseViewModel
    {
        public Crane Item { get; set; }

        public Command CancelCommand { get; set; }

        public Command SaveCommand { get; set; }

        public NewCraneViewModel()
        {
            this.Title = "New Crane";

            this.Item = new Crane("Crane name", 10);
            this.CancelCommand = new Command(async () => await this.ExecuteCancelCommand());
            this.SaveCommand = new Command(async () => await this.ExecuteSaveCommand());
        }

        private async Task ExecuteCancelCommand()
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private async Task ExecuteSaveCommand()
        {
            MessagingCenter.Send(this, "AddCrane", Item);
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
