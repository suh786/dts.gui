using dts.gui.DataGrid;
using dts.gui.Person;

namespace dts.gui
{
    public class MainWindowModel : NotifyingObject
    {
        public MainWindowModel()
        {
            PersonDataGridViewModel = new PersonDataGridViewModel();
        }

        private IDataGridViewModel _personDataGridViewModel;
        public IDataGridViewModel PersonDataGridViewModel
        {
            get { return _personDataGridViewModel; }
            set
            {
                _personDataGridViewModel = value;
                NotifyPropertyChanged("PersonDataGridViewModel");
            }
        }

        public void Init()
        {
            PersonDataGridViewModel.Init();
        }
    }
}
