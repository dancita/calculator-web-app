using System.ComponentModel.DataAnnotations;

namespace CalculatorWebApp.Models
{
    public class Calculation
    {
        [Required]
        [Range((typeof(decimal)), "0.0", "1.0", ErrorMessage = "Number must be between 0 and 1")]
        public decimal NumberA { get; set; }

        [Required]
        [Range((typeof(decimal)), "0.0", "1.0", ErrorMessage = "Number must be between 0 and 1")]
        public decimal NumberB { get; set; }

        [Required(ErrorMessage = "An operation must be selected")]
        public OperationType? Operation { get; set; }
        public decimal? Result { get; set; }

        public enum OperationType
        {
            CombinedWith,
            Either
        }
    }
}
