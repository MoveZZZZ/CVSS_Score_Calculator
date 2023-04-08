using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_APP.Models.V3._1
{
    interface IEnvironmentalEquationRepositoryV3
    {
        void setNumberVariables(EnvironmentalEquationModelV3 environmental_equation_model_v3);
        void calculateISS(EnvironmentalEquationModelV3 environmental_equation_model_v3);
        void calculateMISS(EnvironmentalEquationModelV3 environmental_equation_model_v3);
        void calculateImpact(EnvironmentalEquationModelV3 environmental_equation_model_v3);
        void calculateModifiedImpact(EnvironmentalEquationModelV3 environmental_equation_model_v3);
        void calculeteExploitability(EnvironmentalEquationModelV3 environmental_equation_model_v3);
        void calculeteModifiedExploitability(EnvironmentalEquationModelV3 environmental_equation_model_v3);
        void calculateBaseScore(EnvironmentalEquationModelV3 environmental_equation_model_v3);
        void calculateTemporalScore(EnvironmentalEquationModelV3 environmental_equation_model_v3);
        void calculateEnvironmentalScore(EnvironmentalEquationModelV3 environmental_equation_model_v3);
        void calculateRatingTemporal(EnvironmentalEquationModelV3 environmental_equation_model_v3);
        void calculateRatingBase(EnvironmentalEquationModelV3 environmental_equation_model_v3);
        void calculateRatingEnvironmental(EnvironmentalEquationModelV3 environmental_equation_model_v3);
        void calculateAllValues(EnvironmentalEquationModelV3 environmental_equation_model_v3);
        void checkDefinedVariables(EnvironmentalEquationModelV3 environmental_equation_model_v3);
    }
}
