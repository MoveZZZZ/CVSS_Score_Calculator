using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using PZ_APP.Models;
using PZ_APP.Repositories;

namespace PZ_APP.ViewModels
{
    public class EnvironmentalEquationViewModel: ViewModelBase
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

        private string _selectedItemCollateralDamagePotentialString;
        private ComboBoxItem _selectedItemCollateralDamagePotential;       
        
        private string _selectedItemTargetDistributionString;
        private ComboBoxItem _selectedItemTargetDistribution;
        
        private string _selectedItemConfReqString;
        private ComboBoxItem _selectedItemConfReq;

        private string _selectedItemIntegReqString;
        private ComboBoxItem _selectedItemIntegReq;

        private string _selectedItemAvailReqString;
        private ComboBoxItem _selectedItemAvailReq;


        private string _errorMessage;

        private string _baseScoreString;
        private string _temporalScoreString;

        private string _environmentalScoreString;
        private string _adjustedTemporalString;
        private string _adjustedImpactString;
        private string _baseScoreEEString;
        private string _temporalScoreEEString;


        private string _flagAV;
        private string _flagAC;
        private string _flagAUTH;
        private string _flagCI;
        private string _flagII;
        private string _flagAI;
        private string _flagEX;
        private string _flagRL;
        private string _flagRC;

