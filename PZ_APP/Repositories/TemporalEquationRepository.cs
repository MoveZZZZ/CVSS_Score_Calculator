using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PZ_APP.Models;

namespace PZ_APP.Repositories
{
    public class TemporalEquationRepository : ITemporalEquationRepository
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

        public TemporalEquationRepository()
        {
            fillDictionaries();
        }

        public void calculateAllValues(TemporalEquationModel temporal_equation_model)
        {
            calculateImpact(temporal_equation_model);
            calculateFImpakt(temporal_equation_model);
            calculateExploitability(temporal_equation_model);
            calculateBaseScore(temporal_equation_model);
            calculateTemporalScore(temporal_equation_model);
        }

        public void calculateBaseScore(TemporalEquationModel temporal_equation_model)
        {
            double baseScore = 0;
            baseScore = ((0.6 * temporal_equation_model.Impact) + (0.4 * temporal_equation_model.ExploitabilityBS) - 1.5) * temporal_equation_model.fImpact;
            temporal_equation_model.BaseScore = Math.Round(baseScore, 1);
        }

        public void calculateExploitability(TemporalEquationModel temporal_equation_model)
        {
            temporal_equation_model.ExploitabilityBS = 20 * temporal_equation_model.AccessVectorNumber * temporal_equation_model.AccessComplexityNumber * temporal_equation_model.AuthenticationNumber;
        }

        public void calculateFImpakt(TemporalEquationModel temporal_equation_model)
        {
            if (temporal_equation_model.Impact == 0)
            {
                temporal_equation_model.fImpact = 0;
            }
            else
            {
                temporal_equation_model.fImpact = 1.176;
            }
        }

        public void calculateImpact(TemporalEquationModel temporal_equation_model)
        {
            temporal_equation_model.Impact = 10.41 * (1 - (1 - temporal_equation_model.ConfImpactNumber) * (1 - temporal_equation_model.IntegImpactNumber) * (1 - temporal_equation_model.AvailImpactNumber));
        }

        public void calculateTemporalScore(TemporalEquationModel temporal_equation_model)
        {
            double temporalScore = 0;
            temporalScore = temporal_equation_model.BaseScore * temporal_equation_model.ExploitabilityNumber * temporal_equation_model.RemediationLevelNumber * temporal_equation_model.ReportConfidenceNumber;
            temporal_equation_model.TemporalScore = Math.Round(temporalScore, 1);
        }

        public void setNumberVariables(TemporalEquationModel temporal_equation_model)
        {
            temporal_equation_model.AccessVectorNumber = AccessVectorValuesDict[temporal_equation_model.AccessVectorString.ToLower()];
            temporal_equation_model.AccessComplexityNumber = AccessComplexityValuesDict[temporal_equation_model.AccessComplexityString.ToLower()];
            temporal_equation_model.AuthenticationNumber = AuthenticationValuesDict[temporal_equation_model.AuthenticationString.ToLower()];
            temporal_equation_model.ConfImpactNumber = ConfImpactValuesDict[temporal_equation_model.ConfImpactString.ToLower()];
            temporal_equation_model.IntegImpactNumber = IntegImpactValuesDict[temporal_equation_model.IntegImpactString.ToLower()];
            temporal_equation_model.AvailImpactNumber = AvailImpactValuesDict[temporal_equation_model.AvailImpactString.ToLower()];

            temporal_equation_model.ExploitabilityNumber = ExploitabilityValuesDict[temporal_equation_model.ExploitabilityString.ToLower()];
            temporal_equation_model.RemediationLevelNumber = RemediationLevelValuesDict[temporal_equation_model.RemediationLevelString.ToLower()];
            temporal_equation_model.ReportConfidenceNumber = ReportConfidenceValuesDict[temporal_equation_model.ReportConfidenceString.ToLower()];
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
    }
}
