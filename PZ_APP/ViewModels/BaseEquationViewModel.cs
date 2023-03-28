using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PZ_APP.ViewModels
{
    public class BaseEquationViewModel :ViewModelBase
    {
        private string _selectedItemAccessVectorString;
        private ComboBoxItem _selectedItemAccessVector;


        private string _selectedItemAccessComplexityString;
        private ComboBoxItem _selectedItemAccessComplexity;

        private string _selectedItemAuthenticationString;
        private ComboBoxItem _selectedItemAuthentication;

        private string _selectedItemConfImpactString;
        private ComboBoxItem _selectedItemConfImpact;

        private string _selectedItemIntegImpactString;
        private ComboBoxItem _selectedItemIntegImpact;

        private string _selectedItemAvailImpactString;
        private ComboBoxItem _selectItemAvailImpact;

        private string _errorMessage;

        private float _baseScore;
        private float _impact;
        private float _exploitability;
        private float _fimpact;


        public string AccessVectorValue { get; }
        public string AccessComplexityValue { get; }
        public string AuthenticationValue { get; }
        public string ConfImpactValue { get; }
        public string IntegImpact { get; }
        public string AvailImpact { get; }


        public string BaseScore;
        public string Impact;
        public string Exploitability;
        public string FImpakt;


        public ComboBoxItem SelectedItemAccessVector
        {
            get { return _selectedItemAccessVector; }
            set
            {
                if (_selectedItemAccessVector != value)
                {
                    _selectedItemAccessVector = value;
                    OnPropertyChanged(nameof(SelectedItemAccessVector));
                    _selectedItemAccessVectorString = Convert.ToString(SelectedItemAccessVector.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemAccessComplexity
        {
            get { return _selectedItemAccessComplexity; }
            set
            {
                if (_selectedItemAccessComplexity != value)
                {
                    _selectedItemAccessComplexity = value;
                    OnPropertyChanged(nameof(SelectedItemAccessComplexity));
                    _selectedItemAccessComplexityString = Convert.ToString(SelectedItemAccessComplexity.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemAuthentication
        {
            get { return _selectedItemAuthentication; }
            set
            {
                if (_selectedItemAuthentication != value)
                {
                    _selectedItemAuthentication = value;
                    OnPropertyChanged(nameof(SelectedItemAuthentication));
                    _selectedItemAuthenticationString = Convert.ToString(SelectedItemAuthentication.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemConfImpact
        {
            get { return _selectedItemConfImpact; }
            set
            {
                if (_selectedItemConfImpact != value)
                {
                    _selectedItemConfImpact = value;
                    OnPropertyChanged(nameof(SelectedItemConfImpact));
                    _selectedItemConfImpactString = Convert.ToString(SelectedItemConfImpact.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemIntegImpact
        {
            get { return _selectedItemIntegImpact; }
            set
            {
                if(_selectedItemIntegImpact != value)
                {
                    _selectedItemIntegImpact = value;
                    OnPropertyChanged(nameof(SelectedItemIntegImpact));
                    _selectedItemIntegImpactString = Convert.ToString(SelectedItemIntegImpact.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemAvailImpact
        {
            get { return _selectItemAvailImpact; }
            set
            {
                if(_selectItemAvailImpact !=value)
                {
                    _selectItemAvailImpact = value;
                    OnPropertyChanged(nameof(SelectedItemAvailImpact));
                    _selectedItemAvailImpactString = Convert.ToString(SelectedItemAvailImpact.Content);
                }
            }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }


        public ICommand CalculateCommand { get; }

        public BaseEquationViewModel()
        {
            ErrorMessage = "Brak danych!";
            CalculateCommand = new ViewModelCommand(ExecuteCalculateCommand, CanExecuteCalculateCommand);
        }

        private bool CanExecuteCalculateCommand(object obj)
        {
            if (_selectedItemAccessComplexityString != null && _selectedItemAccessVectorString != null && _selectedItemAuthenticationString != null
                && _selectedItemAvailImpactString != null && _selectedItemConfImpactString != null && _selectedItemIntegImpactString !=null)
            {
                ErrorMessage = "";
                return true;
            }
            return false;
        }

        private void ExecuteCalculateCommand(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
