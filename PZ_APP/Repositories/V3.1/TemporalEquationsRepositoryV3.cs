using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PZ_APP.Models.V3._1;

namespace PZ_APP.Repositories.V3._1
{
    public class TemporalEquationsRepositoryV3 : ITemporalEquationsRepositoryV3
    {
        Dictionary<string, double> AttackVectorDict;
        Dictionary<string, double> AttackComplexityDict;
        Dictionary<string, double> PrivilegesRequiredDict;
        Dictionary<string, double> PrivilegesRequiredScopeChangedDict;
        Dictionary<string, double> UserInteractionDict;
        Dictionary<string, double> ScopeDcit;
        Dictionary<string, double> ConfidentialityDict;
        Dictionary<string, double> IntegrityDict;
        Dictionary<string, double> AvailabilityDict;
        Dictionary<string, double> ExploitCodeMaturityDict;
        Dictionary<string, double> RemediationLevelDict;
        Dictionary<string, double> ReportConfidenceDict;

        public TemporalEquationsRepositoryV3()
        {
            fillDictionaries();
        }
        public void calculateAllValues(TemporalEquationsModelV3 temporal_equation_model_v3)
        {
            calculateISS(temporal_equation_model_v3);
            calculateImpact(temporal_equation_model_v3);
            calculeteExploitability(temporal_equation_model_v3);
            calculateBaseScore(temporal_equation_model_v3);
            calculateTemporalScore(temporal_equation_model_v3);
            calculateRatingTemporal(temporal_equation_model_v3);
            calculateRatingBase(temporal_equation_model_v3);
        }
        public void calculateTemporalScore(TemporalEquationsModelV3 temporal_equation_model_v3)
        {
            temporal_equation_model_v3.TemporalScore = Roundtrip(temporal_equation_model_v3.BaseScore * temporal_equation_model_v3.ExploitCodeMaturityNumber
                * temporal_equation_model_v3.RemediationLevelNumber * temporal_equation_model_v3.ReportConfidenceNumber);
        }

        public void calculateBaseScore(TemporalEquationsModelV3 temporal_equation_model_v3)
        {
            if (temporal_equation_model_v3.Impact <= 0)
            {
                temporal_equation_model_v3.BaseScore = 0;
            }
            else if (temporal_equation_model_v3.ScopeNumber == 1)
            {
                temporal_equation_model_v3.BaseScore = Roundtrip(Math.Min(1.08 * (temporal_equation_model_v3.Impact + temporal_equation_model_v3.Exploitability), 10));
            }
            else if (temporal_equation_model_v3.ScopeNumber == 0)
            {
                temporal_equation_model_v3.BaseScore = Roundtrip(Math.Min((temporal_equation_model_v3.Impact + temporal_equation_model_v3.Exploitability), 10));
            }
        }

        public void calculateImpact(TemporalEquationsModelV3 temporal_equation_model_v3)
        {
            if (temporal_equation_model_v3.ScopeNumber == 1)
            {
                temporal_equation_model_v3.Impact = 7.52 * (temporal_equation_model_v3.ISS - 0.029) - 3.25 * Math.Pow((temporal_equation_model_v3.ISS - 0.02), 15);
            }
            else
            {
                temporal_equation_model_v3.Impact = 6.42 * temporal_equation_model_v3.ISS;
            }
        }

        public void calculateISS(TemporalEquationsModelV3 temporal_equation_model_v3)
        {
            temporal_equation_model_v3.ISS = 1 - ((1 - temporal_equation_model_v3.ConfidentialityNumber) * (1 - temporal_equation_model_v3.IntegrityNumber) * (1 - temporal_equation_model_v3.AvailabilityNumber));
        }

