using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PZ_APP.Models.V3._1;
using PZ_APP.Repositories.V3._1;

namespace PZ_APP.ViewModels.V3._1
{
    public class EnvironmentalEquationViewModelV3: ViewModelBase
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

        private string _selectedItemModifiedAttackVectorString;
        private ComboBoxItem _selectedItemModifiedAttackVector;

        private string _selectedItemModifiedAttackComplexityString;
        private ComboBoxItem _selectedItemModifiedAttackComplexity;

        private string _selectedItemModifiedPrivilegesRequiredString;
        private ComboBoxItem _selectedItemModifiedPrivilegesRequired;

        private string _selectedItemModifiedUserInteractionString;
        private ComboBoxItem _selectedItemModifiedUserInteraction;

        private string _selectedItemModifiedScopeString;
        private ComboBoxItem _selectedItemModifiedScope;

        private string _selectedItemModifiedConfidentialityString;
        private ComboBoxItem _selectedItemModifiedConfidentiality;

        private string _selectedItemModifiedIntegrityString;
        private ComboBoxItem _selectedItemModifiedIntegrity;

        private string _selectedItemModifiedAvailabilityString;
        private ComboBoxItem _selectedItemModifiedAvailability;

        private string _selectedItemConfidentialityRequirementString;
        private ComboBoxItem _selectedItemConfidentialityRequirement;

        private string _selectedItemIntegrityRequirementString;
        private ComboBoxItem _selectedItemIntegrityRequirement;

        private string _selectedItemAvailabilityRequirementString;
        private ComboBoxItem _selectedItemAvailabilityRequirement;

/*        private string _attackVectorValFlag;
        private string _attackComlexityValFlag;
        private string _privilegesRequiredValFlag;
        private string _userInteractionValFlag;
        private string _scopeValFlag;
        private string _confidentialityValFlag;
        private string _integrityValFlag;
        private string _availabilityValFlag;
        private string _modattackVectorValFlag;
        private string _modattackComlexityValFlag;
        private string _modprivilegesRequiredValFlag;
        private string _moduserInteractionValFlag;
        private string _modscopeValFlag;
        private string _modconfidentialityValFlag;
        private string _modintegrityValFlag;
        private string _modavailabilityValFlag;
        private string _exploitCodeMaturityValFlag;
        private string _remediationLevelValFlag;
        private string _reportConfidenceValFlag;
        private string _confidentialityRequirementValFlag;
        private string _integrityRequirementValFlag;
        private string _availabilityRequirementValFlag;*/

        private string _errorMessage;

