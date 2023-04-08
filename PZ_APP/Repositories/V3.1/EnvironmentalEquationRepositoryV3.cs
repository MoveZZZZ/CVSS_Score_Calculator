using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PZ_APP.Models.V3._1;

namespace PZ_APP.Repositories.V3._1
{
    public class EnvironmentalEquationRepositoryV3 : IEnvironmentalEquationRepositoryV3
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
        Dictionary<string, double> ConfidentialityRequirementDict;
        Dictionary<string, double> IntegrityRequirementDict;
        Dictionary<string, double> AvailabilityRequirementDict;
        Dictionary<string, double> ModifiedAttackVectorDict;
        Dictionary<string, double> ModifiedAttackComplexityDict;
        Dictionary<string, double> ModifiedPrivilegesRequiredDict;
        Dictionary<string, double> ModifiedPrivilegesRequiredScopeChangedDict;
        Dictionary<string, double> ModifiedUserInteractionDict;
        Dictionary<string, double> ModifiedScopeDict;
        Dictionary<string, double> ModifiedConfidentialityDict;
        Dictionary<string, double> ModifiedIntegrityDict;
        Dictionary<string, double> ModifiedAvailabilityDict;

        public EnvironmentalEquationRepositoryV3()
        {
            fillDictionaries();
        }

        public void calculateAllValues(EnvironmentalEquationModelV3 environmental_equation_model_v3)
        {
            checkDefinedVariables(environmental_equation_model_v3);
            calculateISS(environmental_equation_model_v3);
            calculateMISS(environmental_equation_model_v3);
            calculateImpact(environmental_equation_model_v3);
            calculateModifiedImpact(environmental_equation_model_v3);
            calculeteExploitability(environmental_equation_model_v3);
            calculeteModifiedExploitability(environmental_equation_model_v3);
            calculateBaseScore(environmental_equation_model_v3);
            calculateTemporalScore(environmental_equation_model_v3);
            calculateEnvironmentalScore(environmental_equation_model_v3);
            calculateRatingTemporal(environmental_equation_model_v3);
            calculateRatingBase(environmental_equation_model_v3);
            calculateRatingEnvironmental(environmental_equation_model_v3);

        }
        public void checkDefinedVariables(EnvironmentalEquationModelV3 environmental_equation_model_v3)
        {
            if (environmental_equation_model_v3.ModifiedAttackComplexityNumber == -1)
                environmental_equation_model_v3.ModifiedAttackComplexityNumber = environmental_equation_model_v3.AttackComplexityNumber;

            if (environmental_equation_model_v3.ModifiedAttackVectorNumber == -1)
                environmental_equation_model_v3.ModifiedAttackVectorNumber = environmental_equation_model_v3.AttackVectorNumber;

            if (environmental_equation_model_v3.ModifiedAvailabilityNumber == -1)
                environmental_equation_model_v3.ModifiedAvailabilityNumber = environmental_equation_model_v3.AvailabilityNumber;

            if (environmental_equation_model_v3.ModifiedConfidentialityNumber == -1)
                environmental_equation_model_v3.ModifiedConfidentialityNumber = environmental_equation_model_v3.ConfidentialityNumber;

            if (environmental_equation_model_v3.ModifiedIntegrityNumber == -1)
                environmental_equation_model_v3.ModifiedIntegrityNumber = environmental_equation_model_v3.IntegrityNumber;

            if (environmental_equation_model_v3.ModifiedPrivilegesRequiredNumber == -1)
                environmental_equation_model_v3.ModifiedPrivilegesRequiredNumber = environmental_equation_model_v3.PrivilegesRequiredNumber;

            if (environmental_equation_model_v3.ModifiedScopeNumber == -1)
                environmental_equation_model_v3.ModifiedScopeNumber = environmental_equation_model_v3.ScopeNumber;

            if (environmental_equation_model_v3.ModifiedUserInteractionNumber == -1)
                environmental_equation_model_v3.ModifiedUserInteractionNumber = environmental_equation_model_v3.UserInteractionNumber;
        }

