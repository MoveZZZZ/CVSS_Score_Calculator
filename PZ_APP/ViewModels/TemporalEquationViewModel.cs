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
    public class TemporalEquationViewModel:ViewModelBase
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

        private string _selectedItemExploitabilityString;
        private ComboBoxItem _selectedItemExploitability;

        private string _selectedItemRemediationLevelString;
        private ComboBoxItem _selectedItemRemediationLevel;

        private string _selectedItemReportConfidenceString;
        private ComboBoxItem _selectedItemReportConfidence;


        private string _errorMessage;

        private string _baseScoreString;
        private string _temporalScoreString;


        private string _flagAV;
        private string _flagAC;
        private string _flagAUTH;
        private string _flagCI;
        private string _flagII;
        private string _flagAI;
        private string _flagEX;
        private string _flagRL;
        private string _flagRC;


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
        public string ExploitabilityValue
        {
            get { return _selectedItemExploitabilityString; }
            set
            {
                _selectedItemExploitabilityString = value;
                OnPropertyChanged(nameof(ExploitabilityValue));
            }
        }
        public string RemediationLevelValue
        {
            get { return _selectedItemRemediationLevelString; }
            set
            {
                _selectedItemRemediationLevelString = value;
                OnPropertyChanged(nameof(RemediationLevelValue));
            }
        }
        public string ReportConfidenceValue
        {
            get { return _selectedItemReportConfidenceString; }
            set
            {
                _selectedItemReportConfidenceString = value;
                OnPropertyChanged(nameof(ReportConfidenceValue));
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
                if (_selectedItemIntegImpact != value)
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
                if (_selectItemAvailImpact != value)
                {
                    _selectItemAvailImpact = value;
                    OnPropertyChanged(nameof(SelectedItemAvailImpact));
                    _selectedItemAvailImpactString = Convert.ToString(SelectedItemAvailImpact.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemExploitability
        {
            get { return _selectedItemExploitability; }
            set
            {
                if(_selectedItemExploitability != value)
                {
                    _selectedItemExploitability = value;
                    OnPropertyChanged(nameof(SelectedItemExploitability));
                    _selectedItemExploitabilityString = Convert.ToString(SelectedItemExploitability.Content);
                }
            }

        }        
        public ComboBoxItem SelectedItemRemediationLevel
        {
            get { return _selectedItemRemediationLevel; }
            set
            {
                if(_selectedItemRemediationLevel!=value)
                {
                    _selectedItemRemediationLevel = value;
                    OnPropertyChanged(nameof(SelectedItemRemediationLevel));
                    _selectedItemRemediationLevelString = Convert.ToString(SelectedItemRemediationLevel.Content);
                }
                
            }

        }        
        public ComboBoxItem SelectedItemReportConfidence
        {
            get { return _selectedItemReportConfidence; }
            set
            {
                if(_selectedItemReportConfidence!=value)
                {
                    _selectedItemReportConfidence = value;
                    OnPropertyChanged(nameof(SelectedItemReportConfidence));
                    _selectedItemReportConfidenceString = Convert.ToString(SelectedItemReportConfidence.Content);
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
        public string FlagAV
        {
            get { return _flagAV; }
            set
            {
                if (_flagAV != value)
                {
                    _flagAV = value;
                    OnPropertyChanged(nameof(FlagAV));
                }
            }
        }
        public string FlagAC
        {
            get { return _flagAC; }
            set
            {
                if (_flagAC != value)
                {
                    _flagAC = value;
                    OnPropertyChanged(nameof(FlagAC));
                }
            }
        }
        public string FlagAUTH
        {
            get { return _flagAUTH; }
            set
            {
                if (_flagAUTH != value)
                {
                    _flagAUTH = value;
                    OnPropertyChanged(nameof(FlagAUTH));
                }
            }
        }
        public string FlagCI
        {
            get { return _flagCI; }
            set
            {
                if (_flagCI != value)
                {
                    _flagCI = value;
                    OnPropertyChanged(nameof(FlagCI));
                }
            }
        }
        public string FlagII
        {
            get { return _flagII; }
            set
            {
                if (_flagII != value)
                {
                    _flagII = value;
                    OnPropertyChanged(nameof(FlagII));
                }
            }
        }
        public string FlagAI
        {
            get { return _flagAI; }
            set
            {
                if (_flagAI != value)
                {
                    _flagAI = value;
                    OnPropertyChanged(nameof(FlagAI));
                }
            }
        }
        public string FlagEX
        {
            get { return _flagEX; }
            set
            {
                if(_flagEX!=value)
                {
                    _flagEX = value;
                    OnPropertyChanged(nameof(FlagEX));
                }
            }
        }
        public string FlagRL
        {
            get { return _flagRL; }
            set
            {
                if(_flagRL!=value)
                {
                    _flagRL = value;
                    OnPropertyChanged(nameof(FlagRL));
                }
            }
        }
        public string FlagRC
        {
            get { return _flagRC; }
            set
            {
                if(_flagRC!=value)
                {
                    _flagRC = value;
                    OnPropertyChanged(nameof(FlagRC));
                }
            }
        }

        public string BaseScore
        {
            get { return _baseScoreString; }
            set
            {
                if (_baseScoreString != value)
                {
                    _baseScoreString = value;
                    OnPropertyChanged(nameof(BaseScore));
                }
            }
        }
        public string TemporalScore
        {
            get { return _temporalScoreString; }
            set
            {
                if (_temporalScoreString != value)
                {
                    _temporalScoreString = value;
                    OnPropertyChanged(nameof(TemporalScore));
                }
            }
        }


        public ICommand CalculateCommand { get; }

        private ITemporalEquationRepository TemporalEquationRepository;
        private TemporalEquationModel _TemporalEquationModel;

        public TemporalEquationViewModel()
        {
            ErrorMessage = "Bad Data!";
            TemporalEquationRepository = new TemporalEquationRepository();
            _TemporalEquationModel = new TemporalEquationModel();

            CalculateCommand = new ViewModelCommand(ExecuteCalculateCommand, CanExecuteCalculateCommand);
        }

        private bool CanExecuteCalculateCommand(object obj)
        {
            if (_selectedItemAccessComplexityString != null && _selectedItemAccessVectorString != null && _selectedItemAuthenticationString != null
                && _selectedItemAvailImpactString != null && _selectedItemConfImpactString != null && _selectedItemIntegImpactString != null 
                && _selectedItemExploitabilityString!=null && _selectedItemRemediationLevelString!=null&& _selectedItemReportConfidenceString!=null)
            {
               SetValuesBaseEquationModel();
                ErrorMessage = "";
                return true;
            }
            return false;
        }

        private void ExecuteCalculateCommand(object obj)
        {
            TemporalEquationRepository.setNumberVariables(_TemporalEquationModel);
            TemporalEquationRepository.calculateAllValues(_TemporalEquationModel);
            SetCalculationValue();
            System.Console.WriteLine(_TemporalEquationModel.BaseScore);

        }

        private void SetCalculationValue()
        {
            AccessVectorValue = _selectedItemAccessVectorString; /*+ " (" + Convert.ToString(_BaseEquationModel.AccessVectorNumber) + ")"*/
            AccessComplexityValue = _selectedItemAccessComplexityString; /*+ " (" + Convert.ToString(_BaseEquationModel.AccessComplexityNumber) + ")"*/
            AuthenticationValue = _selectedItemAuthenticationString;  /*+" (" + Convert.ToString(_BaseEquationModel.AuthenticationNumber) + ")"*/
            ConfImpactValue = _selectedItemConfImpactString;  /*+" (" + Convert.ToString(_BaseEquationModel.ConfImpactNumber) + ")"*/
            IntegImpactValue = _selectedItemIntegImpactString;  /*+" (" + Convert.ToString(_BaseEquationModel.IntegImpactNumber) + ")"*/
            AvailImpactValue = _selectedItemAvailImpactString; /*+ " (" + Convert.ToString(_BaseEquationModel.AvailImpactNumber) + ")"*/
            
            ExploitabilityValue = _selectedItemExploitabilityString;
            RemediationLevelValue = _selectedItemRemediationLevelString;
            ReportConfidenceValue = _selectedItemReportConfidenceString;

            TemporalScore = Convert.ToString(_TemporalEquationModel.TemporalScore);
            BaseScore = Convert.ToString(_TemporalEquationModel.BaseScore);


            FlagAV = Convert.ToString(_TemporalEquationModel.AccessVectorNumber);
            FlagAC = Convert.ToString(_TemporalEquationModel.AccessComplexityNumber);
            FlagAUTH = Convert.ToString(_TemporalEquationModel.AuthenticationNumber);
            FlagCI = Convert.ToString(_TemporalEquationModel.ConfImpactNumber);
            FlagII = Convert.ToString(_TemporalEquationModel.IntegImpactNumber);
            FlagAI = Convert.ToString(_TemporalEquationModel.AvailImpactNumber);

            FlagEX = Convert.ToString(_TemporalEquationModel.ExploitabilityNumber);
            FlagRL = Convert.ToString(_TemporalEquationModel.RemediationLevelNumber);
            FlagRC = Convert.ToString(_TemporalEquationModel.ReportConfidenceNumber);
        }

        private void SetValuesBaseEquationModel()
        {
            _TemporalEquationModel.AccessVectorString = _selectedItemAccessVectorString;
            _TemporalEquationModel.AccessComplexityString = _selectedItemAccessComplexityString;
            _TemporalEquationModel.AuthenticationString = _selectedItemAuthenticationString;
            _TemporalEquationModel.ConfImpactString = _selectedItemConfImpactString;
            _TemporalEquationModel.IntegImpactString = _selectedItemIntegImpactString;
            _TemporalEquationModel.AvailImpactString = _selectedItemAvailImpactString;

            _TemporalEquationModel.ExploitabilityString = _selectedItemExploitabilityString;
            _TemporalEquationModel.RemediationLevelString = _selectedItemRemediationLevelString;
            _TemporalEquationModel.ReportConfidenceString = _selectedItemReportConfidenceString;
        }

    }
}
