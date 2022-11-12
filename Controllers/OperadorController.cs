using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api_Dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperadorController : ControllerBase
    {
    
        // POST api/<OperadorController>
        [HttpPost]
        public double post(Operacioncs operacion)
        {
            double result=0;
            switch (operacion.operador)
            {
                case "+":
                   result = operacion.num1 + operacion.num2;
                    break;
                    case "-":
                        result = operacion.num1 - operacion.num2;
                    break;
                case "*":
                    result = operacion.num1 * operacion.num2;
                    break;
                case "/":
                    result = operacion.num1 / operacion.num2;
                    break;
            }

            return result;

        }
        [HttpGet]
        public double Get([FromHeader] double num1, [FromHeader]double num2, [FromHeader]string operador)
        {
            double result = 0;
            switch (operador)
            {
                case "+":
                    result = num1 +num2;
                    break;
                case "-":
                    result = num1 - num2;
                    break;
                case "*":
                    result = num1 * num2;
                    break;
                case "/":
                    result = num1 / num2;
                    break;
            }

            return result;
           
        }



    }
}