        public void calculateBaseScore(EnvironmentalEquationModelV3 environmental_equation_model_v3)
        {
            if (environmental_equation_model_v3.Impact <= 0)
            {
                environmental_equation_model_v3.BaseScore = 0;
            }
            else if (environmental_equation_model_v3.ScopeNumber == 1)
            {
                environmental_equation_model_v3.BaseScore = Roundtrip(Math.Min(1.08 * (environmental_equation_model_v3.Impact + environmental_equation_model_v3.Exploitability), 10));
            }
            else if (environmental_equation_model_v3.ScopeNumber == 0)
            {
                environmental_equation_model_v3.BaseScore = Roundtrip(Math.Min((environmental_equation_model_v3.Impact + environmental_equation_model_v3.Exploitability), 10));
            }
        }

        public void calculateEnvironmentalScore(EnvironmentalEquationModelV3 environmental_equation_model_v3)
        {
            if(environmental_equation_model_v3.ModifiedImpact<=0)
            {
                environmental_equation_model_v3.EnvironmentalScore = 0;
            }
            else if(environmental_equation_model_v3.ModifiedScopeNumber==1)
            {
                environmental_equation_model_v3.EnvironmentalScore =
                    Roundtrip(
                        Roundtrip(
                        Math.Min(1.08 * (environmental_equation_model_v3.ModifiedImpact + environmental_equation_model_v3.ModifiedExploitability), 10)
                        * environmental_equation_model_v3.ExploitCodeMaturityNumber * environmental_equation_model_v3.RemediationLevelNumber * environmental_equation_model_v3.ReportConfidenceNumber)
                        );
            }
            else if(environmental_equation_model_v3.ModifiedScopeNumber==0)
            {
                environmental_equation_model_v3.EnvironmentalScore =
                    Roundtrip(
                        Roundtrip(
                        Math.Min((environmental_equation_model_v3.ModifiedImpact + environmental_equation_model_v3.ModifiedExploitability), 10)
                        * environmental_equation_model_v3.ExploitCodeMaturityNumber * environmental_equation_model_v3.RemediationLevelNumber * environmental_equation_model_v3.ReportConfidenceNumber)
                        );
            }
        }

        public void calculateImpact(EnvironmentalEquationModelV3 environmental_equation_model_v3)
        {
            if (environmental_equation_model_v3.ScopeNumber == 1)
            {
                environmental_equation_model_v3.Impact = 7.52 * (environmental_equation_model_v3.ISS - 0.029) - 3.25 * Math.Pow((environmental_equation_model_v3.ISS - 0.02), 15);
            }
            else
            {
                environmental_equation_model_v3.Impact = 6.42 * environmental_equation_model_v3.ISS;
            }
        }
        public void calculateModifiedImpact(EnvironmentalEquationModelV3 environmental_equation_model_v3)
        {
            if (environmental_equation_model_v3.ModifiedScopeNumber == 1)
            {
                environmental_equation_model_v3.ModifiedImpact = 7.52 * (environmental_equation_model_v3.MISS - 0.029) - 3.25 * Math.Pow((environmental_equation_model_v3.MISS*0.9731-0.02), 13);
            }
            else
            {
                environmental_equation_model_v3.Impact = 6.42 * environmental_equation_model_v3.MISS;
            }
        }

        public void calculateISS(EnvironmentalEquationModelV3 environmental_equation_model_v3)
        {
            environmental_equation_model_v3.ISS = 1 - ((1 - environmental_equation_model_v3.ConfidentialityNumber) * (1 - environmental_equation_model_v3.IntegrityNumber) * (1 - environmental_equation_model_v3.AvailabilityNumber));
        }
        public void calculateMISS(EnvironmentalEquationModelV3 environmental_equation_model_v3)
        {
            environmental_equation_model_v3.MISS = Math.Min(1 - (
                (1 - environmental_equation_model_v3.ConfidentialityRequirementNumber * environmental_equation_model_v3.ModifiedConfidentialityNumber) *
                (1 - environmental_equation_model_v3.IntegrityRequirementNumber * environmental_equation_model_v3.ModifiedIntegrityNumber) *
                (1 - environmental_equation_model_v3.AvailabilityRequirementNumber * environmental_equation_model_v3.ModifiedAvailabilityNumber)
                ), 0.915);
        }

