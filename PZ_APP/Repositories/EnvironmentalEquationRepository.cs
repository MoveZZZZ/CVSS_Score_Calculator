using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PZ_APP.Models;

namespace PZ_APP.Repositories
{
    public class EnvironmentalEquationRepository : IEnvironmentalEquationRepository
    {
        Dictionary<string, double> AccessVectorValuesDict;
        Dictionary<string, double> AccessComplexityValuesDict;
        Dictionary<string, double> AuthenticationValuesDict;
        Dictionary<string, double> ConfImpactValuesDict;
        Dictionary<string, double> IntegImpactValuesDict;
        Dictionary<string, double> AvailImpactValuesDict;

        Dictionary<string, double> ExploitabilityValuesDict;
        Dictionary<string, double> RemediationLevelValuesDict;
        Dictionary<string, double> ReportConfidenceValuesDict;

        Dictionary<string, double> CollateralDamagePotentialDict;
        Dictionary<string, double> TargetDistributionDict;
        Dictionary<string, double> ConfReqDict;
        Dictionary<string, double> IntegReqDict;
        Dictionary<string, double> AvailReqDict;

        public EnvironmentalEquationRepository()
        {
            fillDictionaries();
        }


        public void calculateAllValues(EnvironmentalEquationModel environmental_equation_model)
        {
            calculateImpact(environmental_equation_model);
            calculateFImpakt(environmental_equation_model);
            calculateExploitability(environmental_equation_model);
            calculateBaseScore(environmental_equation_model);
            calculateTemporalScore(environmental_equation_model);

            calculateAdjustedImpact(environmental_equation_model);
            calculateFImpaktEE(environmental_equation_model);
            calculateBaseScoreForEnvironmentalEquation(environmental_equation_model);
            calculateTemporalScoreForEnvironmentalEquation(environmental_equation_model);
            calculateAdjustedTemporal(environmental_equation_model);
            calculateEnvironmentalScore(environmental_equation_model);
        }
        public void calculateEnvironmentalScore(EnvironmentalEquationModel environmental_equation_model)
        {
            double EnvironmentalScore = 0;
            EnvironmentalScore = (environmental_equation_model.AdjustedTemporal + (10 - environmental_equation_model.AdjustedImpact) *
                environmental_equation_model.CollateralDamagePotentialNumber) * environmental_equation_model.TargetDistributionNumber;
            environmental_equation_model.EnvironmentalScore = Math.Round(EnvironmentalScore, 1);
        }

        public void calculateAdjustedTemporal(EnvironmentalEquationModel environmental_equation_model)
        {
            environmental_equation_model.AdjustedTemporal = environmental_equation_model.TemporalScoreEE;
        }

        public void calculateAdjustedImpact(EnvironmentalEquationModel environmental_equation_model)
        {
            double adjustedImpactD= 0;
            adjustedImpactD = 10.41 * (1 - (1 - environmental_equation_model.ConfImpactNumber * environmental_equation_model.ConfReqNumber) *
                (1 - environmental_equation_model.IntegImpactNumber * environmental_equation_model.IntegReqNumber) * (1 - environmental_equation_model.AvailImpactNumber * environmental_equation_model.AvailReqNumber));
            environmental_equation_model.AdjustedImpact = Math.Min(10, adjustedImpactD);
        }
        public void calculateBaseScore(EnvironmentalEquationModel environmental_equation_model)
        {
            double baseScoreS;
            baseScoreS = ((0.6 * environmental_equation_model.Impact) + (0.4 * environmental_equation_model.ExploitabilityBS) - 1.5) * environmental_equation_model.fImpact;
            environmental_equation_model.BaseScore = Math.Round(baseScoreS, 1);
        }

        public void calculateBaseScoreForEnvironmentalEquation(EnvironmentalEquationModel environmental_equation_model)
        {
            double baseScoreEE = 0;
            baseScoreEE = ((0.6 * environmental_equation_model.AdjustedImpact) + (0.4 * environmental_equation_model.ExploitabilityBS) - 1.5) * environmental_equation_model.fImpact;
            environmental_equation_model.BaseScoreEE = Math.Round(baseScoreEE, 1);
        }

        public void calculateExploitability(EnvironmentalEquationModel environmental_equation_model)
        {
            environmental_equation_model.ExploitabilityBS = 20 * environmental_equation_model.AccessVectorNumber * environmental_equation_model.AccessComplexityNumber * environmental_equation_model.AuthenticationNumber;
        }

