using Aranda.Negocio.Abstracciones;
using Aranda.Negocio.DTO;
using Aranda.Negocio.Reglas;
using Microsoft.AspNetCore.Mvc;

namespace Aranda.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoReglas productoReglas;

        public ProductoController(IProductoReglas productoReglas)
        {
            this.productoReglas = productoReglas;
        }

        [HttpGet("productos")]
        public async Task<IActionResult> Productos()
        {
            try
            {
                var productos = await productoReglas.Productos();
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
                var producto = await productoReglas.Producto(id);
                return Ok(producto);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] ProductoDTO productoDTO)
        {
            try
            {
                productoDTO = await productoReglas.Crear(productoDTO);
                return Ok(productoDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] ProductoDTO productoDTO)
        {
            try
            {
                productoDTO = await productoReglas.Actualizar(productoDTO);
                return Ok(productoDTO);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                bool success = await productoReglas.Eliminar(id);
                return Ok(success);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
