using Xamarin.Forms;
using OCranes.Services;
using System.Diagnostics;
using Google.Cloud.Firestore;

namespace OCranes
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<CranesDataStore>();

            FirestoreDB

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            Debug.WriteLine("[APPLICATION] On Start!");
        }

        protected override void OnSleep()
        {
            Debug.WriteLine("[APPLICATION] On Start!");
        }

        protected override void OnResume()
        {
            Debug.WriteLine("[APPLICATION] On Start!");
        }
    }
}