        public void calculateFImpakt(EnvironmentalEquationModel environmental_equation_model)
        {
            if (environmental_equation_model.Impact == 0)
            {
                environmental_equation_model.fImpact = 0;
            }
            else
            {
                environmental_equation_model.fImpact = 1.176;
            }
        }
        public void calculateFImpaktEE(EnvironmentalEquationModel environmental_equation_model)
        {
            if(environmental_equation_model.AdjustedImpact == 0)
            {
                environmental_equation_model.fImpact = 0;
            }
            else
            {
                environmental_equation_model.fImpact = 1.176;
            }
        }

        public void calculateImpact(EnvironmentalEquationModel environmental_equation_model)
        {
            environmental_equation_model.Impact = 10.41 * (1 - (1 - environmental_equation_model.ConfImpactNumber) * (1 - environmental_equation_model.IntegImpactNumber) * (1 - environmental_equation_model.AvailImpactNumber));
        }

        public void calculateTemporalScore(EnvironmentalEquationModel environmental_equation_model)
        {
            double temporalScore = 0;
            temporalScore = environmental_equation_model.BaseScore * environmental_equation_model.ExploitabilityNumber * environmental_equation_model.RemediationLevelNumber * environmental_equation_model.ReportConfidenceNumber;
            environmental_equation_model.TemporalScore = Math.Round(temporalScore, 1);
        }

        public void calculateTemporalScoreForEnvironmentalEquation(EnvironmentalEquationModel environmental_equation_model)
        {
            double temporalScore = 0;
            temporalScore = environmental_equation_model.BaseScoreEE * environmental_equation_model.ExploitabilityNumber * environmental_equation_model.RemediationLevelNumber * environmental_equation_model.ReportConfidenceNumber;
            environmental_equation_model.TemporalScoreEE = Math.Round(temporalScore, 1);
        }

        public void setNumberVariables(EnvironmentalEquationModel environmental_equation_model)
        {
            environmental_equation_model.AccessVectorNumber = AccessVectorValuesDict[environmental_equation_model.AccessVectorString.ToLower()];
            environmental_equation_model.AccessComplexityNumber = AccessComplexityValuesDict[environmental_equation_model.AccessComplexityString.ToLower()];
            environmental_equation_model.AuthenticationNumber = AuthenticationValuesDict[environmental_equation_model.AuthenticationString.ToLower()];
            environmental_equation_model.ConfImpactNumber = ConfImpactValuesDict[environmental_equation_model.ConfImpactString.ToLower()];
            environmental_equation_model.IntegImpactNumber = IntegImpactValuesDict[environmental_equation_model.ConfImpactString.ToLower()];
            environmental_equation_model.AvailImpactNumber = AvailImpactValuesDict[environmental_equation_model.AvailImpactString.ToLower()];

            environmental_equation_model.ExploitabilityNumber = ExploitabilityValuesDict[environmental_equation_model.ExploitabilityString.ToLower()];
            environmental_equation_model.RemediationLevelNumber = RemediationLevelValuesDict[environmental_equation_model.RemediationLevelString.ToLower()];
            environmental_equation_model.ReportConfidenceNumber = ReportConfidenceValuesDict[environmental_equation_model.ReportConfidenceString.ToLower()];

            environmental_equation_model.CollateralDamagePotentialNumber = CollateralDamagePotentialDict[environmental_equation_model.CollateralDamagePotentialString.ToLower()];
            environmental_equation_model.TargetDistributionNumber = TargetDistributionDict[environmental_equation_model.TargetDistributionString.ToLower()];
            environmental_equation_model.ConfReqNumber = ConfReqDict[environmental_equation_model.ConfReqString.ToLower()];
            environmental_equation_model.IntegReqNumber = IntegReqDict[environmental_equation_model.IntegReqString.ToLower()];
            environmental_equation_model.AvailReqNumber = AvailReqDict[environmental_equation_model.AvailReqString.ToLower()];
        }

        private void fillDictionaries()
        {
            FillAccessVectorDict();
            FillAccessComplexityDict();
            FillAuthenticationDict();
            FillConfImpactDict();
            FillIntegImpact();
            FillAvailImpact();
            FillExploitability();
            FillRemediationLevel();
            FillReportConfidence();
            FillCollateralDamagePotential();
            FillTargetDistribution();
            FillConfReq();
            FillIntegReq();
            FillAvailReq();

        }

