using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_APP.Models
{
    public class EnvironmentalEquationModel
    {
        public double BaseScore { get; set; }
        public double BaseScoreEE { get; set; }
        public double Impact { get; set; }
        public double ExploitabilityBS { get; set; }
        public double fImpact { get; set; }
        public double TemporalScore { get; set; }
        public double TemporalScoreEE { get; set; }
        public double EnvironmentalScore { get; set; }
        public double AdjustedTemporal { get; set; }
        public double AdjustedImpact { get; set; }


        public double AccessVectorNumber { get; set; }
        public double AccessComplexityNumber { get; set; }
        public double AuthenticationNumber { get; set; }
        public double ConfImpactNumber { get; set; }
        public double IntegImpactNumber { get; set; }
        public double AvailImpactNumber { get; set; }
        public double ExploitabilityNumber { get; set; }
        public double RemediationLevelNumber { get; set; }
        public double ReportConfidenceNumber { get; set; }
        public double CollateralDamagePotentialNumber { get; set; }
        public double TargetDistributionNumber { get; set; }
        public double ConfReqNumber { get; set; }
        public double IntegReqNumber { get; set; }
        public double AvailReqNumber { get; set; }


        public string AccessVectorString { get; set; }
        public string AccessComplexityString { get; set; }
        public string AuthenticationString { get; set; }
        public string ConfImpactString { get; set; }
        public string IntegImpactString { get; set; }
        public string AvailImpactString { get; set; }
        public string ExploitabilityString { get; set; }
        public string RemediationLevelString { get; set; }
        public string ReportConfidenceString { get; set; }
        public string CollateralDamagePotentialString { get; set; }
        public string TargetDistributionString { get; set; }
        public string ConfReqString { get; set; }
        public string IntegReqString { get; set; }
        public string AvailReqString { get; set; }



    }
}
