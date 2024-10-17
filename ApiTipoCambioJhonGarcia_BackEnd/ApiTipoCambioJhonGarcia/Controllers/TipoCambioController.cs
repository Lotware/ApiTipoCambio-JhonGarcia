using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ApiTipoCambioJhonGarcia.Data;
using ApiTipoCambioJhonGarcia.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;


namespace ApiTipoCambioJhonGarcia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCambioController : ControllerBase
    {
        private readonly TipoCambioContext _context;

        public TipoCambioController(TipoCambioContext context)
        {
            _context = context;
        }

        // POST: api/TipoCambio
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<decimal>> AplicarTipoCambio([FromBody] AplicarCambioRequest request)
        {
            var tipoCambio = await _context.TiposDeCambio
                .FirstOrDefaultAsync(tc => tc.MonedaOrigen == request.MonedaOrigen && tc.MonedaDestino == request.MonedaDestino);

            if (tipoCambio == null)
            {
                return NotFound("Tipo de cambio no encontrado.");
            }

            var montoConTipoCambio = request.Monto * tipoCambio.ValorCambio;

            return Ok(new
            {
                Monto = request.Monto,
                MontoConTipoCambio = montoConTipoCambio,
                MonedaOrigen = request.MonedaOrigen,
                MonedaDestino = request.MonedaDestino,
                TipoDeCambio = tipoCambio.ValorCambio
            });
        }

        // POST: api/TipoCambio/Actualizar
        [Authorize]
        [HttpPost("actualizar")]
        public async Task<IActionResult> ActualizarTipoCambio([FromBody] TipoCambio tipoCambio)
        {
            var tipoCambioExistente = await _context.TiposDeCambio
                .FirstOrDefaultAsync(tc => tc.MonedaOrigen == tipoCambio.MonedaOrigen && tc.MonedaDestino == tipoCambio.MonedaDestino);

            if (tipoCambioExistente != null)
            {
                tipoCambioExistente.ValorCambio = tipoCambio.ValorCambio;
                _context.TiposDeCambio.Update(tipoCambioExistente);
            }
            else
            {
                _context.TiposDeCambio.Add(tipoCambio);
            }

            await _context.SaveChangesAsync();

            return Ok(tipoCambio);
        }
    }

    public class AplicarCambioRequest
    {
        public decimal Monto { get; set; }
        public string MonedaOrigen { get; set; }
        public string MonedaDestino { get; set; }
    }
}