        private string _flagCDP;
        private string _flagTD;
        private string _flagCR;
        private string _flagIR;
        private string _flagAR;

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
        public string CollateralDamagePotentialValue
        {
            get { return _selectedItemCollateralDamagePotentialString; }
            set
            {
                _selectedItemCollateralDamagePotentialString = value;
                OnPropertyChanged(nameof(CollateralDamagePotentialValue));
            }
        }
        public string TargetDistributionValue
        {
            get { return _selectedItemTargetDistributionString; }
            set
            {
                _selectedItemTargetDistributionString = value;
                OnPropertyChanged(nameof(TargetDistributionValue));
            }
        }
        public string ConfReqValue
        {
            get { return _selectedItemConfReqString; }
            set
            {
                _selectedItemConfReqString = value;
                OnPropertyChanged(nameof(ConfReqValue));
            }
        }
        public string IntegReqValue
        {
            get { return _selectedItemIntegReqString; }
            set
            {
                _selectedItemIntegReqString = value;
                OnPropertyChanged(nameof(IntegReqValue));
            }
        }
        public string AvailReqValue
        {
            get { return _selectedItemAvailReqString; }
            set
            {
                _selectedItemAvailReqString = value;
                OnPropertyChanged(nameof(AvailReqValue));
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
                if (_selectedItemExploitability != value)
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
        public ComboBoxItem SelectedItemCollateralDamagePotential
        {
            get { return _selectedItemCollateralDamagePotential; }
            set
            {
                if(_selectedItemCollateralDamagePotential!=value)
                {
                    _selectedItemCollateralDamagePotential = value;
                    OnPropertyChanged(nameof(SelectedItemCollateralDamagePotential));
                    _selectedItemCollateralDamagePotentialString = Convert.ToString(SelectedItemCollateralDamagePotential.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemTargetDistribution
        {
            get { return _selectedItemTargetDistribution; }
            set
            {
                if (_selectedItemTargetDistribution != value)
                {
                    _selectedItemTargetDistribution = value;
                    OnPropertyChanged(nameof(SelectedItemTargetDistribution));
                    _selectedItemTargetDistributionString = Convert.ToString(SelectedItemTargetDistribution.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemConfReq
        {
            get { return _selectedItemConfReq; }
            set
            {
                if (_selectedItemConfReq != value)
                {
                    _selectedItemConfReq = value;
                    OnPropertyChanged(nameof(SelectedItemConfReq));
                    _selectedItemConfReqString = Convert.ToString(SelectedItemConfReq.Content);
                }
            }
        }
        /// <summary>
        /// ///
        /// </summary>
        public ComboBoxItem SelectedItemIntegReq
        {
            get { return _selectedItemIntegReq; }
            set
            {
                if (_selectedItemIntegReq != value)
                {
                    _selectedItemIntegReq = value;
                    OnPropertyChanged(nameof(SelectedItemIntegReq));
                    _selectedItemIntegReqString = Convert.ToString(SelectedItemIntegReq.Content);
                }
            }
        }
        public ComboBoxItem SelectedItemAvailReq
        {
            get { return _selectedItemAvailReq; }
            set
            {
                if (_selectedItemAvailReq != value)
                {
                    _selectedItemAvailReq = value;
                    OnPropertyChanged(nameof(SelectedItemAvailReq));
                    _selectedItemAvailReqString = Convert.ToString(SelectedItemAvailReq.Content);
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
        //All Flags
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
                if (_flagEX != value)
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
        public string FlagCDP
        {
            get { return _flagCDP; }
            set
            {
                if (_flagCDP != value)
                {
                    _flagCDP = value;
                    OnPropertyChanged(nameof(FlagCDP));
                }
            }
        }
        public string FlagTD
        {
            get { return _flagTD; }
            set
            {
                if (_flagTD != value)
                {
                    _flagTD = value;
                    OnPropertyChanged(nameof(FlagTD));
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
                if (_flagAR != value)
                {
                    _flagAR = value;
                    OnPropertyChanged(nameof(FlagAR));
                }
            }
        }
        //All calculated values
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
        public string EnvironmentalScore
        {
            get { return _environmentalScoreString; }
            set
            {
                if(_environmentalScoreString!=value)
                {
                    _environmentalScoreString = value;
                    OnPropertyChanged(nameof(EnvironmentalScore));
                }
            }
        }
        public string AdjustedTemporal
        {
            get { return _adjustedTemporalString; }
            set
            {
                if(_adjustedTemporalString!=value)
                {
                    _adjustedTemporalString = value;
                    OnPropertyChanged(nameof(AdjustedTemporal));
                }
            }
        }
        public string AdjustedImpact
        {
            get { return _adjustedImpactString; }
            set
            {
                if(_adjustedImpactString!=value)
                {
                    _adjustedImpactString = value;
                    OnPropertyChanged(nameof(AdjustedImpact));
                }
            }
        }
        public string BaseScoreEE
        {
            get { return _baseScoreEEString; }
            set
            {
                if(_baseScoreEEString!=value)
                {
                    _baseScoreEEString = value;
                    OnPropertyChanged(nameof(BaseScoreEE));
                }
            }
        }
        public string TemporalScoreEE
        {
            get { return _temporalScoreEEString; }
            set
            {
                if(_temporalScoreEEString!=value)
                {
                    _temporalScoreEEString = value;
                    OnPropertyChanged(nameof(TemporalScoreEE));
                }
            }
        }



        public ICommand CalculateCommand { get; }
        private IEnvironmentalEquationRepository EnvironmentalEquationRepository;
        private EnvironmentalEquationModel _EnvironmentalEquationModel;

        public EnvironmentalEquationViewModel()
        {
            ErrorMessage = "Bad Data!";
            EnvironmentalEquationRepository = new EnvironmentalEquationRepository();
            _EnvironmentalEquationModel = new EnvironmentalEquationModel();

            CalculateCommand = new ViewModelCommand(ExecuteCalculateCommand, CanExecuteCalculateCommand);
        }

        private bool CanExecuteCalculateCommand(object obj)
        {
            if (_selectedItemAccessComplexityString != null && _selectedItemAccessVectorString != null && _selectedItemAuthenticationString != null
                && _selectedItemAvailImpactString != null && _selectedItemConfImpactString != null && _selectedItemIntegImpactString != null
                && _selectedItemExploitabilityString != null && _selectedItemRemediationLevelString != null && _selectedItemReportConfidenceString != null
                && _selectedItemCollateralDamagePotentialString!=null && _selectedItemTargetDistributionString!=null
                && _selectedItemConfReqString!=null&&_selectedItemIntegReqString!=null && _selectedItemAvailReqString!=null)
            {
                SetValuesEnvironmentalEquationModel();
                ErrorMessage = "";
                return true;
            }
            return false;
        }

        private void ExecuteCalculateCommand(object obj)
        {
            EnvironmentalEquationRepository.setNumberVariables(_EnvironmentalEquationModel);
            EnvironmentalEquationRepository.calculateAllValues(_EnvironmentalEquationModel);
            SetCalculationValue();
        }


        private void SetCalculationValue()
        {
            AccessVectorValue = _selectedItemAccessVectorString;
            AccessComplexityValue = _selectedItemAccessComplexityString;
            AuthenticationValue = _selectedItemAuthenticationString;
            ConfImpactValue = _selectedItemConfImpactString;
            IntegImpactValue = _selectedItemIntegImpactString;
            AvailImpactValue = _selectedItemAvailImpactString;

            ExploitabilityValue = _selectedItemExploitabilityString;
            RemediationLevelValue = _selectedItemRemediationLevelString;
            ReportConfidenceValue = _selectedItemReportConfidenceString;

            CollateralDamagePotentialValue = _selectedItemCollateralDamagePotentialString;
            TargetDistributionValue = _selectedItemTargetDistributionString;
            ConfReqValue = _selectedItemConfReqString;
            IntegReqValue = _selectedItemIntegReqString;
            AvailReqValue = _selectedItemAvailReqString;


            BaseScore = Convert.ToString(_EnvironmentalEquationModel.BaseScore);
            BaseScoreEE = Convert.ToString(_EnvironmentalEquationModel.BaseScoreEE);
            TemporalScore = Convert.ToString(_EnvironmentalEquationModel.TemporalScore);
            TemporalScoreEE = Convert.ToString(_EnvironmentalEquationModel.TemporalScoreEE);
            EnvironmentalScore = Convert.ToString(_EnvironmentalEquationModel.EnvironmentalScore);
            AdjustedTemporal = Convert.ToString(_EnvironmentalEquationModel.AdjustedTemporal);
            AdjustedImpact = Convert.ToString(Math.Round(_EnvironmentalEquationModel.AdjustedImpact,8));


            FlagAV = Convert.ToString(_EnvironmentalEquationModel.AccessVectorNumber);
            FlagAC = Convert.ToString(_EnvironmentalEquationModel.AccessComplexityNumber);
            FlagAUTH = Convert.ToString(_EnvironmentalEquationModel.AuthenticationNumber);
            FlagCI = Convert.ToString(_EnvironmentalEquationModel.ConfImpactNumber);
            FlagII = Convert.ToString(_EnvironmentalEquationModel.IntegImpactNumber);
            FlagAI = Convert.ToString(_EnvironmentalEquationModel.AvailImpactNumber);

            FlagEX = Convert.ToString(_EnvironmentalEquationModel.ExploitabilityNumber);
            FlagRL = Convert.ToString(_EnvironmentalEquationModel.RemediationLevelNumber);
            FlagRC = Convert.ToString(_EnvironmentalEquationModel.ReportConfidenceNumber);

            FlagCDP = Convert.ToString(_EnvironmentalEquationModel.CollateralDamagePotentialNumber);
            FlagTD = Convert.ToString(_EnvironmentalEquationModel.TargetDistributionNumber);
            FlagCR = Convert.ToString(_EnvironmentalEquationModel.ConfReqNumber);
            FlagIR = Convert.ToString(_EnvironmentalEquationModel.IntegReqNumber);
            FlagAR = Convert.ToString(_EnvironmentalEquationModel.AvailReqNumber);
        }

        private void SetValuesEnvironmentalEquationModel()
        {
            _EnvironmentalEquationModel.AccessVectorString = _selectedItemAccessVectorString;
            _EnvironmentalEquationModel.AccessComplexityString = _selectedItemAccessComplexityString;
            _EnvironmentalEquationModel.AuthenticationString = _selectedItemAuthenticationString;
            _EnvironmentalEquationModel.ConfImpactString = _selectedItemConfImpactString;
            _EnvironmentalEquationModel.IntegImpactString = _selectedItemIntegImpactString;
            _EnvironmentalEquationModel.AvailImpactString = _selectedItemAvailImpactString;

            _EnvironmentalEquationModel.ExploitabilityString = _selectedItemExploitabilityString;
            _EnvironmentalEquationModel.RemediationLevelString = _selectedItemRemediationLevelString;
            _EnvironmentalEquationModel.ReportConfidenceString = _selectedItemReportConfidenceString;

            _EnvironmentalEquationModel.CollateralDamagePotentialString = _selectedItemCollateralDamagePotentialString;
            _EnvironmentalEquationModel.TargetDistributionString = _selectedItemTargetDistributionString;
            _EnvironmentalEquationModel.ConfReqString = _selectedItemConfReqString;
            _EnvironmentalEquationModel.IntegReqString = _selectedItemIntegReqString;
            _EnvironmentalEquationModel.AvailReqString = _selectedItemAvailReqString;
        }
    }
}
