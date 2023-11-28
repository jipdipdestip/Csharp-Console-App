using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Core
{
    public class CalculatorResult
    {
        internal decimal CalculatedResult { get; set; }
        internal bool IsCalculated { get; set; }
        internal string Error { get; set; }
    }
}