using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PZ_APP.Models.V3._1;

namespace PZ_APP.Repositories.V3._1
{
    public class BaseEquationsRepositoryV3 : IBaseEquationsRepositoryV3
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

        public BaseEquationsRepositoryV3()
        {
            fillDictionaries();
        }



        public void calculateAllValues(BaseEquationsModelV3 base_equation_model_v3)
        {
            calculateISS(base_equation_model_v3);
            calculateImpact(base_equation_model_v3);
            calculeteExploitability(base_equation_model_v3);
            calculateBaseScore(base_equation_model_v3);
            calculateRating(base_equation_model_v3);
        }
        public void calculateRating(BaseEquationsModelV3 base_equation_model_v3)
        {
            if(base_equation_model_v3.BaseScore==0)
            {
                base_equation_model_v3.Rating = "None";
            }
            else if(base_equation_model_v3.BaseScore >=0.1 && base_equation_model_v3.BaseScore <= 3.9)
            {
                base_equation_model_v3.Rating = "Low";
            }
            else if(base_equation_model_v3.BaseScore >=4 && base_equation_model_v3.BaseScore<=6.9)
            {
                base_equation_model_v3.Rating = "Medium";
            }
            else if(base_equation_model_v3.BaseScore>=7 && base_equation_model_v3.BaseScore <=8.9)
            {
                base_equation_model_v3.Rating = "High";
            }
            else
            {
                base_equation_model_v3.Rating = "Critical";
            }
        }
        public void calculateBaseScore(BaseEquationsModelV3 base_equation_model_v3)
        {
            if(base_equation_model_v3.Impact<=0)
            {
                base_equation_model_v3.BaseScore = 0;
            }
            else if(base_equation_model_v3.ScopeNumber==1)
            {
                base_equation_model_v3.BaseScore = Roundtrip(Math.Min(1.08*(base_equation_model_v3.Impact + base_equation_model_v3.Exploitability), 10));
            }
            else if(base_equation_model_v3.ScopeNumber==0)
            {
                base_equation_model_v3.BaseScore = Roundtrip(Math.Min((base_equation_model_v3.Impact + base_equation_model_v3.Exploitability), 10));
            }
        }
        public void calculateISS(BaseEquationsModelV3 base_equation_model_v3)
        {
            base_equation_model_v3.ISS = 1 - ((1-base_equation_model_v3.ConfidentialityNumber)*(1-base_equation_model_v3.IntegrityNumber)*(1-base_equation_model_v3.AvailabilityNumber));
        }
        public void calculateImpact(BaseEquationsModelV3 base_equation_model_v3)
        {
            if(base_equation_model_v3.ScopeNumber==1)
            {
                base_equation_model_v3.Impact = 7.52 * (base_equation_model_v3.ISS - 0.029) - 3.25 * Math.Pow((base_equation_model_v3.ISS - 0.02), 15);
            }
            else
            {
                base_equation_model_v3.Impact = 6.42 * base_equation_model_v3.ISS;
            }
        }

        public void calculeteExploitability(BaseEquationsModelV3 base_equation_model_v3)
        {
            base_equation_model_v3.Exploitability = 8.22 * base_equation_model_v3.AttackVectorNumber * base_equation_model_v3.AttackComplexityNumber
                * base_equation_model_v3.PrivilegesRequiredNumber * base_equation_model_v3.UserInteractionNumber;
        }

        public void setNumberVariables(BaseEquationsModelV3 base_equation_model_v3)
        {
            base_equation_model_v3.AttackVectorNumber = AttackVectorDict[base_equation_model_v3.AttackVectorString.ToLower()];
            base_equation_model_v3.AttackComplexityNumber = AttackComplexityDict[base_equation_model_v3.AttackComplexityString.ToLower()];
            base_equation_model_v3.UserInteractionNumber = UserInteractionDict[base_equation_model_v3.UserInteractionString.ToLower()];
            base_equation_model_v3.ScopeNumber = ScopeDcit[base_equation_model_v3.ScopeString.ToLower()];
            if (base_equation_model_v3.ScopeNumber == 1)
            {
                base_equation_model_v3.PrivilegesRequiredNumber = PrivilegesRequiredScopeChangedDict[base_equation_model_v3.PrivilegesRequiredString.ToLower()];
            }
            else
            {
                base_equation_model_v3.PrivilegesRequiredNumber = PrivilegesRequiredDict[base_equation_model_v3.PrivilegesRequiredString.ToLower()];
            }
            base_equation_model_v3.ConfidentialityNumber = ConfidentialityDict[base_equation_model_v3.ConfidentialityString.ToLower()];
            base_equation_model_v3.IntegrityNumber = IntegrityDict[base_equation_model_v3.IntegrityString.ToLower()];
            base_equation_model_v3.AvailabilityNumber = AvailabilityDict[base_equation_model_v3.AvailabilityString.ToLower()];

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
        }

        private void fillAttackVectorDict()
        {
            AttackVectorDict = new Dictionary<string, double>();
            AttackVectorDict.Add("network", 0.85);
            AttackVectorDict.Add("adjacent",0.62);
            AttackVectorDict.Add("local",0.55);
            AttackVectorDict.Add("physical",0.2);


        }
        private void fillAttackComplexityDict()
        {
            AttackComplexityDict = new Dictionary<string, double>();
            AttackComplexityDict.Add("low",0.77);
            AttackComplexityDict.Add("high",0.44);
        }
        private void fillPrivilegesRequiredDict()
        {
            PrivilegesRequiredDict = new Dictionary<string, double>();
            PrivilegesRequiredDict.Add("none",0.85);
            PrivilegesRequiredDict.Add("low",0.62);
            PrivilegesRequiredDict.Add("high",0.27);

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
            UserInteractionDict.Add("none",0.85);
            UserInteractionDict.Add("required",0.62);
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
        private double Roundtrip(double values)
        {
            double calculated=0;
            int valChang = (int)Math.Round(values* 100000);
            if(valChang%10000==0)
            {
                calculated = valChang / 100000.0;
                return calculated;
            }
            else
            {
                calculated = (double)Math.Floor((valChang/10000.0)+1)/10;
                return calculated;
            }
        }


    }
}
