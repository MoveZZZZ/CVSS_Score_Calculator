using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PZ_APP.ViewModels.V3._1
{
    public class MainWindowViewModelV3: ViewModelBase
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

        public ICommand ShowBaseEquationV3Command { get; }
        public ICommand ShowTemporalEquationV3Command { get; }
        public ICommand ShowEnvironmentalEquationV3Command { get; }
        public ICommand ShowMainMenuV3Command { get; }

        public MainWindowViewModelV3()
        {
            ShowBaseEquationV3Command = new ViewModelCommand(ExecuteShowBaseEquationV3Command);
            ShowTemporalEquationV3Command = new ViewModelCommand(ExecuteShowTemporalEquationV3Command);
            ShowEnvironmentalEquationV3Command = new ViewModelCommand(ExecuteShowEnvironmentalEquationV3Command);
            ShowMainMenuV3Command = new ViewModelCommand(ExecuteShowMainMenuV3);
            ExecuteShowMainMenuV3(null);
        }

        private void ExecuteShowMainMenuV3(object obj)
        {
            CurrentChildView = new MainMenuViewModelV3();
        }

        private void ExecuteShowEnvironmentalEquationV3Command(object obj)
        {
            CurrentChildView = new EnvironmentalEquationViewModelV3();
        }

        private void ExecuteShowTemporalEquationV3Command(object obj)
        {
            CurrentChildView =new TemporalEquationViewModelV3();
        }

        private void ExecuteShowBaseEquationV3Command(object obj)
        {
            CurrentChildView = new BaseEquationViewModelV3();
        }
    }
}
