namespace Calculator.Core
{
    public class CalculateService
    {
        public CalculatorResult PerformCalculation(decimal number1, decimal number2, char oper)
        {
            decimal result = CalculateResult(number1, number2, oper);
            return CreateCalculatorResult(result);
        }

        private decimal CalculateResult(decimal number1, decimal number2, char oper)
        {
            switch (oper)
            {
                case '+':
                    return number1 + number2;
                case '-':
                    return number1 - number2;
                case '/':
                    return number2 == 0
                        ? 0
                        : number1 / number2;
                case '*':
                    return number1 * number2;
                default:
                    return 0;
            }
        }

        private CalculatorResult CreateCalculatorResult(decimal result)
        {
            if (result == 0)
            {
                return new CalculatorResult()
                {
                    CalculatedResult = 0,
                    IsCalculated = false,
                    Error = result == 0 ? "Cannot divide by zero" : "Invalid operation"
                };
            }
            else
            {
                return new CalculatorResult()
                {
                    CalculatedResult = result,
                    IsCalculated = true,
                    Error = ""
                };
            }
        }
    }
}
