using PZ_APP.Models;
using PZ_APP.Repositories;
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

        private string _baseScoreString;
        private string _impactString;
        private string _exploitabilityString;
        private string _fimpactString;


        public string AccessVectorValue 
        {
            get { return _selectedItemAccessVectorString; }
            set
            {
                _selectedItemAccessVectorString = value;
                OnPropertyChanged(nameof(AccessVectorValue));
            }
        }
        public string AccessComplexityValue 
        { 
            get { return _selectedItemAccessComplexityString; }
            set
            {
                _selectedItemAccessComplexityString = value;
                OnPropertyChanged(nameof(AccessComplexityValue));
            }
        }
        public string AuthenticationValue 
        { 
            get { return _selectedItemAuthenticationString; }
            set
            {
                _selectedItemAuthenticationString = value;
                OnPropertyChanged(nameof(AuthenticationValue));
                
                
            }
        }
        public string ConfImpactValue 
        { 
            get { return _selectedItemConfImpactString; }
            set
            {
               _selectedItemConfImpactString = value;
               OnPropertyChanged(nameof(ConfImpactValue));
            }
        }
        public string IntegImpactValue 
        { 
            get { return _selectedItemIntegImpactString; }
            set
            {

                _selectedItemIntegImpactString = value;
                OnPropertyChanged(nameof(IntegImpactValue));
            }
        }
        public string AvailImpactValue 
        { 
            get { return _selectedItemAvailImpactString; }
            set
            {
                _selectedItemAvailImpactString = value;
                OnPropertyChanged(nameof(AvailImpactValue));
            }
        }
        public string BaseScore
        {
            get { return _baseScoreString; }
            set
            {
                if(_baseScoreString != value)
                {
                    _baseScoreString = value;
                    OnPropertyChanged(nameof(BaseScore));
                }
            }
        }
        public string Impact
        {
            get { return _impactString; }
            set
            {
                if(_impactString != value)
                {
                    _impactString = value;
                    OnPropertyChanged(nameof(Impact));
                }
            }
        }
        public string Exploitability
        {
            get { return _exploitabilityString; }
            set
            {
                if(_exploitabilityString != value)
                {
                    _exploitabilityString = value;
                    OnPropertyChanged(nameof(Exploitability));
                }
            }
        }
        public string FImpakt
        {
            get { return _fimpactString; }
            set
            {
                if(_fimpactString != value)
                {
                    _fimpactString = value;
                    OnPropertyChanged(nameof(FImpakt));
                }
            }
        }


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
        private IBaseEquationRepository BaseEquationRepository;
        private BaseEquationModel _BaseEquationModel;


        public BaseEquationViewModel()
        {
            ErrorMessage = "Brak danych!";
            BaseEquationRepository = new BaseEquationRepository();
            _BaseEquationModel = new BaseEquationModel();
            CalculateCommand = new ViewModelCommand(ExecuteCalculateCommand, CanExecuteCalculateCommand);
        }

        private bool CanExecuteCalculateCommand(object obj)
        {
            if (_selectedItemAccessComplexityString != null && _selectedItemAccessVectorString != null && _selectedItemAuthenticationString != null
                && _selectedItemAvailImpactString != null && _selectedItemConfImpactString != null && _selectedItemIntegImpactString !=null)
            {
                SetValuesBaseEquationModel();
                ErrorMessage = "";
                return true;
            }
            return false;
        }

        private void ExecuteCalculateCommand(object obj)
        {
            BaseEquationRepository.setNumberVariables(_BaseEquationModel);
            BaseEquationRepository.calculateAllValues(_BaseEquationModel);
            SetCalculationValue();
        }

        private void SetCalculationValue()
        {
            AccessVectorValue = _selectedItemAccessVectorString; /*+ " (" + Convert.ToString(_BaseEquationModel.AccessVectorNumber) + ")"*/
            AccessComplexityValue = _selectedItemAccessComplexityString; /*+ " (" + Convert.ToString(_BaseEquationModel.AccessComplexityNumber) + ")"*/
            AuthenticationValue = _selectedItemAuthenticationString;  /*+" (" + Convert.ToString(_BaseEquationModel.AuthenticationNumber) + ")"*/
            ConfImpactValue = _selectedItemConfImpactString;  /*+" (" + Convert.ToString(_BaseEquationModel.ConfImpactNumber) + ")"*/
            IntegImpactValue = _selectedItemIntegImpactString;  /*+" (" + Convert.ToString(_BaseEquationModel.IntegImpactNumber) + ")"*/
            AvailImpactValue = _selectedItemAvailImpactString; /*+ " (" + Convert.ToString(_BaseEquationModel.AvailImpactNumber) + ")"*/

            BaseScore = Convert.ToString(_BaseEquationModel.BaseScore);
            Impact = Convert.ToString(_BaseEquationModel.Impact);
            FImpakt = Convert.ToString(_BaseEquationModel.fImpact);
            Exploitability = Convert.ToString(_BaseEquationModel.Exploitability);
        }
        private void SetValuesBaseEquationModel()
        {
            _BaseEquationModel.AccessVectorString = _selectedItemAccessVectorString;
            _BaseEquationModel.AccessComplexityString = _selectedItemAccessComplexityString;
            _BaseEquationModel.AuthenticationString = _selectedItemAuthenticationString;
            _BaseEquationModel.ConfImpactString = _selectedItemConfImpactString;
            _BaseEquationModel.IntegImpactString = _selectedItemIntegImpactString;
            _BaseEquationModel.AvailImpactString = _selectedItemAvailImpactString;
        }
    }
}