        public void calculateRatingBase(EnvironmentalEquationModelV3 environmental_equation_model_v3)
        {
            if (environmental_equation_model_v3.BaseScore == 0)
            {
                environmental_equation_model_v3.RatingBase = "None";
            }
            else if (environmental_equation_model_v3.BaseScore >= 0.1 && environmental_equation_model_v3.BaseScore <= 3.9)
            {
                environmental_equation_model_v3.RatingBase = "Low";
            }
            else if (environmental_equation_model_v3.BaseScore >= 4 && environmental_equation_model_v3.BaseScore <= 6.9)
            {
                environmental_equation_model_v3.RatingBase = "Medium";
            }
            else if (environmental_equation_model_v3.BaseScore >= 7 && environmental_equation_model_v3.BaseScore <= 8.9)
            {
                environmental_equation_model_v3.RatingBase = "High";
            }
            else
            {
                environmental_equation_model_v3.RatingBase = "Critical";
            }
        }

        public void calculateRatingTemporal(EnvironmentalEquationModelV3 environmental_equation_model_v3)
        {
            if (environmental_equation_model_v3.TemporalScore == 0)
            {
                environmental_equation_model_v3.RatingTemporal= "None";
            }
            else if (environmental_equation_model_v3.TemporalScore >= 0.1 && environmental_equation_model_v3.TemporalScore <= 3.9)
            {
                environmental_equation_model_v3.RatingTemporal = "Low";
            }
            else if (environmental_equation_model_v3.TemporalScore >= 4 && environmental_equation_model_v3.TemporalScore <= 6.9)
            {
                environmental_equation_model_v3.RatingTemporal = "Medium";
            }
            else if (environmental_equation_model_v3.TemporalScore >= 7 && environmental_equation_model_v3.TemporalScore <= 8.9)
            {
                environmental_equation_model_v3.RatingTemporal = "High";
            }
            else
            {
                environmental_equation_model_v3.RatingTemporal = "Critical";
            }
        }
        public void calculateRatingEnvironmental(EnvironmentalEquationModelV3 environmental_equation_model_v3)
        {
            if (environmental_equation_model_v3.EnvironmentalScore == 0)
            {
                environmental_equation_model_v3.RatingEnvironmental= "None";
            }
            else if (environmental_equation_model_v3.EnvironmentalScore >= 0.1 && environmental_equation_model_v3.EnvironmentalScore <= 3.9)
            {
                environmental_equation_model_v3.RatingEnvironmental = "Low";
            }
            else if (environmental_equation_model_v3.EnvironmentalScore >= 4 && environmental_equation_model_v3.EnvironmentalScore <= 6.9)
            {
                environmental_equation_model_v3.RatingEnvironmental = "Medium";
            }
            else if (environmental_equation_model_v3.EnvironmentalScore >= 7 && environmental_equation_model_v3.EnvironmentalScore <= 8.9)
            {
                environmental_equation_model_v3.RatingEnvironmental = "High";
            }
            else
            {
                environmental_equation_model_v3.RatingEnvironmental = "Critical";
            }
        }

        public void calculateTemporalScore(EnvironmentalEquationModelV3 environmental_equation_model_v3)
        {
            environmental_equation_model_v3.TemporalScore = Roundtrip(environmental_equation_model_v3.BaseScore * environmental_equation_model_v3.ExploitCodeMaturityNumber
               * environmental_equation_model_v3.RemediationLevelNumber * environmental_equation_model_v3.ReportConfidenceNumber);
        }

