using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace CalculatorWebApp.Models
{
    public class Calculation
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public OperationType? Operation {get;set;}
        public long? Result { get; set; }

        public enum OperationType
        {
            Add,
            Multiply
        }
    }
}
