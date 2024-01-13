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
        public IActionResult Somar(string primeiroNumero, string segundoNumero) {

            if(EhNumerico(primeiroNumero) && EhNumerico(segundoNumero)) {
                var soma = ConverterParaDecimal(primeiroNumero) + ConverterParaDecimal(segundoNumero);
                return Ok(soma.ToString());
            }

            return BadRequest("Alguma entrada inválida.");
        }

        [HttpGet("subtrair/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Subtrair(string primeiroNumero, string segundoNumero) {

            if(EhNumerico(primeiroNumero) && EhNumerico(segundoNumero)) {
                var subtracao = ConverterParaDecimal(primeiroNumero) - ConverterParaDecimal(segundoNumero);
                return Ok(subtracao.ToString());
            }

            return BadRequest("Alguma entrada inválida.");
        }

        [HttpGet("dividir/{primeiroNumero}/{segundoNumero}")]
        public IActionResult Dividir(string primeiroNumero, string segundoNumero) {

            if(EhNumerico(primeiroNumero) && EhNumerico(segundoNumero)) {
                var subtracao = ConverterParaDecimal(primeiroNumero) / ConverterParaDecimal(segundoNumero);
                return Ok(subtracao.ToString());
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