        private string _baseScoreString;
        private string _modifiedBaseScoreString;
        private string _temporalScoreString;
        private string _environmentalScoreString;



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
        private string _flagMAV;
        private string _flagMAC;
        private string _flagMPR;
        private string _flagMUI;
        private string _flagMS;
        private string _flagMC;
        private string _flagMI;
        private string _flagMA;
        private string _flagCR;
        private string _flagIR;
        private string _flagAR;

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
        public string ModifiedAttackVectorValue
        {
            get { return _selectedItemModifiedAttackVectorString; }
            set
            {
                _selectedItemModifiedAttackVectorString = value;
                OnPropertyChanged(nameof(ModifiedAttackVectorValue));
            }
        }
        public string ModifiedAttackComplexityValue
        {
            get { return _selectedItemModifiedAttackComplexityString; }
            set
            {
                _selectedItemModifiedAttackComplexityString = value;
                OnPropertyChanged(nameof(ModifiedAttackComplexityValue));
            }
        }
        public string ModifiedPrivilegesRequiredValue
        {
            get { return _selectedItemModifiedPrivilegesRequiredString; }
            set
            {
                _selectedItemModifiedPrivilegesRequiredString = value;
                OnPropertyChanged(nameof(ModifiedPrivilegesRequiredValue));
            }
        }
        public string ModifiedUserInteractionValue
        {
            get { return _selectedItemModifiedUserInteractionString; }
            set
            {
                _selectedItemModifiedUserInteractionString = value;
                OnPropertyChanged(nameof(ModifiedUserInteractionValue));
            }
        }
        public string ModifiedScopeValue
        {
            get { return _selectedItemModifiedScopeString; }
            set
            {
                _selectedItemModifiedScopeString = value;
                OnPropertyChanged(nameof(ModifiedScopeValue));
            }
        }
        public string ModifiedConfidentialityValue
        {
            get { return _selectedItemModifiedConfidentialityString; }
            set
            {
                _selectedItemModifiedConfidentialityString = value;
                OnPropertyChanged(nameof(ModifiedConfidentialityValue));
            }
        }
        public string ModifiedIntegrityValue
        {
            get { return _selectedItemModifiedIntegrityString; }
            set
            {
                _selectedItemModifiedIntegrityString = value;
                OnPropertyChanged(nameof(ModifiedIntegrityValue));
            }
        }
        public string ModifiedAvailabilityValue
        {
            get { return _selectedItemModifiedAvailabilityString; }
            set
            {
                _selectedItemModifiedAvailabilityString = value;
                OnPropertyChanged(nameof(ModifiedAvailabilityValue));
            }
        }
        public string ConfidentialityRequirementValue
        {
            get { return _selectedItemConfidentialityRequirementString; }
            set
            {
                _selectedItemConfidentialityRequirementString = value;
                OnPropertyChanged(nameof(ConfidentialityRequirementValue));
            }
        }
        public string IntegrityRequirementValue
        {
            get { return _selectedItemIntegrityRequirementString; }
            set
            {
                _selectedItemIntegrityRequirementString = value;
                OnPropertyChanged(nameof(IntegrityRequirementValue));
            }
        }
        public string AvailabilityRequirementValue
        {
            get { return _selectedItemAvailabilityRequirementString; }
            set
            {
                _selectedItemAvailabilityRequirementString = value;
                OnPropertyChanged(nameof(AvailabilityRequirementValue));
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
        public string ModBaseScoreValue
        {
            get { return _modifiedBaseScoreString; }
            set
            {
                if (_modifiedBaseScoreString != value)
                {
                    _modifiedBaseScoreString = value;
                    OnPropertyChanged(nameof(ModBaseScoreValue));
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
        public string EnvironmentalScoreValue
        {
            get { return _environmentalScoreString; }
            set
            {
                if(_environmentalScoreString!=value)
                {
                    _environmentalScoreString = value;
                    OnPropertyChanged(nameof(EnvironmentalScoreValue));
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
        public string FlagMAV
        {
            get { return _flagMAV; }
            set
            {
                if (_flagMAV != value)
                {
                    _flagMAV = value;
                    OnPropertyChanged(nameof(FlagMAV));
                }
            }
        }
        public string FlagMAC
        {
            get { return _flagMAC; }
            set
            {
                if (_flagMAC != value)
                {
                    _flagMAC = value;
                    OnPropertyChanged(nameof(FlagMAC));
                }
            }
        }
        public string FlagMPR
        {
            get { return _flagMPR; }
            set
            {
                if (_flagMPR != value)
                {
                    _flagMPR = value;
                    OnPropertyChanged(nameof(FlagMPR));
                }
            }
        }
        public string FlagMUI
        {
            get { return _flagMUI; }
            set
            {
                if (_flagMUI != value)
                {
                    _flagMUI = value;
                    OnPropertyChanged(nameof(FlagMUI));
                }
            }
        }
        public string FlagMS
        {
            get { return _flagMS; }
            set
            {
                if (_flagMS!= value)
                {
                    _flagMS = value;
                    OnPropertyChanged(nameof(FlagMS));
                }
            }
        }
        public string FlagMC
        {
            get { return _flagMC; }
            set
            {
                if (_flagMC != value)
                {
                    _flagMC = value;
                    OnPropertyChanged(nameof(FlagMC));
                }
            }
        }
        public string FlagMI
        {
            get { return _flagMI; }
            set
            {
                if (_flagMI != value)
                {
                    _flagMI = value;
                    OnPropertyChanged(nameof(FlagMI));
                }
            }
        }
        public string FlagMA
        {
            get { return _flagMA; }
            set
            {
                if (_flagMA != value)
                {
                    _flagMA = value;
                    OnPropertyChanged(nameof(FlagMA));
                }
            }
        }
        public string FlagCR
        {
            get { return _flagCR; }
            set
            {
                if (_flagCR != value)
                {
                    _flagCR = value;
                    OnPropertyChanged(nameof(FlagCR));
                }
            }
        }
        public string FlagIR
        {
            get { return _flagIR; }
            set
            {
                if (_flagIR != value)
                {
                    _flagIR = value;
                    OnPropertyChanged(nameof(FlagIR));
                }
            }
        }
        public string FlagAR
        {
            get { return _flagAR; }
            set
            {
                if (_flagAR!= value)
                {
                    _flagAR = value;
                    OnPropertyChanged(nameof(FlagAR));
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
                if (_selectedItemReportConfidence != value)
                {
                    _selectedItemReportConfidence = value;
                    OnPropertyChanged(nameof(SelectedItemReportConfidence));
                    _selectedItemReportConfidenceString = Convert.ToString(SelectedItemReportConfidence.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemModifiedAttackVector
        {
            get { return _selectedItemModifiedAttackVector; }
            set
            {
                if(_selectedItemModifiedAttackVector!=value)
                {
                    _selectedItemModifiedAttackVector = value;
                    OnPropertyChanged(nameof(SelectedItemModifiedAttackVector));
                    _selectedItemModifiedAttackVectorString = Convert.ToString(SelectedItemModifiedAttackVector.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemModifiedAttackComplexity
        {
            get { return _selectedItemModifiedAttackComplexity; }
            set
            {
                if(_selectedItemModifiedAttackComplexity!=value)
                {
                    _selectedItemModifiedAttackComplexity = value;
                    OnPropertyChanged(nameof(SelectedItemModifiedAttackComplexity));
                    _selectedItemModifiedAttackComplexityString = Convert.ToString(SelectedItemModifiedAttackComplexity.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemModifiedPrivilegesRequired
        {
            get { return _selectedItemModifiedPrivilegesRequired; }
            set
            {
                if(_selectedItemModifiedPrivilegesRequired!=value)
                {
                    _selectedItemModifiedPrivilegesRequired = value;
                    OnPropertyChanged(nameof(SelectedItemModifiedPrivilegesRequired));
                    _selectedItemModifiedPrivilegesRequiredString = Convert.ToString(SelectedItemModifiedPrivilegesRequired.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemModifiedUserInteraction
        {
            get { return _selectedItemModifiedUserInteraction; }
            set
            {
                if(_selectedItemModifiedUserInteraction!=value)
                {
                    _selectedItemModifiedUserInteraction = value;
                    OnPropertyChanged(nameof(SelectedItemModifiedUserInteraction));
                    _selectedItemModifiedUserInteractionString = Convert.ToString(SelectedItemModifiedUserInteraction.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemModifiedScope
        {
            get { return _selectedItemModifiedScope; }
            set
            {
                if(_selectedItemModifiedScope!=value)
                {
                    _selectedItemModifiedScope = value;
                    OnPropertyChanged(nameof(SelectedItemModifiedScope));
                    _selectedItemModifiedScopeString = Convert.ToString(SelectedItemModifiedScope.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemModifiedConfidentiality
        {
            get { return _selectedItemModifiedConfidentiality; }
            set
            {
                if(_selectedItemModifiedConfidentiality!=value)
                {
                    _selectedItemModifiedConfidentiality = value;
                    OnPropertyChanged(nameof(SelectedItemModifiedConfidentiality));
                    _selectedItemModifiedConfidentialityString = Convert.ToString(SelectedItemModifiedConfidentiality.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemModifiedIntegrity
        {
            get { return _selectedItemModifiedIntegrity; }
            set
            {
                if(_selectedItemModifiedIntegrity!=value)
                {
                    _selectedItemModifiedIntegrity = value;
                    OnPropertyChanged(nameof(SelectedItemModifiedIntegrity));
                    _selectedItemModifiedIntegrityString = Convert.ToString(SelectedItemModifiedIntegrity.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemModifiedAvailability
        {
            get { return _selectedItemModifiedAvailability; }
            set
            {
                if(_selectedItemModifiedAvailability!=value)
                {
                    _selectedItemModifiedAvailability = value;
                    OnPropertyChanged(nameof(SelectedItemModifiedAvailability));
                    _selectedItemModifiedAvailabilityString = Convert.ToString(SelectedItemModifiedAvailability.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemConfidentialityRequirement
        {
            get { return _selectedItemConfidentialityRequirement; }
            set
            {
                if(_selectedItemConfidentialityRequirement!=value)
                {
                    _selectedItemConfidentialityRequirement = value;
                    OnPropertyChanged(nameof(SelectedItemConfidentialityRequirement));
                    _selectedItemConfidentialityRequirementString = Convert.ToString(SelectedItemConfidentialityRequirement.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemIntegrityRequirement
        {
            get { return _selectedItemIntegrityRequirement; }
            set
            {
                if(_selectedItemIntegrityRequirement!=value)
                {
                    _selectedItemIntegrityRequirement = value;
                    OnPropertyChanged(nameof(SelectedItemIntegrityRequirement));
                    _selectedItemIntegrityRequirementString = Convert.ToString(SelectedItemIntegrityRequirement.Content);
                }    
            }
        }
        public ComboBoxItem SelectedItemAvailabilityRequirement
        {
            get { return _selectedItemAvailabilityRequirement; }
            set
            {
                if(_selectedItemAvailabilityRequirement!=value)
                {
                    _selectedItemAvailabilityRequirement = value;
                    OnPropertyChanged(nameof(SelectedItemAvailabilityRequirement));
                    _selectedItemAvailabilityRequirementString = Convert.ToString(SelectedItemAvailabilityRequirement.Content);
                }
            
            }
        }

        public ICommand CalculateCommand { get; }
        private IEnvironmentalEquationRepositoryV3 EnvironmentalEquationRepositoryV3;
        private EnvironmentalEquationModelV3 _EnvironmentalEquationModelV3;

        public EnvironmentalEquationViewModelV3()
        {
            ErrorMessage = "Bad Data!";
            EnvironmentalEquationRepositoryV3 = new EnvironmentalEquationRepositoryV3();
            _EnvironmentalEquationModelV3 = new EnvironmentalEquationModelV3();
            CalculateCommand = new ViewModelCommand(ExecuteCalculateCommand, CanExecuteCalculateCommand);
        }

        private bool CanExecuteCalculateCommand(object obj)
        {
            if (_selectedItemAttackComplexityString != null && _selectedItemAttackVectorString != null && _selectedItemAvailabilityString != null && _selectedItemConfidentialityString != null
                 && _selectedItemIntegrityString != null && _selectedItemPrivilegesRequiredString != null && _selectedItemScopeString != null && _selectedItemUserInteractionString != null
                 && _selectedItemExploitCodeMaturityString != null && _selectedItemRemediationLevelString != null && _selectedItemReportConfidenceString != null
                 && _selectedItemModifiedAttackComplexityString != null && _selectedItemModifiedAttackVectorString != null && _selectedItemModifiedAvailabilityString != null
                 && _selectedItemModifiedConfidentialityString != null && _selectedItemModifiedIntegrityString != null && _selectedItemModifiedPrivilegesRequiredString != null
                 && _selectedItemModifiedScopeString != null && _selectedItemModifiedUserInteractionString != null && _selectedItemConfidentialityRequirementString != null
                 && _selectedItemIntegrityRequirementString != null&&_selectedItemAvailabilityRequirementString!=null)
            {
                SetValuesEnvironmentalEquationModelV3();
                ErrorMessage = "";
                return true;

            }
            return false;
        }

        private void ExecuteCalculateCommand(object obj)
        {
            EnvironmentalEquationRepositoryV3.setNumberVariables(_EnvironmentalEquationModelV3);
            EnvironmentalEquationRepositoryV3.calculateAllValues(_EnvironmentalEquationModelV3);
            SetEndValue();
        }
        private void SetEndValue()
        {
            setFlags();
            setBasicValues();
            setCalculatedValues();
        }
        private void SetValuesEnvironmentalEquationModelV3()
        {
            _EnvironmentalEquationModelV3.AttackVectorString = _selectedItemAttackVectorString;
            _EnvironmentalEquationModelV3.AttackComplexityString = _selectedItemAttackComplexityString;
            _EnvironmentalEquationModelV3.PrivilegesRequiredString = _selectedItemPrivilegesRequiredString;
            _EnvironmentalEquationModelV3.UserInteractionString = _selectedItemUserInteractionString;
            _EnvironmentalEquationModelV3.ScopeString = _selectedItemScopeString;
            _EnvironmentalEquationModelV3.ConfidentialityString = _selectedItemConfidentialityString;
            _EnvironmentalEquationModelV3.IntegrityString = _selectedItemIntegrityString;
            _EnvironmentalEquationModelV3.AvailabilityString = _selectedItemAvailabilityString;
            _EnvironmentalEquationModelV3.ExploitCodeMaturityString = _selectedItemExploitCodeMaturityString;
            _EnvironmentalEquationModelV3.RemediationLevelString = _selectedItemRemediationLevelString;
            _EnvironmentalEquationModelV3.ReportConfidenceString = _selectedItemReportConfidenceString;
            _EnvironmentalEquationModelV3.ConfidentialityRequirementString = _selectedItemConfidentialityRequirementString;
            _EnvironmentalEquationModelV3.IntegrityRequirementString = _selectedItemIntegrityRequirementString;
            _EnvironmentalEquationModelV3.AvailabilityRequirementString = _selectedItemAvailabilityRequirementString;
            _EnvironmentalEquationModelV3.ModifiedAttackVectorString = _selectedItemModifiedAttackVectorString;
            _EnvironmentalEquationModelV3.ModifiedAttackComplexityString = _selectedItemModifiedAttackComplexityString;
            _EnvironmentalEquationModelV3.ModifiedPrivilegesRequiredString = _selectedItemModifiedPrivilegesRequiredString;
            _EnvironmentalEquationModelV3.ModifiedUserInteractionString = _selectedItemModifiedUserInteractionString;
            _EnvironmentalEquationModelV3.ModifiedScopeString = _selectedItemModifiedScopeString;
            _EnvironmentalEquationModelV3.ModifiedConfidentialityString = _selectedItemModifiedConfidentialityString;
            _EnvironmentalEquationModelV3.ModifiedIntegrityString = _selectedItemModifiedIntegrityString;
            _EnvironmentalEquationModelV3.ModifiedAvailabilityString = _selectedItemModifiedAvailabilityString;
        }
        private void setBasicValues()
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

            ModifiedAttackVectorValue = _selectedItemModifiedAttackVectorString;
            ModifiedAttackComplexityValue = _selectedItemModifiedAttackComplexityString;
            ModifiedPrivilegesRequiredValue = _selectedItemModifiedPrivilegesRequiredString;
            ModifiedUserInteractionValue = _selectedItemModifiedUserInteractionString;
            ModifiedScopeValue = _selectedItemModifiedScopeString;
            ModifiedConfidentialityValue = _selectedItemModifiedConfidentialityString;
            ModifiedIntegrityValue = _selectedItemModifiedIntegrityString;
            ModifiedAvailabilityValue = _selectedItemModifiedAvailabilityString;
            ConfidentialityRequirementValue = _selectedItemConfidentialityRequirementString;
            IntegrityRequirementValue = _selectedItemIntegrityRequirementString;
            AvailabilityRequirementValue = _selectedItemAvailabilityRequirementString;
        }
        private void setFlags()
        {
            FlagAV = "(" + Convert.ToString(_EnvironmentalEquationModelV3.AttackVectorNumber) + ")";
            FlagAC = "(" + Convert.ToString(_EnvironmentalEquationModelV3.AttackComplexityNumber) + ")";
            FlagPR = "(" + Convert.ToString(_EnvironmentalEquationModelV3.PrivilegesRequiredNumber) + ")";
            FlagUI = "(" + Convert.ToString(_EnvironmentalEquationModelV3.UserInteractionNumber) + ")";
            FlagS = "(" + Convert.ToString(_EnvironmentalEquationModelV3.ScopeNumber) + ")";
            FlagC = "(" + Convert.ToString(_EnvironmentalEquationModelV3.ConfidentialityNumber) + ")";
            FlagI = "(" + Convert.ToString(_EnvironmentalEquationModelV3.IntegrityNumber) + ")";
            FlagA = "(" + Convert.ToString(_EnvironmentalEquationModelV3.AvailabilityNumber) + ")";
            FlagE = "(" + Convert.ToString(_EnvironmentalEquationModelV3.ExploitCodeMaturityNumber) + ")";
            FlagRL = "(" + Convert.ToString(_EnvironmentalEquationModelV3.RemediationLevelNumber) + ")";
            FlagRC = "(" + Convert.ToString(_EnvironmentalEquationModelV3.ReportConfidenceNumber) + ")";
            FlagCR = "(" + Convert.ToString(_EnvironmentalEquationModelV3.ConfidentialityRequirementNumber) + ")";
            FlagIR = "(" + Convert.ToString(_EnvironmentalEquationModelV3.IntegrityRequirementNumber) + ")";
            FlagAR = "(" + Convert.ToString(_EnvironmentalEquationModelV3.AvailabilityRequirementNumber) + ")";
            FlagMAV = "(" + Convert.ToString(_EnvironmentalEquationModelV3.ModifiedAttackVectorNumber) + ")";
            FlagMAC = "(" + Convert.ToString(_EnvironmentalEquationModelV3.ModifiedAttackComplexityNumber) + ")";
            FlagMPR = "(" + Convert.ToString(_EnvironmentalEquationModelV3.ModifiedPrivilegesRequiredNumber) + ")";
            FlagMUI = "(" + Convert.ToString(_EnvironmentalEquationModelV3.ModifiedUserInteractionNumber) + ")";
            FlagMS = "(" + Convert.ToString(_EnvironmentalEquationModelV3.ModifiedScopeNumber) + ")";
            FlagMC = "(" + Convert.ToString(_EnvironmentalEquationModelV3.ModifiedConfidentialityNumber) + ")";
            FlagMI = "(" + Convert.ToString(_EnvironmentalEquationModelV3.ModifiedIntegrityNumber) + ")";
            FlagMA = "(" + Convert.ToString(_EnvironmentalEquationModelV3.ModifiedAvailabilityNumber) + ")";
        }
        private void setCalculatedValues()
        {
            BaseScoreValue = Convert.ToString(_EnvironmentalEquationModelV3.BaseScore) + " ("+_EnvironmentalEquationModelV3.RatingBase+")";
            TemporalScoreValue = Convert.ToString(_EnvironmentalEquationModelV3.TemporalScore)+" ("+_EnvironmentalEquationModelV3.RatingTemporal+")";
            EnvironmentalScoreValue = Convert.ToString(_EnvironmentalEquationModelV3.EnvironmentalScore)+" ("+_EnvironmentalEquationModelV3.RatingEnvironmental+")";
        }
    }
}
