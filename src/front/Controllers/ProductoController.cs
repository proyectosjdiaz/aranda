using Aranda.Front.Model;
using Aranda.Front.Service;
using Microsoft.AspNetCore.Mvc;

namespace Aranda.Front.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly IServiceProducto serviceProducto;

        public ProductoController(IServiceProducto serviceProducto)
        {
            this.serviceProducto = serviceProducto;
        }

        [HttpGet("productos")]
        public async Task<IActionResult> Productos()
        {
            try
            {
                var productos = await serviceProducto.Productos();
                return Ok(productos);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Producto(int id)
        {
            try
            {
                var productos = await serviceProducto.Producto(id);
                return Ok(productos);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ProductoModel productoModel)
        {
            try
            {
                productoModel = await serviceProducto.Crear(productoModel);
                return Ok(productoModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] ProductoModel productoModel)
        {
            try
            {
                productoModel = await serviceProducto.Actualizar(productoModel);
                return Ok(productoModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Eliminar([FromQuery] int id)
        {
            try
            {
                var success = await serviceProducto.Eliminar(id);
                return Ok(success);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
