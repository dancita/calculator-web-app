using System.ComponentModel.DataAnnotations;

namespace CalculatorWebApp.Models
{
    public class Calculation
    {
       [Range(0, 1, ErrorMessage = "Number must be between 0 and 1")]
        public long NumberA { get; set; }
        [Range(0, 1, ErrorMessage = "Number must be between 0 and 1")]
        public long NumberB { get; set; }
        public OperationType? Operation { get; set; }
        public long? Result { get; set; }

        public enum OperationType
        {
            Add,
            Multiply
        }
    }
}