        public void calculateRatingTemporal(TemporalEquationsModelV3 temporal_equation_model_v3)
        {
            if (temporal_equation_model_v3.TemporalScore == 0)
            {
                temporal_equation_model_v3.RatingTemporal = "None";
            }
            else if (temporal_equation_model_v3.TemporalScore >= 0.1 && temporal_equation_model_v3.TemporalScore<= 3.9)
            {
                temporal_equation_model_v3.RatingTemporal = "Low";
            }
            else if (temporal_equation_model_v3.TemporalScore >= 4 && temporal_equation_model_v3.TemporalScore<= 6.9)
            {
                temporal_equation_model_v3.RatingTemporal = "Medium";
            }
            else if (temporal_equation_model_v3.TemporalScore >= 7 && temporal_equation_model_v3.TemporalScore<= 8.9)
            {
                temporal_equation_model_v3.RatingTemporal = "High";
            }
            else
            {
                temporal_equation_model_v3.RatingTemporal = "Critical";
            }
        }
        public void calculateRatingBase(TemporalEquationsModelV3 temporal_equation_model_v3)
        {
            if (temporal_equation_model_v3.BaseScore == 0)
            {
                temporal_equation_model_v3.RatingBase = "None";
            }
            else if (temporal_equation_model_v3.BaseScore >= 0.1 && temporal_equation_model_v3.BaseScore <= 3.9)
            {
                temporal_equation_model_v3.RatingBase = "Low";
            }
            else if (temporal_equation_model_v3.BaseScore >= 4 && temporal_equation_model_v3.BaseScore <= 6.9)
            {
                temporal_equation_model_v3.RatingBase = "Medium";
            }
            else if (temporal_equation_model_v3.BaseScore >= 7 && temporal_equation_model_v3.BaseScore <= 8.9)
            {
                temporal_equation_model_v3.RatingBase = "High";
            }
            else
            {
                temporal_equation_model_v3.RatingBase = "Critical";
            }
        }

        public void calculeteExploitability(TemporalEquationsModelV3 temporal_equation_model_v3)
        {
            temporal_equation_model_v3.Exploitability = 8.22 * temporal_equation_model_v3.AttackVectorNumber * temporal_equation_model_v3.AttackComplexityNumber
                * temporal_equation_model_v3.PrivilegesRequiredNumber * temporal_equation_model_v3.UserInteractionNumber;
        }

        public void setNumberVariables(TemporalEquationsModelV3 temporal_equation_model_v3)
        {
            temporal_equation_model_v3.AttackVectorNumber = AttackVectorDict[temporal_equation_model_v3.AttackVectorString.ToLower()];
            temporal_equation_model_v3.AttackComplexityNumber = AttackComplexityDict[temporal_equation_model_v3.AttackComplexityString.ToLower()];
            temporal_equation_model_v3.UserInteractionNumber = UserInteractionDict[temporal_equation_model_v3.UserInteractionString.ToLower()];
            temporal_equation_model_v3.ScopeNumber = ScopeDcit[temporal_equation_model_v3.ScopeString.ToLower()];
            if (temporal_equation_model_v3.ScopeNumber == 1)
            {
                temporal_equation_model_v3.PrivilegesRequiredNumber = PrivilegesRequiredScopeChangedDict[temporal_equation_model_v3.PrivilegesRequiredString.ToLower()];
            }
            else
            {
                temporal_equation_model_v3.PrivilegesRequiredNumber = PrivilegesRequiredDict[temporal_equation_model_v3.PrivilegesRequiredString.ToLower()];
            }
            temporal_equation_model_v3.ConfidentialityNumber = ConfidentialityDict[temporal_equation_model_v3.ConfidentialityString.ToLower()];
            temporal_equation_model_v3.IntegrityNumber = IntegrityDict[temporal_equation_model_v3.IntegrityString.ToLower()];
            temporal_equation_model_v3.AvailabilityNumber = AvailabilityDict[temporal_equation_model_v3.AvailabilityString.ToLower()];
            temporal_equation_model_v3.ExploitCodeMaturityNumber = ExploitCodeMaturityDict[temporal_equation_model_v3.ExploitCodeMaturityString.ToLower()];
            temporal_equation_model_v3.RemediationLevelNumber = RemediationLevelDict[temporal_equation_model_v3.RemediationLevelString.ToLower()];
            temporal_equation_model_v3.ReportConfidenceNumber = ReportConfidenceDict[temporal_equation_model_v3.ReportConfidenceString.ToLower()];
        }

        private void fillDictionaries()
        {
            fillAttackComplexityDict();
            fillAttackVectorDict();
            fillAvailabilityDict();
            fillConfidentialityDict();
            fillIntegrityDict();
            fillPrivilegesRequiredDict();
            fillPrivilegesRequiredScopeChangedDict();
            fillScopeDict();
            fillUserInteractionDict();
            fillExploitCodeMaturityDict();
            fillRemediationLevelDict();
            fillReportConfidenceDict();
        }

