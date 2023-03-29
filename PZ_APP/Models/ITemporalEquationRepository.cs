using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_APP.Models
{
    interface ITemporalEquationRepository
    {
        void setNumberVariables(TemporalEquationModel temporal_equation_model);
        void calculateBaseScore(TemporalEquationModel temporal_equation_model);
        void calculateTemporalScore(TemporalEquationModel temporal_equation_model);
        void calculateImpact(TemporalEquationModel temporal_equation_model);
        void calculateExploitability(TemporalEquationModel temporal_equation_model);
        void calculateFImpakt(TemporalEquationModel temporal_equation_model);
        void calculateAllValues(TemporalEquationModel temporal_equation_model);
    }
}
