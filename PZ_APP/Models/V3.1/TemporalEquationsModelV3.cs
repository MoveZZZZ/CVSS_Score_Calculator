using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_APP.Models.V3._1
{
    public class TemporalEquationsModelV3
    {
        public double BaseScore { get; set; }
        public double TemporalScore { get; set; }
        public double Impact { get; set; }
        public double Exploitability { get; set; }
        public double ISS { get; set; }
        public double AttackVectorNumber { get; set; }
        public double AttackComplexityNumber { get; set; }
        public double PrivilegesRequiredNumber { get; set; }
        public double UserInteractionNumber { get; set; }
        public double ScopeNumber { get; set; }
        public double ConfidentialityNumber { get; set; }
        public double IntegrityNumber { get; set; }
        public double AvailabilityNumber { get; set; }
        public double ExploitCodeMaturityNumber { get; set; }
        public double RemediationLevelNumber { get; set; }
        public double ReportConfidenceNumber { get; set; }

        public string RatingTemporal { get; set; }
        public string RatingBase { get; set; }


        public string AttackVectorString { get; set; }
        public string AttackComplexityString { get; set; }
        public string PrivilegesRequiredString { get; set; }
        public string UserInteractionString { get; set; }
        public string ScopeString { get; set; }
        public string ConfidentialityString { get; set; }
        public string IntegrityString { get; set; }
        public string AvailabilityString { get; set; }
        public string ExploitCodeMaturityString { get; set; }
        public string RemediationLevelString { get; set; }
        public string ReportConfidenceString { get; set; }
    }
}
