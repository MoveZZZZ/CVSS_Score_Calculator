using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PZ_APP.ViewModels.V3._1
{
    public class TemporalEquationViewModelV3 : ViewModelBase
    {
        private string _selectedItemAttackVectorString;
        private ComboBoxItem _selectedItemAttackVector;

        private string _selectedItemAttackComplexityString;
        private ComboBoxItem _selectedItemAttackComplexity;

        private string _selectedItemPrivilegesRequiredString;
        private ComboBoxItem _selectedItemPrivilegesRequired;

        private string _selectedItemUserInteractionString;
        private ComboBoxItem _selectedItemUserInteraction;

        private string _selectedItemScopeString;
        private ComboBoxItem _selectedItemScope;

        private string _selectedItemConfidentialityString;
        private ComboBoxItem _selectedItemConfidentiality;

        private string _selectedItemIntegrityString;
        private ComboBoxItem _selectedItemIntegrity;

        private string _selectedItemAvailabilityString;
        private ComboBoxItem _selectedItemAvailability;

        private string _selectedItemExploitCodeMaturityString;
        private ComboBoxItem _selectedItemExploitCodeMaturity;

        private string _selectedItemRemediationLevelString;
        private ComboBoxItem _selectedItemRemediationLevel;

        private string _selectedItemReportConfidenceString;
        private ComboBoxItem _selectedItemReportConfidence;

        private string _errorMessage;

        private string _baseScoreString;
        private string _temporalScoreString;


        private string _flagAV;
        private string _flagAC;
        private string _flagPR;
        private string _flagUI;
        private string _flagS;
        private string _flagC;
        private string _flagI;
        private string _flagA;
        private string _flagE;
        private string _flagRL;
        private string _flagRC;






        public string AttackVectorValue
        {
            get { return _selectedItemAttackVectorString; }
            set
            {
                _selectedItemAttackVectorString = value;
                OnPropertyChanged(nameof(AttackVectorValue));
            }
        }
        public string AttackCompexityValue
        {
            get { return _selectedItemAttackComplexityString; }
            set
            {
                _selectedItemAttackComplexityString = value;
                OnPropertyChanged(nameof(AttackCompexityValue));
            }
        }
        public string PrivilegesRequiredValue
        {
            get { return _selectedItemPrivilegesRequiredString; }
            set
            {
                _selectedItemPrivilegesRequiredString = value;
                OnPropertyChanged(nameof(PrivilegesRequiredValue));
            }
        }
        public string UserInteractionValue
        {
            get { return _selectedItemUserInteractionString; }
            set
            {
                _selectedItemUserInteractionString = value;
                OnPropertyChanged(nameof(UserInteractionValue));
            }
        }
        public string ScopeValue
        {
            get { return _selectedItemScopeString; }
            set
            {
                _selectedItemScopeString = value;
                OnPropertyChanged(nameof(ScopeValue));
            }
        }
        public string ConfidentialityValue
        {
            get { return _selectedItemConfidentialityString; }
            set
            {
                _selectedItemConfidentialityString = value;
                OnPropertyChanged(nameof(ConfidentialityValue));
            }
        }
        public string IntegrityValue
        {
            get { return _selectedItemIntegrityString; }
            set
            {
                _selectedItemIntegrityString = value;
                OnPropertyChanged(nameof(IntegrityValue));
            }
        }
        public string AvailabilityValue
        {
            get { return _selectedItemAvailabilityString; }
            set
            {
                _selectedItemAvailabilityString = value;
                OnPropertyChanged(nameof(AvailabilityValue));
            }
        }
        public string ExploitCodeMaturityValue
        {
            get { return _selectedItemExploitCodeMaturityString; }
            set
            {
                _selectedItemExploitCodeMaturityString = value;
                OnPropertyChanged(nameof(ExploitCodeMaturityValue));
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

        public string BaseScoreValue
        {
            get { return _baseScoreString; }
            set
            {
                if (_baseScoreString != value)
                {
                    _baseScoreString = value;
                    OnPropertyChanged(nameof(BaseScoreValue));
                }
            }
        }
        public string TemporalScoreValue
        {
            get { return _temporalScoreString; }
            set
            {
                if (_temporalScoreString != value)
                {
                    _temporalScoreString = value;
                    OnPropertyChanged(nameof(TemporalScoreValue));
                }
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
        public string FlagPR
        {
            get { return _flagPR; }
            set
            {
                if (_flagPR != value)
                {
                    _flagPR = value;
                    OnPropertyChanged(nameof(FlagPR));
                }
            }
        }
        public string FlagUI
        {
            get { return _flagUI; }
            set
            {
                if (_flagUI != value)
                {
                    _flagUI = value;
                    OnPropertyChanged(nameof(FlagUI));
                }
            }
        }
        public string FlagS
        {
            get { return _flagS; }
            set
            {
                if (_flagS != value)
                {
                    _flagS = value;
                    OnPropertyChanged(nameof(FlagS));
                }
            }
        }
        public string FlagC
        {
            get { return _flagC; }
            set
            {
                if (_flagC != value)
                {
                    _flagC = value;
                    OnPropertyChanged(nameof(FlagC));
                }
            }
        }
        public string FlagI
        {
            get { return _flagI; }
            set
            {
                if (_flagI != value)
                {
                    _flagI = value;
                    OnPropertyChanged(nameof(FlagI));
                }
            }
        }
        public string FlagA
        {
            get { return _flagA; }
            set
            {
                if (_flagA != value)
                {
                    _flagA = value;
                    OnPropertyChanged(nameof(FlagA));
                }
            }
        }
        public string FlagE
        {
            get { return _flagE; }
            set
            {
                if (_flagE != value)
                {
                    _flagE = value;
                    OnPropertyChanged(nameof(FlagE));
                }
            }
        }
        public string FlagRL
        {
            get { return _flagRL; }
            set
            {
                if (_flagRL != value)
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
                if (_flagRC != value)
                {
                    _flagRC = value;
                    OnPropertyChanged(nameof(FlagRC));
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

        public ComboBoxItem SelectedItemAttackVector
        {
            get { return _selectedItemAttackVector; }
            set
            {
                if (_selectedItemAttackVector != value)
                {
                    _selectedItemAttackVector = value;
                    OnPropertyChanged(nameof(SelectedItemAttackVector));
                    _selectedItemAttackVectorString = Convert.ToString(SelectedItemAttackVector.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemAttackCompexity
        {
            get { return _selectedItemAttackComplexity; }
            set
            {
                if (_selectedItemAttackComplexity != value)
                {
                    _selectedItemAttackComplexity = value;
                    OnPropertyChanged(nameof(SelectedItemAttackCompexity));
                    _selectedItemAttackComplexityString = Convert.ToString(SelectedItemAttackCompexity.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemPrivilegesRequired
        {
            get { return _selectedItemPrivilegesRequired; }
            set
            {
                if (_selectedItemPrivilegesRequired != value)
                {
                    _selectedItemPrivilegesRequired = value;
                    OnPropertyChanged(nameof(SelectedItemPrivilegesRequired));
                    _selectedItemPrivilegesRequiredString = Convert.ToString(SelectedItemPrivilegesRequired.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemUserInteraction
        {
            get { return _selectedItemUserInteraction; }
            set
            {
                if (_selectedItemUserInteraction != value)
                {
                    _selectedItemUserInteraction = value;
                    OnPropertyChanged(nameof(SelectedItemUserInteraction));
                    _selectedItemUserInteractionString = Convert.ToString(SelectedItemUserInteraction.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemScope
        {
            get { return _selectedItemScope; }
            set
            {
                if (_selectedItemScope != value)
                {
                    _selectedItemScope = value;
                    OnPropertyChanged(nameof(SelectedItemScope));
                    _selectedItemScopeString = Convert.ToString(SelectedItemScope.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemConfidentiality
        {
            get { return _selectedItemConfidentiality; }
            set
            {
                if (_selectedItemConfidentiality != value)
                {
                    _selectedItemConfidentiality = value;
                    OnPropertyChanged(nameof(SelectedItemConfidentiality));
                    _selectedItemConfidentialityString = Convert.ToString(SelectedItemConfidentiality.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemIntegrity
        {
            get { return _selectedItemIntegrity; }
            set
            {
                if (_selectedItemIntegrity != value)
                {
                    _selectedItemIntegrity = value;
                    OnPropertyChanged(nameof(SelectedItemIntegrity));
                    _selectedItemIntegrityString = Convert.ToString(SelectedItemIntegrity.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemAvailability
        {
            get { return _selectedItemAvailability; }
            set
            {
                if (_selectedItemAvailability != value)
                {
                    _selectedItemAvailability = value;
                    OnPropertyChanged(nameof(SelectedItemAvailability));
                    _selectedItemAvailabilityString = Convert.ToString(SelectedItemAvailability.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemExploitCodeMaturity
        {
            get { return _selectedItemExploitCodeMaturity; }
            set
            {
                if (_selectedItemExploitCodeMaturity != value)
                {
                    _selectedItemExploitCodeMaturity = value;
                    OnPropertyChanged(nameof(SelectedItemExploitCodeMaturity));
                    _selectedItemExploitCodeMaturityString = Convert.ToString(SelectedItemExploitCodeMaturity.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemRemediationLevel
        {
            get { return _selectedItemRemediationLevel; }
            set
            {
                if (_selectedItemRemediationLevel != value)
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

        public ICommand CalculateCommand { get; }
        public TemporalEquationViewModelV3()
        {
            ErrorMessage = "Bad data!";
            CalculateCommand = new ViewModelCommand(ExecuteCalculateCommand, CanExecuteCalculateCommand);

        }
        private bool CanExecuteCalculateCommand(object obj)
        {
            if (_selectedItemAttackComplexityString != null && _selectedItemAttackVectorString != null && _selectedItemAvailabilityString != null && _selectedItemConfidentialityString != null
                 && _selectedItemIntegrityString != null && _selectedItemPrivilegesRequiredString != null && _selectedItemScopeString != null && _selectedItemUserInteractionString != null
                 &&_selectedItemExploitCodeMaturityString!=null&&_selectedItemRemediationLevelString!=null&&_selectedItemReportConfidenceString!=null)
            {
                ErrorMessage = "";
                return true;

            }
            return false;
        }

        private void ExecuteCalculateCommand(object obj)
        {
            SetCalculationValue();
        }
        private void SetCalculationValue()
        {
            AttackVectorValue = _selectedItemAttackVectorString;
            AttackCompexityValue = _selectedItemAttackComplexityString;
            PrivilegesRequiredValue = _selectedItemPrivilegesRequiredString;
            UserInteractionValue = _selectedItemUserInteractionString;
            ScopeValue = _selectedItemScopeString;
            ConfidentialityValue = _selectedItemConfidentialityString;
            IntegrityValue = _selectedItemIntegrityString;
            AvailabilityValue = _selectedItemAvailabilityString;
            ExploitCodeMaturityValue = _selectedItemExploitCodeMaturityString;
            RemediationLevelValue = _selectedItemRemediationLevelString;
            ReportConfidenceValue = _selectedItemReportConfidenceString;
        }
    }
}