        private void FillAccessVectorDict()
        {
            AccessVectorValuesDict = new Dictionary<string, double>();
            AccessVectorValuesDict.Add("requires local access", 0.395);
            AccessVectorValuesDict.Add("adjacent network accessible", 0.646);
            AccessVectorValuesDict.Add("network accessible", 1.0);

        }
        private void FillAccessComplexityDict()
        {
            AccessComplexityValuesDict = new Dictionary<string, double>();
            AccessComplexityValuesDict.Add("high", 0.35);
            AccessComplexityValuesDict.Add("medium", 0.61);
            AccessComplexityValuesDict.Add("low", 0.71);
        }
        private void FillAuthenticationDict()
        {
            AuthenticationValuesDict = new Dictionary<string, double>();
            AuthenticationValuesDict.Add("requires multiple instances of authentication", 0.45);
            AuthenticationValuesDict.Add("requires single instance of authentication", 0.56);
            AuthenticationValuesDict.Add("requires no authentication", 0.704);
        }
        private void FillConfImpactDict()
        {
            ConfImpactValuesDict = new Dictionary<string, double>();
            ConfImpactValuesDict.Add("none", 0.0);
            ConfImpactValuesDict.Add("partial", 0.275);
            ConfImpactValuesDict.Add("complete", 0.660);
        }
        private void FillIntegImpact()
        {
            IntegImpactValuesDict = new Dictionary<string, double>();
            IntegImpactValuesDict.Add("none", 0.0);
            IntegImpactValuesDict.Add("partial", 0.275);
            IntegImpactValuesDict.Add("complete", 0.660);
        }
        private void FillAvailImpact()
        {
            AvailImpactValuesDict = new Dictionary<string, double>();
            AvailImpactValuesDict.Add("none", 0.0);
            AvailImpactValuesDict.Add("partial", 0.275);
            AvailImpactValuesDict.Add("complete", 0.660);
        }
        private void FillExploitability()
        {
            ExploitabilityValuesDict = new Dictionary<string, double>();
            ExploitabilityValuesDict.Add("unproven", 0.85);
            ExploitabilityValuesDict.Add("proof-of-concept", 0.9);
            ExploitabilityValuesDict.Add("functional", 0.95);
            ExploitabilityValuesDict.Add("high", 1);
            ExploitabilityValuesDict.Add("not defined", 1);
        }
        private void FillRemediationLevel()
        {
            RemediationLevelValuesDict = new Dictionary<string, double>();
            RemediationLevelValuesDict.Add("official-fix", 0.87);
            RemediationLevelValuesDict.Add("temporary-fix", 0.90);
            RemediationLevelValuesDict.Add("workaround", 0.95);
            RemediationLevelValuesDict.Add("unavailable", 1);
            RemediationLevelValuesDict.Add("not defined", 1);
        }
        private void FillReportConfidence()
        {
            ReportConfidenceValuesDict = new Dictionary<string, double>();
            ReportConfidenceValuesDict.Add("unconfirmed", 0.9);
            ReportConfidenceValuesDict.Add("uncorroborated", 0.95);
            ReportConfidenceValuesDict.Add("confirmed", 1);
            ReportConfidenceValuesDict.Add("not defined", 1);
        }
        private void FillCollateralDamagePotential()
        {
            CollateralDamagePotentialDict = new Dictionary<string, double>();
            CollateralDamagePotentialDict.Add("none", 0);
            CollateralDamagePotentialDict.Add("low", 0.1);
            CollateralDamagePotentialDict.Add("low-medium",0.3);
            CollateralDamagePotentialDict.Add("medium-high", 0.4);
            CollateralDamagePotentialDict.Add("high", 0.5);
            CollateralDamagePotentialDict.Add("not defined",0);
        }
        private void FillTargetDistribution()
        {
            TargetDistributionDict = new Dictionary<string, double>();
            TargetDistributionDict.Add("none", 0);
            TargetDistributionDict.Add("low", 0.25);
            TargetDistributionDict.Add("medium", 0.75);
            TargetDistributionDict.Add("high", 1);
            TargetDistributionDict.Add("not defined", 1);
        }
        private void FillConfReq()
        {
            ConfReqDict = new Dictionary<string, double>();
            ConfReqDict.Add("low", 0.5);
            ConfReqDict.Add("medium", 1);
            ConfReqDict.Add("high", 1.51);
            ConfReqDict.Add("not defined", 1);
        }
        private void FillIntegReq()
        {
            IntegReqDict = new Dictionary<string, double>();
            IntegReqDict.Add("low", 0.5);
            IntegReqDict.Add("medium", 1);
            IntegReqDict.Add("high", 1.51);
            IntegReqDict.Add("not defined", 1);
        }
        private void FillAvailReq()
        {
            AvailReqDict = new Dictionary<string, double>();
            AvailReqDict.Add("low", 0.5);
            AvailReqDict.Add("medium", 1);
            AvailReqDict.Add("high", 1.51);
            AvailReqDict.Add("not defined", 1);
        }


    }
}
