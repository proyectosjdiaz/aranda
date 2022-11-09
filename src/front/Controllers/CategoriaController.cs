using Aranda.Front.Model;
using Aranda.Front.Service;
using Microsoft.AspNetCore.Mvc;

namespace Aranda.Front.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly IServiceCategoria serviceCategoria;

        public CategoriaController(IServiceCategoria serviceCategoria)
        {
            this.serviceCategoria = serviceCategoria;
        }

        [HttpGet("categorias")]
        public async Task<IActionResult> Categorias()
        {
            try
            {
                var categorias = await serviceCategoria.Categorias();
                return Ok(categorias);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Categoria(int id)
        {
            try
            {
                var categoria = await serviceCategoria.Categoria(id);
                return Ok(categoria);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Crear([FromBody] CategoriaModel categoriaModel)
        {
            try
            {
                categoriaModel = await serviceCategoria.Crear(categoriaModel);
                return Ok(categoriaModel);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] CategoriaModel categoriaModel)
        {
            try
            {
                categoriaModel = await serviceCategoria.Actualizar(categoriaModel);
                return Ok(categoriaModel);
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
                var success = await serviceCategoria.Eliminar(id);
                return Ok(success);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}
