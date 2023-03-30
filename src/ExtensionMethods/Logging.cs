using CalculatorWebApp.Models;
using System.Text;

namespace CalculatorWebApp.ExtensionMethods
{
    public static class Logging
    {
        static readonly string fileLocation = "C:\\Project\\CalculatorWebApp\\";
        static readonly string fileName = "log.txt";

        public static void LogCalculation(Calculation calculation)
        {
            var currentLog = BuildCurrentLog(calculation);

            File.AppendAllText(fileLocation + fileName, currentLog);
        }

        public static string BuildCurrentLog(Calculation calculation)
        {
            return DateTime.Now.ToString() + ", OperationType: " + calculation.Operation.ToString() +
               $", number A: {calculation.NumberA}, number B: {calculation.NumberB}, result: {calculation.Result}\n";
        }
    }
}
