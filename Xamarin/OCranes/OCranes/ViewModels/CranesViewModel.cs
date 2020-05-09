using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using OCranes.Models;
using OCranes.Services;
using OCranes.Views.Cranes;
using Xamarin.Forms;

namespace OCranes.ViewModels
{
    public class CranesViewModel : BaseViewModel
    {
        private IDataStore<Crane> CraneStore = DependencyService.Get<IDataStore<Crane>>();

        public ObservableCollection<Crane> Cranes { get; set; }
        public Command LoadCranesCommand { get; set; }

        public CranesViewModel()
        {
            this.Title = "Cranes";
            this.Cranes = new ObservableCollection<Crane>();
            this.LoadCranesCommand = new Command(async () => await this.ExecuteLoadCranes());

            MessagingCenter.Subscribe<NewCranePage, Crane>(this, "AddCrane", async (obj, crane) =>
            {
                var newCrane = crane as Crane;
                this.Cranes.Add(newCrane);
                await this.CraneStore.AddItemAsync(newCrane);
            });
        }

        private async Task ExecuteLoadCranes()
        {
            this.IsBusy = true;

            try
            {
                this.Cranes.Clear();
                var cranes = await this.CraneStore.GetItemsAsync(true);
                cranes.ToList().ForEach(elem => this.Cranes.Add(elem));
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                this.IsBusy = false;
            }
        }
    }
}
