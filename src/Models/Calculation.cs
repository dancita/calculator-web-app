using System.ComponentModel.DataAnnotations;

namespace CalculatorWebApp.Models
{
    public class Calculation
    {
        [Required]
        [Range(0, 1, ErrorMessage = "Number must be between 0 and 1")]
        public long NumberA { get; set; }

        [Required]
        [Range(0, 1, ErrorMessage = "Number must be between 0 and 1")]
        public long NumberB { get; set; }

        [Required(ErrorMessage = "An operation must be selected")]
        public OperationType? Operation { get; set; }
        public long? Result { get; set; }

        public enum OperationType
        {
            CombinedWith,
            Either
        }
    }
}
