using ApiPagamentoStone.Entities;
using ApiPagamentoStone.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiPagamentoStone.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PedidoController : Controller
    {
        private readonly IPedidoRepository _repository;

        public PedidoController(IPedidoRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Pedido>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedido()
        {
            var pedido = await _repository.GetPedido();
            return Ok(pedido);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Pedido), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pedido>> CreatePedido([FromBody] Pedido pedido)
        {
            if (pedido == null)
            
                return BadRequest("Pedido Inválido");
            
            
            await _repository.CreatePedido(pedido);

            return CreatedAtRoute("GetPedido", new { id = pedido.Id }, pedido);
            
        }

        [HttpPut]
        [ProducesResponseType(typeof(Pedido), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePedido([FromBody] Pedido pedido)
        {
           if (pedido == null)
                return BadRequest("Pedido Inválido");

           return Ok(await _repository.UpdatePedido(pedido));
        }

        [HttpDelete]
        [ProducesResponseType(typeof(Pedido), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeletePedido(string id)
        {
            return Ok(await (_repository.DeletePedido(id)));
        }
    }
}
