namespace CalculatorWebApp.Models
{
    public class Calculation
    {
        public int AmountOfNumbers { get; set; } = 2;
        public long[]? NumbersList { get; set; }
        public OperationType? Operation { get; set; }
        public long? Result { get; set; }

        public enum OperationType
        {
            Add,
            Multiply
        }
    }
}