        public void calculeteExploitability(EnvironmentalEquationModelV3 environmental_equation_model_v3)
        {
            environmental_equation_model_v3.Exploitability = 8.22 * environmental_equation_model_v3.AttackVectorNumber * environmental_equation_model_v3.AttackComplexityNumber
               * environmental_equation_model_v3.PrivilegesRequiredNumber * environmental_equation_model_v3.UserInteractionNumber;
        }
        public void calculeteModifiedExploitability(EnvironmentalEquationModelV3 environmental_equation_model_v3)
        {
            environmental_equation_model_v3.ModifiedExploitability = 8.22 * environmental_equation_model_v3.ModifiedAttackVectorNumber* environmental_equation_model_v3.ModifiedAttackComplexityNumber
                * environmental_equation_model_v3.ModifiedPrivilegesRequiredNumber * environmental_equation_model_v3.ModifiedUserInteractionNumber;
        }

        public void setNumberVariables(EnvironmentalEquationModelV3 environmental_equation_model_v3)
        {
            environmental_equation_model_v3.AttackVectorNumber = AttackVectorDict[environmental_equation_model_v3.AttackVectorString.ToLower()];
            environmental_equation_model_v3.AttackComplexityNumber = AttackComplexityDict[environmental_equation_model_v3.AttackComplexityString.ToLower()];
            environmental_equation_model_v3.UserInteractionNumber = UserInteractionDict[environmental_equation_model_v3.UserInteractionString.ToLower()];
            environmental_equation_model_v3.ScopeNumber = ScopeDcit[environmental_equation_model_v3.ScopeString.ToLower()];
            if (environmental_equation_model_v3.ScopeNumber == 1)
            {
                environmental_equation_model_v3.PrivilegesRequiredNumber = PrivilegesRequiredScopeChangedDict[environmental_equation_model_v3.PrivilegesRequiredString.ToLower()];
            }
            else
            {
                environmental_equation_model_v3.PrivilegesRequiredNumber = PrivilegesRequiredDict[environmental_equation_model_v3.PrivilegesRequiredString.ToLower()];
            }
            environmental_equation_model_v3.ConfidentialityNumber = ConfidentialityDict[environmental_equation_model_v3.ConfidentialityString.ToLower()];
            environmental_equation_model_v3.IntegrityNumber = IntegrityDict[environmental_equation_model_v3.IntegrityString.ToLower()];
            environmental_equation_model_v3.AvailabilityNumber = AvailabilityDict[environmental_equation_model_v3.AvailabilityString.ToLower()];
            environmental_equation_model_v3.ExploitCodeMaturityNumber = ExploitCodeMaturityDict[environmental_equation_model_v3.ExploitCodeMaturityString.ToLower()];
            environmental_equation_model_v3.RemediationLevelNumber = RemediationLevelDict[environmental_equation_model_v3.RemediationLevelString.ToLower()];
            environmental_equation_model_v3.ReportConfidenceNumber = ReportConfidenceDict[environmental_equation_model_v3.ReportConfidenceString.ToLower()];

            environmental_equation_model_v3.ModifiedAttackVectorNumber = ModifiedAttackVectorDict[environmental_equation_model_v3.ModifiedAttackVectorString.ToLower()];
            environmental_equation_model_v3.ModifiedAttackComplexityNumber = ModifiedAttackComplexityDict[environmental_equation_model_v3.ModifiedAttackComplexityString.ToLower()];
            environmental_equation_model_v3.ModifiedUserInteractionNumber = ModifiedUserInteractionDict[environmental_equation_model_v3.ModifiedUserInteractionString.ToLower()];
            environmental_equation_model_v3.ModifiedScopeNumber = ModifiedScopeDict[environmental_equation_model_v3.ModifiedScopeString.ToLower()];
            if(environmental_equation_model_v3.ModifiedScopeNumber==1)
            {
                environmental_equation_model_v3.ModifiedPrivilegesRequiredNumber = ModifiedPrivilegesRequiredScopeChangedDict[environmental_equation_model_v3.ModifiedPrivilegesRequiredString.ToLower()];
            }
            else
            {
                environmental_equation_model_v3.ModifiedPrivilegesRequiredNumber = ModifiedPrivilegesRequiredDict[environmental_equation_model_v3.ModifiedPrivilegesRequiredString.ToLower()];
            }
            environmental_equation_model_v3.ModifiedConfidentialityNumber = ModifiedConfidentialityDict[environmental_equation_model_v3.ModifiedConfidentialityString.ToLower()];
            environmental_equation_model_v3.ModifiedIntegrityNumber = ModifiedIntegrityDict[environmental_equation_model_v3.ModifiedIntegrityString.ToLower()];
            environmental_equation_model_v3.ModifiedAvailabilityNumber = ModifiedAvailabilityDict[environmental_equation_model_v3.ModifiedAvailabilityString.ToLower()];
            environmental_equation_model_v3.ConfidentialityRequirementNumber = ConfidentialityRequirementDict[environmental_equation_model_v3.ConfidentialityRequirementString.ToLower()];
            environmental_equation_model_v3.IntegrityRequirementNumber = ConfidentialityRequirementDict[environmental_equation_model_v3.IntegrityRequirementString.ToLower()];
            environmental_equation_model_v3.AvailabilityRequirementNumber = AvailabilityRequirementDict[environmental_equation_model_v3.AvailabilityRequirementString.ToLower()];

           

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
            fillConfidentialityRequirementDict();
            fillIntegrityRequirementDict();
            fillAvailabilityRequirementDict();
            fillModifiedAttackVectorDict();
            fillModifiedAttackComplexityDict();
            fillModifiedAvailabilityDict();
            fillModifiedConfidentialityDict();
            fillModifiedIntegrityDict();
            fillModifiedPrivilegesRequiredDict();
            fillModifiedPrivilegesRequiredScopeChangedDict();
            fillModifiedScopeDict();
            fillModifiedUserInteractionDict();
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
            ExploitCodeMaturityDict.Add("not defined", 1);
            ExploitCodeMaturityDict.Add("high", 1);
            ExploitCodeMaturityDict.Add("functional", 0.97);
            ExploitCodeMaturityDict.Add("proof-of-concept", 0.94);
            ExploitCodeMaturityDict.Add("unproven", 0.91);


        }
        private void fillRemediationLevelDict()
        {
            RemediationLevelDict = new Dictionary<string, double>();
            RemediationLevelDict.Add("not defined", 1);
            RemediationLevelDict.Add("unavailable", 1);
            RemediationLevelDict.Add("workaround", 0.97);
            RemediationLevelDict.Add("temporary fix", 0.96);
            RemediationLevelDict.Add("official fix", 0.95);

        }
        private void fillReportConfidenceDict()
        {
            ReportConfidenceDict = new Dictionary<string, double>();
            ReportConfidenceDict.Add("not defined", 1);
            ReportConfidenceDict.Add("confirmed", 1);
            ReportConfidenceDict.Add("reasonable", 0.96);
            ReportConfidenceDict.Add("unknown", 0.92);

        }
        private void fillConfidentialityRequirementDict()
        {
            ConfidentialityRequirementDict = new Dictionary<string, double>();
            ConfidentialityRequirementDict.Add("not defined",1);
            ConfidentialityRequirementDict.Add("high",1.5);
            ConfidentialityRequirementDict.Add("medium",1);
            ConfidentialityRequirementDict.Add("low",0.5);
        }
        private void fillIntegrityRequirementDict()
        {
            IntegrityRequirementDict = new Dictionary<string, double>();
            IntegrityRequirementDict.Add("not defined", 1);
            IntegrityRequirementDict.Add("high", 1.5);
            IntegrityRequirementDict.Add("medium", 1);
            IntegrityRequirementDict.Add("low", 0.5);
        }
        private void fillAvailabilityRequirementDict()
        {
            AvailabilityRequirementDict = new Dictionary<string, double>();
            AvailabilityRequirementDict.Add("not defined", 1);
            AvailabilityRequirementDict.Add("high", 1.5);
            AvailabilityRequirementDict.Add("medium", 1);
            AvailabilityRequirementDict.Add("low", 0.5);
        }
        private void fillModifiedAttackVectorDict()
        {
            ModifiedAttackVectorDict = new Dictionary<string, double>();
            ModifiedAttackVectorDict.Add("network", 0.85);
            ModifiedAttackVectorDict.Add("adjacent", 0.62);
            ModifiedAttackVectorDict.Add("local", 0.55);
            ModifiedAttackVectorDict.Add("physical", 0.2);
            ModifiedAttackVectorDict.Add("not defined", -1);
        }
        private void fillModifiedAttackComplexityDict()
        {
            ModifiedAttackComplexityDict = new Dictionary<string, double>();
            ModifiedAttackComplexityDict.Add("low", 0.77);
            ModifiedAttackComplexityDict.Add("high", 0.44);
            ModifiedAttackComplexityDict.Add("not defined", -1);
        }
        private void fillModifiedPrivilegesRequiredDict()
        {
            ModifiedPrivilegesRequiredDict = new Dictionary<string, double>();
            ModifiedPrivilegesRequiredDict.Add("none", 0.85);
            ModifiedPrivilegesRequiredDict.Add("low", 0.62);
            ModifiedPrivilegesRequiredDict.Add("high", 0.27);
            ModifiedPrivilegesRequiredDict.Add("not defined", -1);
        }
        private void fillModifiedPrivilegesRequiredScopeChangedDict()
        {
            ModifiedPrivilegesRequiredScopeChangedDict = new Dictionary<string, double>();
            ModifiedPrivilegesRequiredScopeChangedDict.Add("none", 0.85);
            ModifiedPrivilegesRequiredScopeChangedDict.Add("low", 0.68);
            ModifiedPrivilegesRequiredScopeChangedDict.Add("high", 0.5);
            ModifiedPrivilegesRequiredScopeChangedDict.Add("not defined", -1);
        }
        private void fillModifiedUserInteractionDict()
        {
            ModifiedUserInteractionDict = new Dictionary<string, double>();
            ModifiedUserInteractionDict.Add("none", 0.85);
            ModifiedUserInteractionDict.Add("required", 0.62);
            ModifiedUserInteractionDict.Add("not defined", -1);
        }
        private void fillModifiedScopeDict()
        {
            ModifiedScopeDict = new Dictionary<string, double>();
            ModifiedScopeDict.Add("changed", 1);
            ModifiedScopeDict.Add("unchanged", 0);
            ModifiedScopeDict.Add("not defined", -1);
        }
        private void fillModifiedConfidentialityDict()
        {
            ModifiedConfidentialityDict = new Dictionary<string, double>();
            ModifiedConfidentialityDict.Add("none", 0);
            ModifiedConfidentialityDict.Add("high", 0.56);
            ModifiedConfidentialityDict.Add("low", 0.22);
            ModifiedConfidentialityDict.Add("not defined", -1);
        }
        private void fillModifiedIntegrityDict()
        {
            ModifiedIntegrityDict = new Dictionary<string, double>();
            ModifiedIntegrityDict.Add("none", 0);
            ModifiedIntegrityDict.Add("high", 0.56);
            ModifiedIntegrityDict.Add("low", 0.22);
            ModifiedIntegrityDict.Add("not defined", -1);
        }
        private void fillModifiedAvailabilityDict()
        {
            ModifiedAvailabilityDict = new Dictionary<string, double>();
            ModifiedAvailabilityDict.Add("none", 0);
            ModifiedAvailabilityDict.Add("high", 0.56);
            ModifiedAvailabilityDict.Add("low", 0.22);
            ModifiedAvailabilityDict.Add("not defined", -1);
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
