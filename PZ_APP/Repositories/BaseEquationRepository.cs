using PZ_APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_APP.Repositories
{
    public class BaseEquationRepository : IBaseEquationRepository
    {
        Dictionary<string, double> AccessVectorValuesDict;
        Dictionary<string, double> AccessComplexityValuesDict;
        Dictionary<string, double> AuthenticationValuesDict;
        Dictionary<string, double> ConfImpactValuesDict;
        Dictionary<string, double> IntegImpactValuesDict;
        Dictionary<string, double> AvailImpactValuesDict;

        public BaseEquationRepository()
        {
            fillDictionaries();
        }
        public void calculateAllValues(BaseEquationModel base_equation_model)
        {
            calculateImpact(base_equation_model);
            calculateFImpakt(base_equation_model);
            calculateExploitability(base_equation_model);
            calculateBaseScore(base_equation_model);
        }
        public void calculateBaseScore(BaseEquationModel base_equation_model)
        {
            double baseScore = 0;
            baseScore = ((0.6 * base_equation_model.Impact) + (0.4 * base_equation_model.Exploitability) - 1.5) * base_equation_model.fImpact;
            base_equation_model.BaseScore = Math.Round(baseScore, 1);
        }

        public void calculateExploitability(BaseEquationModel base_equation_model)
        {
            base_equation_model.Exploitability = 20 * base_equation_model.AccessVectorNumber * base_equation_model.AccessComplexityNumber * base_equation_model.AuthenticationNumber;
        }

        public void calculateFImpakt(BaseEquationModel base_equation_model)
        {
            if(base_equation_model.Impact == 0)
            {
                base_equation_model.fImpact = 0;
            }
            else
            {
                base_equation_model.fImpact = 1.176;
            }
        }

        public void calculateImpact(BaseEquationModel base_equation_model)
        {
            base_equation_model.Impact = 10.41 * (1 - (1 - base_equation_model.ConfImpactNumber) * (1 - base_equation_model.IntegImpactNumber) * (1 - base_equation_model.AvailImpactNumber));
        }

        public void setNumberVariables(BaseEquationModel base_equation_model)
        {
            base_equation_model.AccessVectorNumber = AccessVectorValuesDict[base_equation_model.AccessVectorString.ToLower()];
            base_equation_model.AccessComplexityNumber = AccessComplexityValuesDict[base_equation_model.AccessComplexityString.ToLower()];
            base_equation_model.AuthenticationNumber = AuthenticationValuesDict[base_equation_model.AuthenticationString.ToLower()];
            base_equation_model.ConfImpactNumber = ConfImpactValuesDict[base_equation_model.ConfImpactString.ToLower()];
            base_equation_model.IntegImpactNumber = IntegImpactValuesDict[base_equation_model.IntegImpactString.ToLower()];
            base_equation_model.AvailImpactNumber = AvailImpactValuesDict[base_equation_model.AvailImpactString.ToLower()];
        }
        private void fillDictionaries()
        {
            FillAccessVectorDict();
            FillAccessComplexityDict();
            FillAuthenticationDict();
            FillConfImpactDict();
            FillIntegImpact();
            FillAvailImpact();
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
            ConfImpactValuesDict.Add("complete",0.660);
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


    }
}
