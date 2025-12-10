using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Service;

namespace RestWithASPNET10.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class MathController : ControllerBase
    {
        private readonly MathService _mathService;

        public MathController()
        {
            _mathService = new MathService();
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            var result = _mathService.Sum(firstNumber, secondNumber);
            return result;
        }


        [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
        public IActionResult Subtraction(string firstNumber, string secondNumber)
        {

            var result = _mathService.Subtraction(firstNumber, secondNumber);
            return result;
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {

            var result = _mathService.Multiplication(firstNumber, secondNumber);
            return result;
        }

        [HttpGet("division/{firstNumber}/{secondNumber}")]
        public IActionResult Division(string firstNumber, string secondNumber)
        {
            var result = _mathService.Division(firstNumber, secondNumber);
            return result;
        }


        [HttpGet("average/{firstNumber}/{secondNumber}")]
        public IActionResult Average(string firstNumber, string secondNumber)
        {
            var result = _mathService.Average(firstNumber, secondNumber);
            return result;
        }
    }
}
