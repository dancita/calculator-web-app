using CalculatorWebApp.Models;

namespace CalculatorWebApp.ExtensionMethods
{
    public static class Calculations
    {
        public static decimal? CalculateResult(Calculation calculation)
        {
            var multiplyResult = Multiply(calculation.NumberA, calculation.NumberB);
            decimal? result = null;
            switch (calculation.Operation)
            {
                case Calculation.OperationType.CombinedWith:
                    result = multiplyResult;
                    break;
                case Calculation.OperationType.Either:
                    result = Add(calculation.NumberA, calculation.NumberB) - multiplyResult;
                    break;
            }
            return result;
        }

        public static decimal Add(decimal numberA, decimal numberB)
        {
            return numberA + numberB;
        }

        public static decimal Multiply(decimal numberA, decimal numberB)
        {
            return numberA * numberB;
        }
    }
}
