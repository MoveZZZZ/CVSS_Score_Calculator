using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PZ_APP.Models
{
    interface IBaseEquationRepository
    {
        void setNumberVariables(BaseEquationModel base_equation_model);
        void calculateBaseScore(BaseEquationModel base_equation_model);
        void calculateImpact(BaseEquationModel base_equation_model);
        void calculateExploitability(BaseEquationModel base_equation_model);
        void calculateFImpakt(BaseEquationModel base_equation_model);
        void calculateAllValues(BaseEquationModel base_equation_model);
    }
}
