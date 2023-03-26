namespace CalculatorWebApp.Models
{
    public class Calculation
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public Operation? OperationType {get;set;}
        public long? Result { get; set; }
    }
}
