using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_APP.Models.V3._1
{
    interface IBaseEquationsRepositoryV3
    {

        void setNumberVariables(BaseEquationsModelV3 base_equation_model_v3);
        void calculateISS(BaseEquationsModelV3 base_equation_model_v3);
        void calculateImpact(BaseEquationsModelV3 base_equation_model_v3);
        void calculeteExploitability(BaseEquationsModelV3 base_equation_model_v3);
        void calculateBaseScore(BaseEquationsModelV3 base_equation_model_v3);
        void calculateRating(BaseEquationsModelV3 base_equation_model_v3);
        void calculateAllValues(BaseEquationsModelV3 base_equation_model_v3);

    }
}
