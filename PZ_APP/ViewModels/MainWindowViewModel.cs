using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PZ_APP.ViewModels
{
    public class MainWindowViewModel: ViewModelBase
    {
        private ViewModelBase _currenChildView;

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currenChildView;
            }
            set
            {
                _currenChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }

        public ICommand ShowBaseEquationCommand { get; }
        public ICommand ShowTemporalEquationCommand { get; }
        public ICommand ShowEnvironmentalEquationCommand { get; }
        public ICommand ShowMainMenuCommand { get; }

        public MainWindowViewModel()
        {
            ShowBaseEquationCommand = new ViewModelCommand(ExecuteShowBaseEquationCommand);
            ShowTemporalEquationCommand = new ViewModelCommand(ExecuteShowTemporalEquationCommand);
            ShowEnvironmentalEquationCommand = new ViewModelCommand(ExecuteShowEnvironmentalEquationCommand);
            ShowMainMenuCommand = new ViewModelCommand(ExecuteShowMainMenu);
            ExecuteShowMainMenu(null);

        }
        private void ExecuteShowMainMenu(object obj)
        {
            CurrentChildView = new MainMenuViewModel();
        }

        private void ExecuteShowEnvironmentalEquationCommand(object obj)
        {
            CurrentChildView = new EnvironmentalEquationViewModel();
        }

        private void ExecuteShowTemporalEquationCommand(object obj)
        {
            CurrentChildView = new TemporalEquationViewModel();
        }

        private void ExecuteShowBaseEquationCommand(object obj)
        {
            CurrentChildView = new BaseEquationViewModel();
        }

    }
}
