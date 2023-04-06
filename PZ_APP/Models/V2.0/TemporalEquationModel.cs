using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_APP.Models
{
    public class TemporalEquationModel
    {
        public double BaseScore { get; set; }
        public double Impact { get; set; }
        public double ExploitabilityBS { get; set; }
        public double fImpact { get; set; }
        public double TemporalScore { get; set; }


        public double AccessVectorNumber { get; set; }
        public double AccessComplexityNumber { get; set; }
        public double AuthenticationNumber { get; set; }
        public double ConfImpactNumber { get; set; }
        public double IntegImpactNumber { get; set; }
        public double AvailImpactNumber { get; set; }
        public double ExploitabilityNumber { get; set; }
        public double RemediationLevelNumber { get; set; }
        public double ReportConfidenceNumber { get; set; }


        public string AccessVectorString { get; set; }
        public string AccessComplexityString { get; set; }
        public string AuthenticationString { get; set; }
        public string ConfImpactString { get; set; }
        public string IntegImpactString { get; set; }
        public string AvailImpactString { get; set; }
        public string ExploitabilityString { get; set; }
        public string RemediationLevelString { get; set; }
        public string ReportConfidenceString { get; set; }
    }
}
