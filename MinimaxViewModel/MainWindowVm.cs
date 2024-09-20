using DataModel.EntityFramework.Contexts;
using System.Collections.ObjectModel;
using System.Linq;
using ViewModelBase;

namespace MinimaxViewModel
{
    public class MainWindowVm : ViewModel
    {
        private readonly DataContext _model;
        public ObservableCollection<int> Cities { get; set; } 
        public MainWindowVm(DataContext model)
        {
            _model = model;
            Cities = new(model.Cities.Select(c => c.Id));
        }       
        
    }
}
