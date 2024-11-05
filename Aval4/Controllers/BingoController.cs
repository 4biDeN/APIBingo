using Aval4.Services;
using Microsoft.AspNetCore.Mvc;

namespace Aval4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BingoController : ControllerBase
    {
        private readonly BingoService _bingoService;

        public BingoController(BingoService bingoService)
        {
            _bingoService = bingoService;
        }

        [HttpPost("imprimir-cartela")]
        public IActionResult ImprimirCartela([FromQuery] string jogador)
        {
            var cartela = _bingoService.ImprimirCartela(jogador);
            return Ok(cartela);
        }

        [HttpPost("sortear-numero")]
        public IActionResult SortearNumero()
        {
            var numero = _bingoService.SortearNumero();
            return Ok(numero);
        }
        /*
        [HttpGet("revelar-vencedores")]
        public IActionResult RevelarVencedores()
        {
            var vencedores = _vencedoresService.RevelarVencedores();
            return Ok(vencedores);
        }*/
    }
}
