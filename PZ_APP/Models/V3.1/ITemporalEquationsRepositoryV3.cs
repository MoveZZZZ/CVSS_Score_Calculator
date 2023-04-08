using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_APP.Models.V3._1
{
    interface ITemporalEquationsRepositoryV3
    {
        void setNumberVariables(TemporalEquationsModelV3 temporal_equation_model_v3);
        void calculateISS(TemporalEquationsModelV3 temporal_equation_model_v3);
        void calculateImpact(TemporalEquationsModelV3 temporal_equation_model_v3);
        void calculeteExploitability(TemporalEquationsModelV3 temporal_equation_model_v3);
        void calculateBaseScore(TemporalEquationsModelV3 temporal_equation_model_v3);
        void calculateTemporalScore(TemporalEquationsModelV3 temporal_equation_model_v3);
        void calculateRatingTemporal(TemporalEquationsModelV3 temporal_equation_model_v3);
        void calculateRatingBase(TemporalEquationsModelV3 temporal_equation_model_v3);
        void calculateAllValues(TemporalEquationsModelV3 temporal_equation_model_v3);
    }
}
