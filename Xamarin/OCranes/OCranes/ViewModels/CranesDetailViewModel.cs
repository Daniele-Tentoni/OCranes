using OCranes.Models;

namespace OCranes.ViewModels
{
    public class CranesDetailViewModel: BaseViewModel
    {
        public Crane Crane { get; set; }

        public CranesDetailViewModel(Crane crane = null)
        {
            this.Title = crane?.Name;
            this.Crane = crane;
        }
    }
}
