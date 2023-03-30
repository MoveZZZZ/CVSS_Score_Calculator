using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_APP.Models
{
    interface IEnvironmentalEquationRepository
    {
        void setNumberVariables(EnvironmentalEquationModel environmental_equation_model);
        void calculateBaseScore(EnvironmentalEquationModel environmental_equation_model);
        void calculateBaseScoreForEnvironmentalEquation(EnvironmentalEquationModel environmental_equation_model);
        void calculateTemporalScore(EnvironmentalEquationModel environmental_equation_model);
        void calculateTemporalScoreForEnvironmentalEquation(EnvironmentalEquationModel environmental_equation_model);
        void calculateImpact(EnvironmentalEquationModel environmental_equation_model);
        void calculateExploitability(EnvironmentalEquationModel environmental_equation_model);
        void calculateFImpakt(EnvironmentalEquationModel environmental_equation_model);
        void calculateFImpaktEE(EnvironmentalEquationModel environmental_equation_model);
        void calculateAllValues(EnvironmentalEquationModel environmental_equation_model);


        void calculateEnvironmentalScore(EnvironmentalEquationModel environmental_equation_model);
        void calculateAdjustedTemporal(EnvironmentalEquationModel environmental_equation_model);
        void calculateAdjustedImpact(EnvironmentalEquationModel environmental_equation_model);
    }
}