        private void fillAttackVectorDict()
        {
            AttackVectorDict = new Dictionary<string, double>();
            AttackVectorDict.Add("network", 0.85);
            AttackVectorDict.Add("adjacent", 0.62);
            AttackVectorDict.Add("local", 0.55);
            AttackVectorDict.Add("physical", 0.2);


        }
        private void fillAttackComplexityDict()
        {
            AttackComplexityDict = new Dictionary<string, double>();
            AttackComplexityDict.Add("low", 0.77);
            AttackComplexityDict.Add("high", 0.44);
        }
        private void fillPrivilegesRequiredDict()
        {
            PrivilegesRequiredDict = new Dictionary<string, double>();
            PrivilegesRequiredDict.Add("none", 0.85);
            PrivilegesRequiredDict.Add("low", 0.62);
            PrivilegesRequiredDict.Add("high", 0.27);

        }
        private void fillPrivilegesRequiredScopeChangedDict()
        {
            PrivilegesRequiredScopeChangedDict = new Dictionary<string, double>();
            PrivilegesRequiredScopeChangedDict.Add("none", 0.85);
            PrivilegesRequiredScopeChangedDict.Add("low", 0.68);
            PrivilegesRequiredScopeChangedDict.Add("high", 0.5);
        }
        private void fillUserInteractionDict()
        {
            UserInteractionDict = new Dictionary<string, double>();
            UserInteractionDict.Add("none", 0.85);
            UserInteractionDict.Add("required", 0.62);
        }
        private void fillScopeDict()
        {
            ScopeDcit = new Dictionary<string, double>();
            ScopeDcit.Add("changed", 1);
            ScopeDcit.Add("unchanged", 0);
        }
        private void fillConfidentialityDict()
        {
            ConfidentialityDict = new Dictionary<string, double>();
            ConfidentialityDict.Add("none", 0);
            ConfidentialityDict.Add("high", 0.56);
            ConfidentialityDict.Add("low", 0.22);

        }
        private void fillIntegrityDict()
        {
            IntegrityDict = new Dictionary<string, double>();
            IntegrityDict.Add("none", 0);
            IntegrityDict.Add("high", 0.56);
            IntegrityDict.Add("low", 0.22);

        }
        private void fillAvailabilityDict()
        {
            AvailabilityDict = new Dictionary<string, double>();
            AvailabilityDict.Add("none", 0);
            AvailabilityDict.Add("high", 0.56);
            AvailabilityDict.Add("low", 0.22);

        }
        private void fillExploitCodeMaturityDict()
        {
            ExploitCodeMaturityDict = new Dictionary<string, double>();
            ExploitCodeMaturityDict.Add("not defined",1);
            ExploitCodeMaturityDict.Add("high",1);
            ExploitCodeMaturityDict.Add("functional",0.97);
            ExploitCodeMaturityDict.Add("proof-of-concept",0.94);
            ExploitCodeMaturityDict.Add("unproven",0.91);
            

        }
        private void fillRemediationLevelDict()
        {
            RemediationLevelDict = new Dictionary<string, double>();
            RemediationLevelDict.Add("not defined", 1);
            RemediationLevelDict.Add("unavailable",1);
            RemediationLevelDict.Add("workaround",0.97);
            RemediationLevelDict.Add("temporary fix",0.96);
            RemediationLevelDict.Add("official fix", 0.95);

        }
        private void fillReportConfidenceDict()
        {
            ReportConfidenceDict = new Dictionary<string, double>();
            ReportConfidenceDict.Add("not defined",1);
            ReportConfidenceDict.Add("confirmed",1);
            ReportConfidenceDict.Add("reasonable",0.96);
            ReportConfidenceDict.Add("unknown",0.92);

        }
        private double Roundtrip(double values)
        {
            double calculated = 0;
            int valChang = (int)Math.Round(values * 100000);
            if (valChang % 10000 == 0)
            {
                calculated = valChang / 100000.0;
                return calculated;
            }
            else
            {
                calculated = (double)Math.Floor((valChang / 10000.0) + 1) / 10;
                return calculated;
            }
        }


    }
}
