using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET10.Service
{
    public class MathService
    {
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if (!isNumeric(firstNumber) || !isNumeric(secondNumber))
            {
                return new BadRequestObjectResult("Invalid Input");
            }
            var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
            return new OkObjectResult(sum);
        }

        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {
            if (!isNumeric(firstNumber) || !isNumeric(secondNumber))
            {
                return new BadRequestObjectResult("Invalid Input");
            }
            var result = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);
            return new OkObjectResult(result);
        }

        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (!isNumeric(firstNumber) || !isNumeric(secondNumber))
            {
                return new BadRequestObjectResult("Invalid Input");
            }
            var result = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
            return new OkObjectResult(result);
        }
         
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            if (!isNumeric(firstNumber) || !isNumeric(secondNumber))
            {
                return new BadRequestObjectResult("Invalid Input");
            }
            var divisor = ConvertToDecimal(secondNumber);
            if (divisor == 0)
            {
                return new BadRequestObjectResult("Division by zero is not allowed.");
            }
            var result = ConvertToDecimal(firstNumber) / divisor;
            return new OkObjectResult(result);
        }

        public IActionResult Average(string firstNumber, string secondNumber)
        {
            if (!isNumeric(firstNumber) || !isNumeric(secondNumber))
            {
                return new BadRequestObjectResult("Invalid Input");
            }
            var sum = (ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2;
            return new OkObjectResult(sum);
        }   

        private decimal ConvertToDecimal(string strNumber)
        {
            decimal decimalValue;
            if (decimal.TryParse(strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalValue))
            {
                return decimalValue;
            }
            return 0;
        }

        private bool isNumeric(string strNumber)
        {
            decimal decimalValue;
            bool isNumber = decimal.TryParse(strNumber,
                System.Globalization.NumberStyles.Any,
                System.Globalization.NumberFormatInfo.InvariantInfo,
                out decimalValue);
            return isNumber;
        }
    }
}
