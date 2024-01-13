using Microsoft.AspNetCore.Mvc;

namespace RestAPI.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger) {
            _logger = logger;
        }

        [HttpGet("somar/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Get(string primeiroNumero, string segundoNumero) {

            if(EhNumerico(primeiroNumero) && EhNumerico(segundoNumero)) {
                var soma = ConverterParaDecimal(primeiroNumero) + ConverterParaDecimal(segundoNumero);
                return Ok(soma.ToString());
            }

            return BadRequest("Alguma entrada inválida.");
        }

        private bool EhNumerico(string numero) {
            double valor;
            bool valido = double.TryParse(numero, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out valor);
            return valido;
        }

        private decimal ConverterParaDecimal(string primeiroNumero) {
            decimal valorDecimal;
            if(decimal.TryParse(primeiroNumero, out valorDecimal)) {
                return valorDecimal;
            }
            return 0;
        }


    }
}